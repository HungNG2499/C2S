using System;
using System.Windows;
using C2S.Application;

namespace C2S
{
    public partial class MainWindow : Window
    {
        private ApplicationBusinessLogic _schoolTrainingInterface = null;

        public MainWindow()
        {
            _schoolTrainingInterface = new ApplicationBusinessLogic();

            InitializeComponent();
        }

        private void WindowsLoaded(object sender, RoutedEventArgs e)
        {
            _schoolTrainingInterface.SetContentFrame(ContentFrame);
            _schoolTrainingInterface.OpenSplashScreen();
        }
    }
}
