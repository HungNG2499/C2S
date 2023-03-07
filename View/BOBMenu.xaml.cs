using C2S.ViewModel;
using System.Windows.Controls;

namespace C2S.View
{
    /// <summary>
    /// Interaction logic for BOBMenu.xaml
    /// </summary>
    public partial class BOBMenu : Page
    {
        public BOBMenu(BOBVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
