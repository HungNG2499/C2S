using System.Windows.Input;

namespace C2S.ViewModel
{
    public class BOBVirAppVM : BaseViewModel
    {
        private int _selectedIndex = 0;
        //public int Test = 1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

                OnPropertyChanged("MenuColor1");
            }
        }

        public string MenuColor1 => SelectedIndex == 1 ? "#ffffff" : "#fdee05";

        public event ActionHandlerFromViewModel ExitApplicationEvent;

        private ICommand _exitApplicationCommand = null;

        public ICommand ExitApplicationCommand
        {
            get
            {
                if (_exitApplicationCommand == null)
                {
                    _exitApplicationCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => ExitApplicationEvent?.Invoke()
                    );
                }
                return _exitApplicationCommand;
            }
        }
    }
}
