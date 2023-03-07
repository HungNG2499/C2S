using C2S.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Web.WebView2.Core;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for BOBTutorial.xaml
    /// </summary>
    public partial class BOBTutorial : Page
    {
        private Button _activeButton;

        public BOBTutorial(BOBTutorialVM vm)
        {
            InitializeComponent();
            DataContext = vm; webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            webView.EnsureCoreWebView2Async();
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                Button1.Click += FirstButton_Click;
                Button2.Click += SecondButton_Click;
            }
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonStyle((Button)sender);
            webView.CoreWebView2.Navigate("C:\\Users\\User\\Desktop\\C2S-project-forked\\C2S-Forked\\Data\\Tutoriels\\Tutoriel utilisation du casque VR Bob beamon .pdf");
        }

        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonStyle((Button)sender);
            webView.CoreWebView2.Navigate("C:\\Users\\User\\Desktop\\C2S-project-forked\\C2S-Forked\\Data\\Tutoriels\\Tutoriel Application Bob Beamon.pdf");
        }

        private void UpdateButtonStyle(Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.FontWeight = FontWeights.Normal;
                _activeButton.Foreground = Brushes.White;
            }
            button.FontWeight = FontWeights.Bold;
            button.Foreground = (Brush)new BrushConverter().ConvertFromString("#3fa7ba");
            _activeButton = button;
        }
    }
}
