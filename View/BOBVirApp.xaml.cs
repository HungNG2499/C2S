using C2S.ViewModel;
using System.Windows.Controls;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for BOBVirApp.xaml
    /// </summary>
    public partial class BOBVirApp : Page
    {
        public BOBVirApp(BOBVirAppVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
