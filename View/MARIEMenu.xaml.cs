using C2S.ViewModel;
using System.Windows.Controls;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for MARIEMenu.xaml
    /// </summary>
    public partial class MARIEMenu : Page
    {
        public MARIEMenu(MARIEVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
