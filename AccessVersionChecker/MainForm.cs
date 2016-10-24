#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AccessVersionChecker.Controller;
using AccessVersionChecker.Controller.Task;
using AccessVersionChecker.Model;
using AccessVersionChecker.Util;

#endregion

namespace AccessVersionChecker
{
  public partial class MainForm : Form, IMainFormView
  {
    private MainFormController _controller;

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      // Create datasource
      IBindingList accessDatabasesList = new SortableBindingList<AccessFileInfo>();
      BindingSource.DataSource = accessDatabasesList;

      // Data bind to the grid
      DatabasesGridView.AutoGenerateColumns = false;
      DatabasesGridView.DataSource = BindingSource;

      _controller = new MainFormController(this, new TaskContainer());
    }

    #region GRID

    private void DatabasesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex <= 0) return;
      if (DatabasesGridView.Columns[e.ColumnIndex].Name != "DbPathColumn") return;

      var cell = DatabasesGridView[e.ColumnIndex, e.RowIndex];
      var filePath = cell.Value.ToString();

      MainFormController.OpenLink(filePath);
    }

    #endregion

    #region VIEW

    public void SortOnComptability()
    {
      var column = UiUtil.GetColumnByName(DatabasesGridView, "ComptabilityColumn");
      DatabasesGridView.Sort(column, ListSortDirection.Ascending);
    }

    public void Add(AccessFileInfo info)
    {
      BindingSource.Add(info);
    }

    public List<int> ComptabilityVersions
    {
      set { ComptabilityVersionComboBox.DataSource = value; }
    }

    public void ClearRows()
    {
      BindingSource.Clear();
    }

    public void RowDataChanged()
    {
      BindingSource.ResetBindings(false);
    }

    public void ProgressChanged(int progressPercentage)
    {
      TaskProgressBar.SetProgressWithoutAnimation(progressPercentage);
    }

    public void DisableInput()
    {
      ToggleButtonState(false);
    }

    public void EnableInput()
    {
      ToggleButtonState(true);
    }

    private void ToggleButtonState(bool enableInput)
    {
      AddDatabaseButton.Enabled = enableInput;
      ClearGridButton.Enabled = enableInput;
      ComptabilityVersionComboBox.Enabled = enableInput;
      fileToolStripMenuItem.Enabled = enableInput;
      DatabasesGridView.Enabled = enableInput;
    }

    public List<AccessFileInfo> Rows
    {
      get { return BindingSource.List.Cast<AccessFileInfo>().ToList(); }
    }

    public int ComptabilityVersion
    {
      get
      {
        // Get the comptability version from the cbo
        var cbo = ComptabilityVersionComboBox;
        if (cbo.SelectedIndex == -1) return -1;
        return int.Parse(cbo.Items[cbo.SelectedIndex] + "");
      }
    }

    #endregion

    #region BUTTONS

    private void AddDatabaseButton_Click(object sender, EventArgs e)
    {
      AddDatabases();
    }

    private void btnClearGrid_Click(object sender, EventArgs e)
    {
      _controller.ClearRows();
    }

    private void CancelTaskButton_Click(object sender, EventArgs e)
    {
      _controller.CancelCurrentTask();
    }

    #endregion

    #region MENU

    private void addDatabasesMenuItem_Click(object sender, EventArgs e)
    {
      AddDatabases();
    }

    private void readDatabasesFromFileMenuItem_Click(object sender, EventArgs e)
    {
      ReadDatabasesFromFile();
    }

    private void exportToExcelMenuItem_Click(object sender, EventArgs e)
    {
      // Prompt for a path to save the CSV file to
      var fileName = UiUtil.SaveFileDialog("Access databases comptability report", "csv", @"*.csv|Excel", this);

      _controller.ExportToExcel(fileName);
    }

    #endregion

    private void AddDatabases()
    {
      // Add mdb access database files to the grid by selecting the files
      var fileNames = UiUtil.OpenMultiSelectFileDialog(@"Access DB|*.mdb", this);
      _controller.AddDatabases(fileNames);
    }

    private void ReadDatabasesFromFile()
    {
      // Add mdb access database files to the grid by reading a text file
      var fileName = UiUtil.OpenFileDialog(@"List of paths to Access Databases|*.txt", this);
      _controller.ReadFromTextFile(fileName);
    }
  }
}