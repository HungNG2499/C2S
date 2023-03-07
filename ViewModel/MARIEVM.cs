using System.Windows.Input;

namespace C2S.ViewModel
{
    public class MARIEVM : BaseViewModel
    {
        private int _selectedIndex = 0;
        //public int Test = 1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

                OnPropertyChanged("MenuColor4");
            }
        }

        public string MenuColor4 => SelectedIndex == 4 ? "#ffffff" : "#fdee05";

        public event ActionHandlerFromViewModel ReturnToHomeEvent;

        private ICommand _returnCommand = null;

        public ICommand ReturnCommand
        {
            get
            {
                if (_returnCommand == null)
                {
                    _returnCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => ReturnToHomeEvent?.Invoke()
                    );
                }
                return _returnCommand;
            }
        }
    }
}
