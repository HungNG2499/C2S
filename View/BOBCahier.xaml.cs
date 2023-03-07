using C2S.ViewModel;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for BOBCahier.xaml
    /// </summary>
    public partial class BOBCahier : Page
    {
        public BOBCahier(BOBCahierVM vm)
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
                //webView.CoreWebView2.Navigate("https://cp2s.sciencesetsport.fr/cahiers-pedagogiques/");
                webView.CoreWebView2.Navigate("file:///C:/Users/User/Desktop/C2S-project-forked/C2S-Forked/Data/Cahiers/Cahier_Saut_Beamon.pdf");
                //webView.CoreWebView2.Navigate("https://online.flippingbook.com/view/340362873/"); 
            }
        }
    }
}
