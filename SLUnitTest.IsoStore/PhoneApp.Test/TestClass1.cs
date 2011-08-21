using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Silverlight.Testing;
using System.IO.IsolatedStorage;
using System.IO;
using System.Diagnostics;

namespace PhoneApp.Test
{
    [TestClass]
    public class TestClass1 : SilverlightTest
    {
        [TestMethod]
        [Description("Method fails intentionally")]
        public void TestMethod1()
        {
            Assert.AreEqual(5, 6);
        }

        [TestMethod]
        [Description("Method passes intentionally")]
        public void TestMethod2()
        {
            Assert.AreEqual(6, 6);
        }
    }
}
