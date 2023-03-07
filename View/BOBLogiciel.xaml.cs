using C2S.ViewModel;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for BOBLogiciel.xaml
    /// </summary>
    public partial class BOBLogiciel : Page
    {
        public BOBLogiciel(BOBLogicielVM vm)
        {
            InitializeComponent();
            DataContext = vm;
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            webView.EnsureCoreWebView2Async();
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                //edit to test GitHub
                webView.CoreWebView2.Navigate("https://cp2s.sciencesetsport.fr/cahiers-pedagogiques/");              
            }
        }
    }
}
