using System.Windows.Input;

namespace C2S.ViewModel
{
    public class BOBVM : BaseViewModel
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

        public event ActionHandlerFromViewModel ReturnToHomeEvent;
        public event ActionHandlerFromViewModel OpenVirtualApplicationEvent;
        public event ActionHandlerFromViewModel OpenLogicielEvent;
        public event ActionHandlerFromViewModel OpenCahierEvent;
        public event ActionHandlerFromViewModel OpenTutorialEvent;

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

        private ICommand _virtualappCommand = null;

        public ICommand VirtualAppCommand
        {
            get
            {
                if (_virtualappCommand == null)
                {
                    _virtualappCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenVirtualApplicationEvent?.Invoke()
                    );
                }
                return _virtualappCommand;
            }
        }

        private ICommand _softwareCommand = null;

        public ICommand SoftwareCommand
        {
            get
            {
                if (_softwareCommand == null)
                {
                    _softwareCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenLogicielEvent?.Invoke()
                    );
                }
                return _softwareCommand;
            }
        }

        private ICommand _notebookCommand = null;

        public ICommand NotebookCommand
        {
            get
            {
                if (_notebookCommand == null)
                {
                    _notebookCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenCahierEvent?.Invoke()
                    );
                }
                return _notebookCommand;
            }
        }

        private ICommand _tutorialCommand = null;

        public ICommand TutorialCommand
        {
            get
            {
                if (_tutorialCommand == null)
                {
                    _tutorialCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenTutorialEvent?.Invoke()
                    );
                }
                return _tutorialCommand;
            }
        }
    }
}
