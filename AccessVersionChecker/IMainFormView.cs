#region

using System.Collections.Generic;
using AccessVersionChecker.Model;

#endregion

namespace AccessVersionChecker
{
  public interface IMainFormView
  {
    List<int> CompatibilityVersions { set; }

    int CompatibilityVersion { get; }

    List<AccessFileInfo> Rows { get; }

    void SortOnCompatibility();

    void Add(AccessFileInfo info);

    void ClearRows();

    void RowDataChanged();

    void ProgressChanged(int progressPercentage);

    void DisableInput();

    void EnableInput();
  }
}