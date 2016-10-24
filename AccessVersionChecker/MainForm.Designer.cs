namespace AccessVersionChecker {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.AddDatabaseButton = new System.Windows.Forms.Button();
      this.DatabasesGridView = new System.Windows.Forms.DataGridView();
      this.DbNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OwnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.VersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.AccessVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ComptabilityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreatedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LastModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DbPathColumn = new System.Windows.Forms.DataGridViewLinkColumn();
      this.HeaderLabel = new System.Windows.Forms.Label();
      this.VersionComptabilityLabel = new System.Windows.Forms.Label();
      this.ComptabilityVersionComboBox = new System.Windows.Forms.ComboBox();
      this.ClearGridButton = new System.Windows.Forms.Button();
      this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
      this.CancelTaskButton = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addDatabasesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.readDatabasesFromFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exportToExcelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.DatabasesGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(55, 35);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 0;
      // 
      // AddDatabaseButton
      // 
      this.AddDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.AddDatabaseButton.Location = new System.Drawing.Point(1038, 500);
      this.AddDatabaseButton.Name = "AddDatabaseButton";
      this.AddDatabaseButton.Size = new System.Drawing.Size(92, 23);
      this.AddDatabaseButton.TabIndex = 1;
      this.AddDatabaseButton.Text = "&Add Databases";
      this.AddDatabaseButton.UseVisualStyleBackColor = true;
      this.AddDatabaseButton.Click += new System.EventHandler(this.AddDatabaseButton_Click);
      // 
      // DatabasesGridView
      // 
      this.DatabasesGridView.AllowUserToAddRows = false;
      this.DatabasesGridView.AllowUserToDeleteRows = false;
      this.DatabasesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DatabasesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DatabasesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DbNameColumn,
            this.OwnerColumn,
            this.VersionColumn,
            this.AccessVersionColumn,
            this.ComptabilityColumn,
            this.CreatedColumn,
            this.LastModifiedColumn,
            this.DbPathColumn});
      this.DatabasesGridView.Location = new System.Drawing.Point(12, 79);
      this.DatabasesGridView.Name = "DatabasesGridView";
      this.DatabasesGridView.ReadOnly = true;
      this.DatabasesGridView.Size = new System.Drawing.Size(1122, 415);
      this.DatabasesGridView.TabIndex = 2;
      this.DatabasesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabasesDataGridView_CellContentClick);
      // 
      // DbNameColumn
      // 
      this.DbNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.DbNameColumn.DataPropertyName = "DbName";
      this.DbNameColumn.HeaderText = "Database name";
      this.DbNameColumn.MinimumWidth = 100;
      this.DbNameColumn.Name = "DbNameColumn";
      this.DbNameColumn.ReadOnly = true;
      // 
      // OwnerColumn
      // 
      this.OwnerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.OwnerColumn.DataPropertyName = "Owner";
      this.OwnerColumn.HeaderText = "Owner";
      this.OwnerColumn.Name = "OwnerColumn";
      this.OwnerColumn.ReadOnly = true;
      this.OwnerColumn.Width = 63;
      // 
      // VersionColumn
      // 
      this.VersionColumn.DataPropertyName = "Version";
      this.VersionColumn.HeaderText = "Version";
      this.VersionColumn.Name = "VersionColumn";
      this.VersionColumn.ReadOnly = true;
      this.VersionColumn.Width = 70;
      // 
      // AccessVersionColumn
      // 
      this.AccessVersionColumn.DataPropertyName = "AccessFileFormat";
      this.AccessVersionColumn.HeaderText = "File Format";
      this.AccessVersionColumn.Name = "AccessVersionColumn";
      this.AccessVersionColumn.ReadOnly = true;
      this.AccessVersionColumn.Width = 85;
      // 
      // ComptabilityColumn
      // 
      this.ComptabilityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.ComptabilityColumn.DataPropertyName = "Compatible";
      this.ComptabilityColumn.HeaderText = "Comptability";
      this.ComptabilityColumn.Name = "ComptabilityColumn";
      this.ComptabilityColumn.ReadOnly = true;
      this.ComptabilityColumn.Width = 88;
      // 
      // CreatedColumn
      // 
      this.CreatedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.CreatedColumn.DataPropertyName = "Created";
      this.CreatedColumn.HeaderText = "Created";
      this.CreatedColumn.Name = "CreatedColumn";
      this.CreatedColumn.ReadOnly = true;
      this.CreatedColumn.Width = 69;
      // 
      // LastModifiedColumn
      // 
      this.LastModifiedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.LastModifiedColumn.DataPropertyName = "LastModified";
      this.LastModifiedColumn.HeaderText = "Last Modified";
      this.LastModifiedColumn.Name = "LastModifiedColumn";
      this.LastModifiedColumn.ReadOnly = true;
      this.LastModifiedColumn.Width = 87;
      // 
      // DbPathColumn
      // 
      this.DbPathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DbPathColumn.DataPropertyName = "DbPath";
      this.DbPathColumn.HeaderText = "Path";
      this.DbPathColumn.Name = "DbPathColumn";
      this.DbPathColumn.ReadOnly = true;
      this.DbPathColumn.ToolTipText = "Open the access database";
      // 
      // HeaderLabel
      // 
      this.HeaderLabel.AutoSize = true;
      this.HeaderLabel.Location = new System.Drawing.Point(12, 33);
      this.HeaderLabel.Name = "HeaderLabel";
      this.HeaderLabel.Size = new System.Drawing.Size(655, 13);
      this.HeaderLabel.TabIndex = 3;
      this.HeaderLabel.Text = "This tool allows to check the version and compatibility of a list of access datab" +
    "ases. If the database is not compatible the file will not open!";
      // 
      // VersionComptabilityLabel
      // 
      this.VersionComptabilityLabel.AutoSize = true;
      this.VersionComptabilityLabel.Location = new System.Drawing.Point(12, 57);
      this.VersionComptabilityLabel.Name = "VersionComptabilityLabel";
      this.VersionComptabilityLabel.Size = new System.Drawing.Size(136, 13);
      this.VersionComptabilityLabel.TabIndex = 4;
      this.VersionComptabilityLabel.Text = "Version comptability check:";
      // 
      // ComptabilityVersionComboBox
      // 
      this.ComptabilityVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComptabilityVersionComboBox.FormattingEnabled = true;
      this.ComptabilityVersionComboBox.Location = new System.Drawing.Point(154, 54);
      this.ComptabilityVersionComboBox.Name = "ComptabilityVersionComboBox";
      this.ComptabilityVersionComboBox.Size = new System.Drawing.Size(73, 21);
      this.ComptabilityVersionComboBox.TabIndex = 5;
      // 
      // ClearGridButton
      // 
      this.ClearGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearGridButton.Location = new System.Drawing.Point(993, 52);
      this.ClearGridButton.Name = "ClearGridButton";
      this.ClearGridButton.Size = new System.Drawing.Size(137, 23);
      this.ClearGridButton.TabIndex = 9;
      this.ClearGridButton.Text = "Clear &list of databases";
      this.ClearGridButton.UseVisualStyleBackColor = true;
      this.ClearGridButton.Click += new System.EventHandler(this.btnClearGrid_Click);
      // 
      // TaskProgressBar
      // 
      this.TaskProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.TaskProgressBar.Location = new System.Drawing.Point(12, 500);
      this.TaskProgressBar.Name = "TaskProgressBar";
      this.TaskProgressBar.Size = new System.Drawing.Size(136, 23);
      this.TaskProgressBar.TabIndex = 10;
      // 
      // CancelTaskButton
      // 
      this.CancelTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CancelTaskButton.Location = new System.Drawing.Point(154, 500);
      this.CancelTaskButton.Name = "CancelTaskButton";
      this.CancelTaskButton.Size = new System.Drawing.Size(77, 23);
      this.CancelTaskButton.TabIndex = 11;
      this.CancelTaskButton.Text = "&Cancel task";
      this.CancelTaskButton.UseVisualStyleBackColor = true;
      this.CancelTaskButton.Click += new System.EventHandler(this.CancelTaskButton_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1134, 24);
      this.menuStrip1.TabIndex = 12;
      this.menuStrip1.Text = "mainMenu";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDatabasesMenuItem,
            this.readDatabasesFromFileMenuItem,
            this.exportToExcelMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // addDatabasesMenuItem
      // 
      this.addDatabasesMenuItem.Name = "addDatabasesMenuItem";
      this.addDatabasesMenuItem.Size = new System.Drawing.Size(230, 22);
      this.addDatabasesMenuItem.Text = "&Add databases";
      this.addDatabasesMenuItem.Click += new System.EventHandler(this.addDatabasesMenuItem_Click);
      // 
      // readDatabasesFromFileMenuItem
      // 
      this.readDatabasesFromFileMenuItem.Name = "readDatabasesFromFileMenuItem";
      this.readDatabasesFromFileMenuItem.Size = new System.Drawing.Size(230, 22);
      this.readDatabasesFromFileMenuItem.Text = "&Read database paths from file";
      this.readDatabasesFromFileMenuItem.Click += new System.EventHandler(this.readDatabasesFromFileMenuItem_Click);
      // 
      // exportToExcelMenuItem
      // 
      this.exportToExcelMenuItem.Name = "exportToExcelMenuItem";
      this.exportToExcelMenuItem.Size = new System.Drawing.Size(230, 22);
      this.exportToExcelMenuItem.Text = "&Export to excel";
      this.exportToExcelMenuItem.Click += new System.EventHandler(this.exportToExcelMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1134, 531);
      this.Controls.Add(this.CancelTaskButton);
      this.Controls.Add(this.TaskProgressBar);
      this.Controls.Add(this.ClearGridButton);
      this.Controls.Add(this.ComptabilityVersionComboBox);
      this.Controls.Add(this.VersionComptabilityLabel);
      this.Controls.Add(this.HeaderLabel);
      this.Controls.Add(this.DatabasesGridView);
      this.Controls.Add(this.AddDatabaseButton);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "Access Version Checker";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DatabasesGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button AddDatabaseButton;
    private System.Windows.Forms.DataGridView DatabasesGridView;
    private System.Windows.Forms.Label HeaderLabel;
    private System.Windows.Forms.Label VersionComptabilityLabel;
    private System.Windows.Forms.ComboBox ComptabilityVersionComboBox;
    private System.Windows.Forms.Button ClearGridButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn DbNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn OwnerColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn VersionColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn AccessVersionColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ComptabilityColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreatedColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn LastModifiedColumn;
    private System.Windows.Forms.DataGridViewLinkColumn DbPathColumn;
    private System.Windows.Forms.BindingSource BindingSource;
    private System.Windows.Forms.ProgressBar TaskProgressBar;
    private System.Windows.Forms.Button CancelTaskButton;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addDatabasesMenuItem;
    private System.Windows.Forms.ToolStripMenuItem readDatabasesFromFileMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportToExcelMenuItem;
  }
}

