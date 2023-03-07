using C2S.ViewModel;
using System.Windows.Controls;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for USAINMenu.xaml
    /// </summary>
    public partial class USAINMenu : Page
    {
        public USAINMenu(USAINVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
