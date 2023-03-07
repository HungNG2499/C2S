using System;
using System.Windows;
using System.Windows.Threading;

namespace C2S
{
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += Application_DispatcherUnhandledException;
        }

        private void Application_DispatcherUnhandledException(object sender,
                           DispatcherUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled Exception: " + e.Exception.Message);
            MessageBox.Show(e.Exception.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
