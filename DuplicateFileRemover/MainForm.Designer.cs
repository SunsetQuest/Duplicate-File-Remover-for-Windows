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
            buttonSelectFolder = new Button();
            buttonRemoveFolder = new Button();
            buttonMoveUp = new Button();
            buttonMoveDown = new Button();
            listBoxFolders = new ListBox();
            panel2 = new Panel();
            buttonStartScan = new Button();
            labelWarning = new Label();
            checkBoxIncludeHidden = new CheckBox();
            tabPageScanProgress = new TabPage();
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
            panel3 = new Panel();
            tabControlMain.SuspendLayout();
            tabPageSelectFolders.SuspendLayout();
            panel2.SuspendLayout();
            tabPageScanProgress.SuspendLayout();
            tabPageResults.SuspendLayout();
            panel1.SuspendLayout();
            ((ISupportInitialize)dataGridViewResults).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageSelectFolders);
            tabControlMain.Controls.Add(tabPageScanProgress);
            tabControlMain.Controls.Add(tabPageResults);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(782, 552);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageSelectFolders
            // 
            tabPageSelectFolders.Controls.Add(listBoxFolders);
            tabPageSelectFolders.Controls.Add(panel3);
            tabPageSelectFolders.Controls.Add(panel2);
            tabPageSelectFolders.Location = new Point(4, 29);
            tabPageSelectFolders.Name = "tabPageSelectFolders";
            tabPageSelectFolders.Size = new Size(774, 519);
            tabPageSelectFolders.TabIndex = 0;
            tabPageSelectFolders.Text = "Select Folders";
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
            // buttonRemoveFolder
            // 
            buttonRemoveFolder.Location = new Point(3, 47);
            buttonRemoveFolder.Name = "buttonRemoveFolder";
            buttonRemoveFolder.Size = new Size(117, 48);
            buttonRemoveFolder.TabIndex = 1;
            buttonRemoveFolder.Text = "Remove Folder";
            buttonRemoveFolder.Click += ButtonRemoveFolder_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Font = new Font("Segoe UI", 18F);
            buttonMoveUp.Location = new Point(3, 101);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(117, 48);
            buttonMoveUp.TabIndex = 2;
            buttonMoveUp.Text = "↑";
            buttonMoveUp.Click += ButtonMoveUp_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Font = new Font("Segoe UI", 18F);
            buttonMoveDown.Location = new Point(3, 155);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(117, 48);
            buttonMoveDown.TabIndex = 3;
            buttonMoveDown.Text = "↓";
            buttonMoveDown.Click += ButtonMoveDown_Click;
            // 
            // listBoxFolders
            // 
            listBoxFolders.Dock = DockStyle.Fill;
            listBoxFolders.Location = new Point(0, 0);
            listBoxFolders.Name = "listBoxFolders";
            listBoxFolders.Size = new Size(649, 278);
            listBoxFolders.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonStartScan);
            panel2.Controls.Add(labelWarning);
            panel2.Controls.Add(checkBoxIncludeHidden);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 278);
            panel2.Name = "panel2";
            panel2.Size = new Size(774, 241);
            panel2.TabIndex = 5;
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
            labelWarning.ForeColor = Color.Red;
            labelWarning.Location = new Point(32, 99);
            labelWarning.Name = "labelWarning";
            labelWarning.Size = new Size(648, 23);
            labelWarning.TabIndex = 3;
            labelWarning.Text = "Warning: Always back up your data before removing files!";
            // 
            // checkBoxIncludeHidden
            // 
            checkBoxIncludeHidden.Location = new Point(32, 43);
            checkBoxIncludeHidden.Name = "checkBoxIncludeHidden";
            checkBoxIncludeHidden.Size = new Size(183, 24);
            checkBoxIncludeHidden.TabIndex = 2;
            checkBoxIncludeHidden.Text = "Include hidden files";
            // 
            // tabPageScanProgress
            // 
            tabPageScanProgress.Controls.Add(progressBar);
            tabPageScanProgress.Controls.Add(labelProgressInfo);
            tabPageScanProgress.Location = new Point(4, 29);
            tabPageScanProgress.Name = "tabPageScanProgress";
            tabPageScanProgress.Size = new Size(774, 519);
            tabPageScanProgress.TabIndex = 1;
            tabPageScanProgress.Text = "Scanning Progress";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(8, 83);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(758, 78);
            progressBar.TabIndex = 0;
            // 
            // labelProgressInfo
            // 
            labelProgressInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelProgressInfo.Location = new Point(8, 28);
            labelProgressInfo.Name = "labelProgressInfo";
            labelProgressInfo.Size = new Size(758, 23);
            labelProgressInfo.TabIndex = 1;
            labelProgressInfo.Text = "Waiting to scan...";
            // 
            // tabPageResults
            // 
            tabPageResults.Controls.Add(panel1);
            tabPageResults.Controls.Add(dataGridViewResults);
            tabPageResults.Location = new Point(4, 29);
            tabPageResults.Name = "tabPageResults";
            tabPageResults.Size = new Size(774, 519);
            tabPageResults.TabIndex = 2;
            tabPageResults.Text = "Results";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelTotalSpaceSaved);
            panel1.Controls.Add(buttonDeleteSelected);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 425);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 94);
            panel1.TabIndex = 3;
            // 
            // labelTotalSpaceSaved
            // 
            labelTotalSpaceSaved.Location = new Point(319, 41);
            labelTotalSpaceSaved.Name = "labelTotalSpaceSaved";
            labelTotalSpaceSaved.Size = new Size(331, 23);
            labelTotalSpaceSaved.TabIndex = 2;
            labelTotalSpaceSaved.Text = "Total space that can be freed: 0 bytes";
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.Location = new Point(8, 28);
            buttonDeleteSelected.Name = "buttonDeleteSelected";
            buttonDeleteSelected.Size = new Size(265, 46);
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
            dataGridViewResults.Size = new Size(774, 519);
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
            colSelect.Width = 50;
            // 
            // colPath
            // 
            colPath.HeaderText = "Path";
            colPath.MinimumWidth = 6;
            colPath.Name = "colPath";
            colPath.ReadOnly = true;
            colPath.Resizable = DataGridViewTriState.True;
            colPath.Width = 500;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonMoveDown);
            panel3.Controls.Add(buttonMoveUp);
            panel3.Controls.Add(buttonRemoveFolder);
            panel3.Controls.Add(buttonSelectFolder);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(649, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(125, 278);
            panel3.TabIndex = 6;
            // 
            // MainForm
            // 
            ClientSize = new Size(782, 552);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Text = "Duplicate File Remover";
            tabControlMain.ResumeLayout(false);
            tabPageSelectFolders.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPageScanProgress.ResumeLayout(false);
            tabPageResults.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((ISupportInitialize)dataGridViewResults).EndInit();
            panel3.ResumeLayout(false);
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
        private TabPage tabPageScanProgress;
        private TabPage tabPageResults;
        private DataGridView dataGridViewResults;
        private Button buttonDeleteSelected;
        private Label labelTotalSpaceSaved;
        // Use a BackgroundWorker to handle scanning on a separate thread
        private BackgroundWorker backgroundWorker;
        private CheckBox checkBoxIncludeHidden;
        private Panel panel2;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colPath;
        private Panel panel1;
        private Panel panel3;
    }
}
