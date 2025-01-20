// Copyright Ryan Scott White, 2025
// Released under the MIT License. Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sub-license, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

// Created almost entirely with ChatGPT.

using Microsoft.VisualBasic.FileIO; // For FileSystem.DeleteFile
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;

namespace DuplicateFileRemover
{
    public partial class MainForm : Form
    {
        // Data model for duplicates
        private class DuplicateGroup
        {
            public List<string> FilePaths { get; } = [];
            public long FileSize { get; set; }
            public bool IsConfirmedFullHash { get; set; } = false; // Tracks if we confirmed duplicates by full hash
            public string FullHash { get; set; } = string.Empty;     // Optional: store the final full hash

            // For UI convenience we store a "Representative" path or display name
            public string RepresentativePath => FilePaths.FirstOrDefault() ?? "";
        }

        // A structure to hold scanning options
        private class ScanOptions
        {
            public List<string> FoldersToScan { get; set; } = [];
            public bool IncludeHidden { get; set; } = false;
        }

        // We'll track all groups by a composite key of (fileSize, partialHash).
        private readonly Dictionary<(long, string), DuplicateGroup> potentialDuplicates
            = [];

        // Once scanning is done, we convert them into a final list to show in the DataGridView
        private readonly List<DuplicateGroup> finalDuplicateGroups = [];

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selected = fbd.SelectedPath;

                // 1) Prevent duplicates
                if (listBoxFolders.Items.Contains(selected))
                {
                    _ = MessageBox.Show($"Folder '{selected}' is already in the list.",
                                    "Duplicate Folder",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                // 2) Restrict system folders. You can decide how strict you want to be.
                // For example:
                string systemDrive = Path.GetPathRoot(Environment.SystemDirectory) ?? @"C:\";
                // e.g. "C:\" 
                string systemRoot = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                // e.g. "C:\Windows"
                string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                // e.g. "C:\Program Files"
                // You can also check ProgramFilesX86, etc.

                // A quick check: if the selected folder is inside one of those special folders,
                // either you display a warning or disallow it.
                if (IsSubfolderOf(selected, systemRoot) ||
                    IsSubfolderOf(selected, programFiles) ||
                    IsSubfolderOf(selected, systemDrive + "Program Files") || // alternative
                    IsSubfolderOf(selected, systemDrive + "Windows"))
                {
                    DialogResult result = MessageBox.Show(
                        $"Warning: '{selected}' appears to be a system folder. " +
                        "Proceeding may cause instability if duplicates are removed. " +
                        "Are you sure you want to add this folder to the scan list?",
                        "System Folder Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                // If we’re still here, add the folder:
                _ = listBoxFolders.Items.Add(selected);
            }
        }

        private void ButtonRemoveFolder_Click(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedIndex >= 0)
            {
                listBoxFolders.Items.RemoveAt(listBoxFolders.SelectedIndex);
            }
            else
            {
                _ = MessageBox.Show("No folder selected to remove.", "Remove Folder",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonMoveUp_Click(object sender, EventArgs e)
        {
            int idx = listBoxFolders.SelectedIndex;
            if (idx > 0) // not already at top
            {
                object folder = listBoxFolders.Items[idx];
                listBoxFolders.Items.RemoveAt(idx);
                listBoxFolders.Items.Insert(idx - 1, folder);
                listBoxFolders.SelectedIndex = idx - 1; // re-select the moved item
            }
        }

        private void ButtonMoveDown_Click(object sender, EventArgs e)
        {
            int idx = listBoxFolders.SelectedIndex;
            if (idx >= 0 && idx < listBoxFolders.Items.Count - 1) // not already at bottom
            {
                object folder = listBoxFolders.Items[idx];
                listBoxFolders.Items.RemoveAt(idx);
                listBoxFolders.Items.Insert(idx + 1, folder);
                listBoxFolders.SelectedIndex = idx + 1; // re-select the moved item
            }
        }

        // Helper method to test if `candidate` is a subfolder of `parentPath`
        private bool IsSubfolderOf(string candidate, string parentPath)
        {
            // Normalize them to avoid trailing slashes, case differences, etc.
            DirectoryInfo candidateInfo = new(candidate);
            DirectoryInfo parentInfo = new(parentPath);

            // Walk up the directory tree of 'candidate' to see if we eventually reach 'parent'
            while (candidateInfo.Parent != null)
            {
                if (candidateInfo.FullName.Equals(parentInfo.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                candidateInfo = candidateInfo.Parent;
            }
            return false;
        }


        private void ButtonStartScan_Click(object sender, EventArgs e)
        {
            if (listBoxFolders.Items.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one folder to scan.", "No Folders Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Switch to the scanning tab
            tabControlMain.SelectedTab = tabPageProgress;

            // Prepare scanning options
            ScanOptions options = new()
            {
                IncludeHidden = checkBoxIncludeHidden.Checked,
                FoldersToScan = listBoxFolders.Items.Cast<string>().ToList()
            };

            // Clear out old data
            potentialDuplicates.Clear();
            finalDuplicateGroups.Clear();
            dataGridViewResults.Rows.Clear();

            // Start the background worker
            backgroundWorker.RunWorkerAsync(options);
            buttonStartScan.Enabled = false;
            buttonSelectFolder.Enabled = false;
            buttonDeleteSelected.Enabled = false;
        }

        // The scanning work is done in the background here
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker || e.Argument == null)
            {
                e.Cancel = true;
                return;
            }
            ScanOptions options = (ScanOptions)e.Argument;

            // Let's define the weight (in % of overall) for each step:
            //   Step A (Enumerate): 20%
            //   Step B (Partial hashing): 50%
            //   Step C (Full hashing): 30%
            double stepAWeight = 20.0;
            double stepBWeight = 50.0;
            double stepCWeight = 30.0;

            // -------------------------------------------------------
            // Step A) Gather/Enumerate all files
            // -------------------------------------------------------
            List<string> allFiles = [];
            List<string> foldersToScan = options.FoldersToScan;

            // We don't know how many folders in total up front, 
            // but let's just say each folder enumerated is worth
            // the same fraction of Step A. Or you can sum up # of subdirs first, etc.

            // "subProgressA" will represent 0..100% of sub-task A
            // "overallProgress" will incorporate all steps.
            double subProgressA = 0;
            int foldersDone = 0;
            int totalFolders = foldersToScan.Count; // if you have subfolders, you can refine this

            foreach (string folder in foldersToScan)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    allFiles.AddRange(EnumerateAllFiles(folder, options.IncludeHidden));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error enumerating {folder}: {ex.Message}");
                }

                foldersDone++;
                // Sub-task progress for enumeration
                subProgressA = 100.0 * foldersDone / Math.Max(totalFolders, 1);

                // Overall progress: combine the weighting
                // We'll say we've completed subProgressA% of the 20% assigned to step A
                double overallProgress = subProgressA / 100.0 * stepAWeight;

                // Report progress
                // We'll use `UserState` to pass the sub-progress so we can update the second bar
                worker.ReportProgress(
                    (int)Math.Round(overallProgress),
                    new { SubTaskProgress = (int)Math.Round(subProgressA), Message = "Enumerating folders..." }
                );
            }

            // -------------------------------------------------------
            // Step B) Partial hashing of all files
            // -------------------------------------------------------
            int fileCount = allFiles.Count;
            int processed = 0;
            // We might update subProgressB from 0..100
            double subProgressB = 0;

            // To avoid too-frequent updates, define a step
            // e.g. if you have 1,000 files, update every 2 or 5 or 10 files
            // We can use the logic from your snippet:
            int onePercentOfFiles = 1 + (fileCount / 100);

            foreach (string file in allFiles)
            {
                if (worker.CancellationPending) { e.Cancel = true; return; }

                // (Same logic from your snippet)
                long fileSize = 0;
                try
                {
                    FileInfo fi = new(file);
                    fileSize = fi.Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cannot get file size for {file}: {ex.Message}");
                    processed++;
                    goto HashDone; // skip hashing, continue
                }

                string partialHash = ComputePartialMD5(file, 4096);

                (long fileSize, string partialHash) key = (fileSize, partialHash);
                if (!potentialDuplicates.ContainsKey(key))
                {
                    potentialDuplicates[key] = new DuplicateGroup
                    {
                        FileSize = fileSize
                    };
                }

                potentialDuplicates[key].FilePaths.Add(file);

                processed++;
            HashDone:;
                // Sub-task progress for partial hashing
                if (processed % onePercentOfFiles == 0)
                {
                    subProgressB = 100.0 * processed / Math.Max(fileCount, 1);

                    // Overall progress from step A is complete, so that was 20%. 
                    // Now we're in step B, which is 50% of overall. So partial hashing
                    // contributes up to 50% more to the total (20..70% range if you prefer,
                    // or 20..70 or 20..80, etc.). Let's do a direct weighting for clarity:
                    double overallProgress =
                        stepAWeight + // step A is done
                        (subProgressB / 100.0 * stepBWeight);

                    worker.ReportProgress(
                        (int)Math.Round(overallProgress),
                        new { SubTaskProgress = (int)Math.Round(subProgressB), Message = "Partial hashing..." }
                    );
                }
            }

            // Once partial hashing is completely finished,
            // ensure we set subProgressB = 100, overall to 20% + 50% = 70% (for example).
            subProgressB = 100.0;
            {
                double overallProgress = stepAWeight + stepBWeight; // 70%
                worker.ReportProgress(
                    (int)Math.Round(overallProgress),
                    new { SubTaskProgress = (int)Math.Round(subProgressB), Message = "Partial hashing done." }
                );
            }

            // -------------------------------------------------------
            // Step C) Full hashing for duplicates
            // -------------------------------------------------------
            double subProgressC = 0;
            // Determine how many files we actually need to full-hash
            // We can sum them up from the potential duplicate dictionary
            // that have more than 1 in each group.
            List<string> filesNeedingFullHash = [];
            foreach (KeyValuePair<(long, string), DuplicateGroup> kvp in potentialDuplicates)
            {
                if (kvp.Value.FilePaths.Count > 1)
                {
                    filesNeedingFullHash.AddRange(kvp.Value.FilePaths);
                }
            }
            int totalFullHash = filesNeedingFullHash.Count;
            int doneFullHash = 0;

            foreach (KeyValuePair<(long, string), DuplicateGroup> kvp in potentialDuplicates)
            {
                DuplicateGroup group = kvp.Value;
                if (group.FilePaths.Count > 1)
                {
                    // We'll compute a full hash for each file in group.FilePaths
                    Dictionary<string, List<string>> fullHashMap = [];
                    foreach (string file in group.FilePaths)
                    {
                        if (worker.CancellationPending) { e.Cancel = true; return; }

                        string fullHash = ComputeFullMD5(file);
                        if (!fullHashMap.ContainsKey(fullHash))
                        {
                            fullHashMap[fullHash] = [];
                        }
                        fullHashMap[fullHash].Add(file);

                        // Update sub-progress after each full hash
                        doneFullHash++;
                        if (doneFullHash % 5 == 0) // update every N to avoid overhead
                        {
                            subProgressC = 100.0 * doneFullHash / Math.Max(totalFullHash, 1);
                            double overallProgress =
                                stepAWeight + stepBWeight + // first two steps
                                (subProgressC / 100.0 * stepCWeight); // portion of the last step

                            worker.ReportProgress(
                                (int)Math.Round(overallProgress),
                                new { SubTaskProgress = (int)Math.Round(subProgressC), Message = "Confirming duplicates (full hash)..." }
                            );
                        }
                    }

                    // group them
                    foreach (KeyValuePair<string, List<string>> fKvp in fullHashMap)
                    {
                        if (fKvp.Value.Count > 1)
                        {
                            DuplicateGroup newGroup = new()
                            {
                                FileSize = group.FileSize,
                                IsConfirmedFullHash = true,
                                FullHash = fKvp.Key
                            };
                            newGroup.FilePaths.AddRange(fKvp.Value);
                            finalDuplicateGroups.Add(newGroup);
                        }
                    }
                }
            }

            // Once full hashing is done, set subProgressC = 100
            subProgressC = 100.0;
            {
                double overallProgress = stepAWeight + stepBWeight + stepCWeight; // 100%
                worker.ReportProgress(
                    (int)Math.Round(overallProgress),
                    new { SubTaskProgress = (int)Math.Round(subProgressC), Message = "Full hashing done." }
                );
            }

            // No more tasks, done.
            // (You might not want to do .Invoke() from within DoWork, but if you do:
            Invoke(new Action(() =>
            {
                buttonStartScan.Enabled = true;
                buttonSelectFolder.Enabled = true;
                buttonDeleteSelected.Enabled = true;
            }));
        }


        private List<string> EnumerateAllFiles(string folder, bool includeHidden)
        {
            List<string> result = [];

            try
            {
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    try
                    {
                        FileAttributes attr = File.GetAttributes(file);
                        if (!includeHidden && (attr & FileAttributes.Hidden) == FileAttributes.Hidden)
                        {
                            continue;
                        }

                        result.Add(file);
                    }
                    catch { /* skip */ }
                }

                string[] subDirs = Directory.GetDirectories(folder);
                foreach (string dir in subDirs)
                {
                    try
                    {
                        FileAttributes attr = File.GetAttributes(dir);
                        if (!includeHidden && (attr & FileAttributes.Hidden) == FileAttributes.Hidden)
                        {
                            continue;
                        }

                        result.AddRange(EnumerateAllFiles(dir, includeHidden));
                    }
                    catch { /* skip */ }
                }
            }
            catch { /* skip */ }

            return result;
        }

        private string ComputePartialMD5(string filePath, int bytesToRead)
        {
            try
            {
                using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] buffer = new byte[Math.Min(bytesToRead, (int)fs.Length)];
                _ = fs.Read(buffer, 0, buffer.Length);
                using MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(buffer);
                return BitConverter.ToString(hash).Replace("-", "");
            }
            catch
            {
                // fallback
                return "ERROR";
            }
        }

        private string ComputeFullMD5(string filePath)
        {
            try
            {
                using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(fs);
                return BitConverter.ToString(hash).Replace("-", "");
            }
            catch
            {
                // fallback
                return "ERROR";
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            labelProgressInfo.Text = $"Scanning: {e.UserState}";
        }


        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 100;
            labelProgressInfo.Text = "Scan complete.";

            // Now display final duplicates
            tabControlMain.SelectedTab = tabPageResults;

            // Flatten them into the DataGridView
            long totalPossibleSpace = 0;
            foreach (DuplicateGroup group in finalDuplicateGroups)
            {
                // For each group, we want to keep one file (the user can keep whichever they want).
                // We'll mark the rest as "delete" by default.
                // Each file in the group gets a row in the DataGridView.
                // We'll store in a 'row object' with columns for check (bool), path, size, group reference, etc.

                bool firstInGroup = true;
                foreach (string filePath in group.FilePaths)
                {
                    // By default, we only want to check duplicates beyond the "first"
                    bool deleteByDefault = !firstInGroup;
                    if (!firstInGroup)
                    {
                        totalPossibleSpace += group.FileSize;
                    }
                    firstInGroup = false;

                    _ = dataGridViewResults.Rows.Add(
                        deleteByDefault, // "Delete?" col
                        filePath,        // "File Path" col
                        group.FileSize.ToString() // "Size (Bytes)"
                    );
                }
            }

            labelTotalSpaceSaved.Text = $"Total space that could be freed (if all duplicates deleted): {totalPossibleSpace} bytes";
        }


        // 2) The button click just prepares the list and starts the worker
        private void ButtonDeleteSelected_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected.Enabled = false;  // disable the button to prevent double-click
            // Gather selected files
            List<string> filesToDelete = new List<string>();
            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                bool isChecked = row.Cells[0].Value is bool val && val;
                if (isChecked && row.Cells[1].Value is string path)
                {
                    filesToDelete.Add(path);
                }
            }

            if (filesToDelete.Count == 0)
            {
                MessageBox.Show("No files selected for deletion.");
                buttonDeleteSelected.Enabled = true; // re-enable the button
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to move {filesToDelete.Count} file(s) to the Recycle Bin?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                tabControlMain.SelectedTab = tabPageProgress;
                backgroundWorkerDelete.RunWorkerAsync(filesToDelete);
            }
            else
            {
                buttonDeleteSelected.Enabled = true; // re-enable the button
            }
        }

        // 3) DoWork on the second BackgroundWorker
        private void BackgroundWorkerDelete_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            if (e.Argument is not List<string> filesToDelete)
            {
                e.Cancel = true;
                return;
            }

            int successCount = 0;
            int totalCount = 0;
            int fileCount = filesToDelete.Count;

            foreach (string file in filesToDelete)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    // This can be slow if 100k files are going to the Recycle Bin, but 
                    // at least it's on a background thread, so it won't block the UI.
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                        file,
                        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                        Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                    successCount++;
                }
                catch (Exception ex)
                {
                    // Log or handle individual file errors
                    Console.WriteLine($"Error deleting {file}: {ex.Message}");
                }

                totalCount++;
                // We can report progress every so often (e.g., every 1%, or every N files)
                if (totalCount % 1000 == 0 || totalCount == fileCount)
                {
                    int percentDone = (int)((double)totalCount / fileCount * 100);
                    worker.ReportProgress(percentDone, new { successCount, totalCount });
                }
            }

            // Store results in e.Result for use in RunWorkerCompleted
            e.Result = (successCount, totalCount);
        }

        // 4) Update progress in ProgressChanged
        private void BackgroundWorkerDelete_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // e.ProgressPercentage is overall progress
            progressBar.Value = Math.Min(100, e.ProgressPercentage);

            // If you want, you can read the successCount, totalCount from e.UserState
            if (e.UserState is { } userState)
            {
                var propSuccess = userState.GetType().GetProperty("successCount");
                var propTotal = userState.GetType().GetProperty("totalCount");
                if (propSuccess != null && propTotal != null)
                {
                    int sc = (int)(propSuccess.GetValue(userState) ?? 0);
                    int tc = (int)(propTotal.GetValue(userState) ?? 0);
                    labelProgressInfo.Text = $"Deleting... {sc} / {tc} deleted.";
                }
            }
        }

        // 5) Once done
        private void BackgroundWorkerDelete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonDeleteSelected.Enabled = true;
            progressBar.Value = 100;

            if (e.Cancelled)
            {
                labelProgressInfo.Text = "Deletion canceled.";
            }
            else if (e.Error != null)
            {
                labelProgressInfo.Text = $"Error: {e.Error.Message}";
            }
            else
            {
                (int successCount, int totalCount) result = ((int, int))e.Result;
                labelProgressInfo.Text = $"Deleted {result.successCount} of {result.totalCount} files to Recycle Bin.";
                MessageBox.Show($"Deleted {result.successCount} file(s) to the Recycle Bin.");
            }

            // Now display final duplicates
            tabControlMain.SelectedTab = tabPageResults;
        }
    }
}
