using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Silverlight.Testing;
using Microsoft.Phone.Shell;
using Microsoft.Silverlight.Testing.Harness;
using Microsoft.Silverlight.Testing.Client;

namespace PhoneApp.Test
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        protected void MainPage_Loaded(object sender, EventArgs e)
        {
            SystemTray.IsVisible = false;

            var testPage = UnitTestSystem.CreateTestPage() as IMobileTestPage;
            BackKeyPress += (x, xe) => xe.Cancel = testPage.NavigateBack();
            
            // Set custom log writer
            IsolatedStorageReportingProvider isoLog = new IsolatedStorageReportingProvider(((MobileTestPage)testPage).UnitTestHarness.Settings.TestService);
            ((MobileTestPage)testPage).UnitTestHarness.Settings.TestService.RegisterService(Microsoft.Silverlight.Testing.Service.TestServiceFeature.TestReporting,
                isoLog);

            // Uncomment this to automatically terminate the test application after test is complete!
            //isoLog.LogPublished += new EventHandler(this.OnTestHarnessCompleted);
            
            (Application.Current.RootVisual as PhoneApplicationFrame).Content = testPage;
        }

        private void OnTestHarnessCompleted(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}