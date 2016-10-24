#region

using System;
using AccessVersionChecker.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace UnitTest
{
  [TestClass]
  public class AccessFileInfoTests
  {
    [TestMethod]
    public void TestEqual()
    {
      var a = new AccessFileInfo(@"c:\test.mdb", "2.0", AccessFileFormat.Acc2, false, "me", DateTime.Now, DateTime.Now);
      var b = new AccessFileInfo(@"c:\test.mdb", "8.0", AccessFileFormat.Acc2000_2003, true, "me", DateTime.Now,
        DateTime.Now);

      Assert.AreEqual(a, b);
    }

    [TestMethod]
    public void TestNotEqual()
    {
      var a = new AccessFileInfo(@"c:\test.mdb", "2.0", AccessFileFormat.Acc2, false, "me", DateTime.Now, DateTime.Now);
      var b = new AccessFileInfo(@"D:\anotherFile.mdb", "2.0", AccessFileFormat.Acc2, false, "me", DateTime.Now,
        DateTime.Now);

      Assert.AreNotEqual(a, b);
    }
  }
}