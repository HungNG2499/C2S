using System.Windows.Controls;
using C2S.ViewModel;

namespace C2S.View
{
    public partial class Accueil : Page
    {
        private HomeVM VM => DataContext as HomeVM;

        public Accueil(HomeVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
                scrollviewer.LineLeft();
            else
                scrollviewer.LineRight();
            e.Handled = true;
        }

        private void Button1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VM.SelectedIndex = 1;
        }

        private void Button1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (VM.SelectedIndex == 1)
            {
                VM.SelectedIndex = 0;
            }
        }

        private void Button2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VM.SelectedIndex = 2;
        }

        private void Button2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (VM.SelectedIndex == 2)
            {
                VM.SelectedIndex = 0;
            }
        }

        private void Button3_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VM.SelectedIndex = 3;
        }

        private void Button3_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (VM.SelectedIndex == 3)
            {
                VM.SelectedIndex = 0;
            }
        }

        private void Button4_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            VM.SelectedIndex = 4;
        }

        private void Button4_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (VM.SelectedIndex == 4)
            {
                VM.SelectedIndex = 0;
            }
        }
    }
}
