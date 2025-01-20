using System.ComponentModel;

namespace DuplicateFileRemover
{
    partial class MainForm
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabPageSelectFolders = new TabPage();
            listBoxFolders = new ListBox();
            panel3 = new Panel();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            buttonRemoveFolder = new Button();
            buttonSelectFolder = new Button();
            panel2 = new Panel();
            label1 = new Label();
            buttonStartScan = new Button();
            labelWarning = new Label();
            checkBoxIncludeHidden = new CheckBox();
            tabPageProgress = new TabPage();
            progressBar = new ProgressBar();
            labelProgressInfo = new Label();
            tabPageResults = new TabPage();
            panel1 = new Panel();
            labelTotalSpaceSaved = new Label();
            buttonDeleteSelected = new Button();
            dataGridViewResults = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colPath = new DataGridViewTextBoxColumn();
            backgroundWorker = new BackgroundWorker();
            backgroundWorkerDelete = new BackgroundWorker();
            tabControlMain.SuspendLayout();
            tabPageSelectFolders.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tabPageProgress.SuspendLayout();
            tabPageResults.SuspendLayout();
            panel1.SuspendLayout();
            ((ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageSelectFolders);
            tabControlMain.Controls.Add(tabPageProgress);
            tabControlMain.Controls.Add(tabPageResults);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1000, 600);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageSelectFolders
            // 
            tabPageSelectFolders.Controls.Add(listBoxFolders);
            tabPageSelectFolders.Controls.Add(panel3);
            tabPageSelectFolders.Controls.Add(panel2);
            tabPageSelectFolders.Location = new Point(4, 29);
            tabPageSelectFolders.Name = "tabPageSelectFolders";
            tabPageSelectFolders.Size = new Size(992, 567);
            tabPageSelectFolders.TabIndex = 0;
            tabPageSelectFolders.Text = "Select Folders";
            // 
            // listBoxFolders
            // 
            listBoxFolders.Dock = DockStyle.Fill;
            listBoxFolders.Location = new Point(0, 0);
            listBoxFolders.Name = "listBoxFolders";
            listBoxFolders.Size = new Size(867, 326);
            listBoxFolders.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonMoveDown);
            panel3.Controls.Add(buttonMoveUp);
            panel3.Controls.Add(buttonRemoveFolder);
            panel3.Controls.Add(buttonSelectFolder);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(867, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(125, 326);
            panel3.TabIndex = 6;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Font = new Font("Segoe UI", 18F);
            buttonMoveDown.Location = new Point(3, 159);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(117, 48);
            buttonMoveDown.TabIndex = 3;
            buttonMoveDown.Text = "↓";
            buttonMoveDown.Click += ButtonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Font = new Font("Segoe UI", 18F);
            buttonMoveUp.Location = new Point(3, 105);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(117, 48);
            buttonMoveUp.TabIndex = 2;
            buttonMoveUp.Text = "↑";
            buttonMoveUp.Click += ButtonMoveUp_Click;
            // 
            // buttonRemoveFolder
            // 
            buttonRemoveFolder.Location = new Point(3, 51);
            buttonRemoveFolder.Name = "buttonRemoveFolder";
            buttonRemoveFolder.Size = new Size(117, 48);
            buttonRemoveFolder.TabIndex = 1;
            buttonRemoveFolder.Text = "Remove Folder";
            buttonRemoveFolder.Click += ButtonRemoveFolder_Click;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new Point(3, 0);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(117, 45);
            buttonSelectFolder.TabIndex = 0;
            buttonSelectFolder.Text = "Add Folder";
            buttonSelectFolder.Click += ButtonSelectFolder_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(buttonStartScan);
            panel2.Controls.Add(labelWarning);
            panel2.Controls.Add(checkBoxIncludeHidden);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 326);
            panel2.Name = "panel2";
            panel2.Size = new Size(992, 241);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(906, 40);
            label1.TabIndex = 5;
            label1.Text = "\r\nFolder Order Matters because the top-most folder is scanned first, and duplicates found later will be automatically checked for removal.";
            // 
            // buttonStartScan
            // 
            buttonStartScan.Location = new Point(32, 153);
            buttonStartScan.Name = "buttonStartScan";
            buttonStartScan.Size = new Size(179, 56);
            buttonStartScan.TabIndex = 4;
            buttonStartScan.Text = "Start Scan";
            buttonStartScan.Click += ButtonStartScan_Click;
            // 
            // labelWarning
            // 
            labelWarning.AutoSize = true;
            labelWarning.ForeColor = Color.Red;
            labelWarning.Location = new Point(3, 60);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new Size(390, 20);
            labelWarning.TabIndex = 3;
            labelWarning.Text = "Warning: Always back up your data before removing files!";
            // 
            // checkBoxIncludeHidden
            // 
            checkBoxIncludeHidden.Location = new Point(32, 99);
            checkBoxIncludeHidden.Name = "checkBoxIncludeHidden";
            checkBoxIncludeHidden.Size = new Size(586, 35);
            checkBoxIncludeHidden.TabIndex = 2;
            checkBoxIncludeHidden.Text = "Include hidden files";
            // 
            // tabPageProgress
            // 
            tabPageProgress.Controls.Add(progressBar);
            tabPageProgress.Controls.Add(labelProgressInfo);
            tabPageProgress.Location = new Point(4, 29);
            tabPageProgress.Name = "tabPageProgress";
            tabPageProgress.Size = new Size(992, 567);
            tabPageProgress.TabIndex = 1;
            tabPageProgress.Text = "Progress";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(8, 107);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(976, 78);
            progressBar.TabIndex = 0;
            // 
            // labelProgressInfo
            // 
            labelProgressInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelProgressInfo.AutoSize = true;
            labelProgressInfo.Location = new Point(8, 52);
            labelProgressInfo.Name = "labelProgressInfo";
            labelProgressInfo.Size = new Size(120, 20);
            labelProgressInfo.TabIndex = 1;
            labelProgressInfo.Text = "Waiting to scan...";
            // 
            // tabPageResults
            // 
            tabPageResults.Controls.Add(panel1);
            tabPageResults.Controls.Add(dataGridViewResults);
            tabPageResults.Location = new Point(4, 29);
            tabPageResults.Name = "tabPageResults";
            tabPageResults.Size = new Size(992, 567);
            tabPageResults.TabIndex = 2;
            tabPageResults.Text = "Results";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelTotalSpaceSaved);
            panel1.Controls.Add(buttonDeleteSelected);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 473);
            panel1.Name = "panel1";
            panel1.Size = new Size(992, 94);
            panel1.TabIndex = 3;
            // 
            // labelTotalSpaceSaved
            // 
            labelTotalSpaceSaved.AutoSize = true;
            labelTotalSpaceSaved.Location = new Point(401, 41);
            labelTotalSpaceSaved.Name = "labelTotalSpaceSaved";
            labelTotalSpaceSaved.Size = new Size(255, 20);
            labelTotalSpaceSaved.TabIndex = 2;
            labelTotalSpaceSaved.Text = "Total space that can be freed: 0 bytes";
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.Location = new Point(8, 28);
            buttonDeleteSelected.Name = "buttonDeleteSelected";
            buttonDeleteSelected.Size = new Size(328, 46);
            buttonDeleteSelected.TabIndex = 1;
            buttonDeleteSelected.Text = "Send Selected to Recycle Bin";
            buttonDeleteSelected.Click += ButtonDeleteSelected_Click;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AllowUserToResizeRows = false;
            dataGridViewResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewResults.ColumnHeadersHeight = 29;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { colSelect, colPath });
            dataGridViewResults.Dock = DockStyle.Fill;
            dataGridViewResults.Location = new Point(0, 0);
            dataGridViewResults.MultiSelect = false;
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(992, 567);
            dataGridViewResults.TabIndex = 0;
            // 
            // colSelect
            // 
            colSelect.HeaderText = "Select";
            colSelect.MinimumWidth = 6;
            colSelect.Name = "colSelect";
            colSelect.Resizable = DataGridViewTriState.False;
            colSelect.SortMode = DataGridViewColumnSortMode.Automatic;
            colSelect.ToolTipText = "The file that will be removed.";
            colSelect.Width = 55;
            // 
            // colPath
            // 
            colPath.HeaderText = "Path";
            colPath.MinimumWidth = 6;
            colPath.Name = "colPath";
            colPath.ReadOnly = true;
            colPath.Resizable = DataGridViewTriState.True;
            colPath.Width = 1000;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            // 
            // backgroundWorkerDelete
            // 
            backgroundWorkerDelete.WorkerReportsProgress = true;
            backgroundWorkerDelete.WorkerSupportsCancellation = true;
            backgroundWorkerDelete.DoWork += BackgroundWorkerDelete_DoWork;
            backgroundWorkerDelete.ProgressChanged += BackgroundWorkerDelete_ProgressChanged;
            backgroundWorkerDelete.RunWorkerCompleted += BackgroundWorkerDelete_RunWorkerCompleted;
            // 
            // MainForm
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Text = "Duplicate File Remover";
            tabControlMain.ResumeLayout(false);
            tabPageSelectFolders.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPageProgress.ResumeLayout(false);
            tabPageProgress.PerformLayout();
            tabPageResults.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // UI Controls
        private Button buttonSelectFolder;
        private Button buttonRemoveFolder;
        private Button buttonMoveUp;
        private Button buttonMoveDown;
        private Button buttonStartScan;
        private ListBox listBoxFolders;
        private Label labelWarning;
        private ProgressBar progressBar;
        private Label labelProgressInfo;
        private TabControl tabControlMain;
        private TabPage tabPageSelectFolders;
        private TabPage tabPageProgress;
        private TabPage tabPageResults;
        private DataGridView dataGridViewResults;
        private Button buttonDeleteSelected;
        private Label labelTotalSpaceSaved;
        // Use a BackgroundWorker to handle scanning on a separate thread
        private BackgroundWorker backgroundWorker;
        private CheckBox checkBoxIncludeHidden;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private BackgroundWorker backgroundWorkerDelete;
        private Label label1;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colPath;
    }
}
