using System.Windows.Input;

namespace C2S.ViewModel
{
    public class USAINVM : BaseViewModel
    {
        private int _selectedIndex = 0;
        //public int Test = 1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

                OnPropertyChanged("MenuColor2");
            }
        }

        public string MenuColor2 => SelectedIndex == 2 ? "#ffffff" : "#fdee05";

        public event ActionHandlerFromViewModel ReturnToHomeEvent;
        //public event ActionHandlerFromViewModel OpenVirtualApplicationEvent;
        //public event ActionHandlerFromViewModel OpenLogicielEvent;
        //public event ActionHandlerFromViewModel OpenCahierEvent;
        //public event ActionHandlerFromViewModel OpenTutorialEvent;

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
