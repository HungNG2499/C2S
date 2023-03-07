using System.Windows.Input;

namespace C2S.ViewModel
{
    public class BOBLogicielVM : BaseViewModel
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

        public event ActionHandlerFromViewModel ReturnToBOBMenuEvent;

        private ICommand _returnCommand = null;

        public ICommand ReturnBOBCommand
        {
            get
            {
                if (_returnCommand == null)
                {
                    _returnCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => ReturnToBOBMenuEvent?.Invoke()
                    );
                }
                return _returnCommand;
            }
        }
    }
}
