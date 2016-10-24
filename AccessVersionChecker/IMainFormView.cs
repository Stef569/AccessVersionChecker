#region

using System.Collections.Generic;
using AccessVersionChecker.Model;

#endregion

namespace AccessVersionChecker
{
  public interface IMainFormView
  {
    List<int> ComptabilityVersions { set; }

    int ComptabilityVersion { get; }

    List<AccessFileInfo> Rows { get; }

    void SortOnComptability();

    void Add(AccessFileInfo info);

    void ClearRows();

    void RowDataChanged();

    void ProgressChanged(int progressPercentage);

    void DisableInput();

    void EnableInput();
  }
}