using C2S.ViewModel;
using System.Windows.Controls;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for DEMENYMenu.xaml
    /// </summary>
    public partial class DEMENYMenu : Page
    {
        public DEMENYMenu(DEMENYVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
