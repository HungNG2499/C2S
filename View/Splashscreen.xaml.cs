using System.Windows.Controls;
using C2S.ViewModel;

namespace C2S.View
{
    public partial class Splashscreen : Page
    {
        public Splashscreen(SplashScreenVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
