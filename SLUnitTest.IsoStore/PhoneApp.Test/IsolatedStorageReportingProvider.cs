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
using Microsoft.Silverlight.Testing;
using Microsoft.Silverlight.Testing.Service;
using Microsoft.Silverlight.Testing.Harness;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Navigation;

namespace PhoneApp.Test
{
    public class IsolatedStorageReportingProvider : TestReportingProvider
    {
        public event EventHandler LogPublished;

        public IsolatedStorageReportingProvider(TestServiceProvider testService)
            : base(testService)
        {
        }

        public override void ReportFinalResult(Action<ServiceResult> callback, bool failure, int failures, int totalScenarios, string message)
        {
            base.ReportFinalResult(callback, failure, failures, totalScenarios, message);
        }

        public override void WriteLog(Action<ServiceResult> callback, string logName, string content)
        {
            // Write the log file in Isolated Storage
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            using (StreamWriter sw = new StreamWriter(isf.CreateFile(logName)))
            {
                sw.Write(content);
            }

            OnLogPublished();
        }

        protected void OnLogPublished()
        {
            EventHandler handler = LogPublished;
            if (handler != null) 
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
