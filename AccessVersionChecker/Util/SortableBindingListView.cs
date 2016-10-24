#region

using System;
using System.ComponentModel;
using System.Linq;

#endregion

namespace AccessVersionChecker.Util
{
  internal class SortableBindingList<T> : BindingList<T>
  {
    protected override bool SupportsSortingCore
    {
      get { return true; }
    }

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
      if (prop.PropertyType.GetInterface("IComparable") == null) return;

      var modifier = direction == ListSortDirection.Ascending ? 1 : -1;

      var items = Items.ToList();

      items.Sort((a, b) =>
      {
        var aVal = prop.GetValue(a) as IComparable;
        var bVal = prop.GetValue(b) as IComparable;
        return aVal.CompareTo(bVal)*modifier;
      });

      Items.Clear();

      foreach (var i in items)
        Items.Add(i);
    }
  }
}