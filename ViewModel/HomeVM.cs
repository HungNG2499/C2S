using System.Windows;
using System.Windows.Input;

namespace C2S.ViewModel
{
    public class HomeVM : BaseViewModel
    {
        // If 0, nothing is selected
        private int _selectedIndex = 0;
        public int Test = 1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

                OnPropertyChanged("SelectedMenu1");
                OnPropertyChanged("SelectedMenu2");
                OnPropertyChanged("SelectedMenu3");
                OnPropertyChanged("SelectedMenu4");

                OnPropertyChanged("UnselectedMenu1");
                OnPropertyChanged("UnselectedMenu2");
                OnPropertyChanged("UnselectedMenu3");
                OnPropertyChanged("UnselectedMenu4");

                OnPropertyChanged("MenuColor1");
                OnPropertyChanged("MenuColor2");
                OnPropertyChanged("MenuColor3");
                OnPropertyChanged("MenuColor4");
            }
        }


        public Visibility SelectedMenu1 => SelectedIndex == 1 ? Visibility.Hidden : Visibility.Visible;
        public Visibility SelectedMenu2 => SelectedIndex == 2 ? Visibility.Hidden : Visibility.Visible;
        public Visibility SelectedMenu3 => SelectedIndex == 3 ? Visibility.Hidden : Visibility.Visible;
        public Visibility SelectedMenu4 => SelectedIndex == 4 ? Visibility.Hidden : Visibility.Visible;

        public Visibility UnselectedMenu1 => SelectedIndex == 1 ? Visibility.Visible : Visibility.Hidden;
        public Visibility UnselectedMenu2 => SelectedIndex == 2 ? Visibility.Visible : Visibility.Hidden;
        public Visibility UnselectedMenu3 => SelectedIndex == 3 ? Visibility.Visible : Visibility.Hidden;
        public Visibility UnselectedMenu4 => SelectedIndex == 4 ? Visibility.Visible : Visibility.Hidden;

        public string MenuColor1 => SelectedIndex == 1 ? "#fdee05" : "#ffffff";
        public string MenuColor2 => SelectedIndex == 2 ? "#fdee05" : "#ffffff";
        public string MenuColor3 => SelectedIndex == 3 ? "#fdee05" : "#ffffff";
        public string MenuColor4 => SelectedIndex == 4 ? "#fdee05" : "#ffffff";


        public event ActionHandlerFromViewModel OpenTutorielsEvent;
        public event ActionHandlerFromViewModel OpenClassesEvent;
        public event ActionHandlerFromViewModel OpenContactEvent;

        private ICommand _siteCommand = null;
        private ICommand _tutorialsCommand = null;

        public ICommand SiteCommand
        {
            get
            {
                if (_siteCommand == null)
                {
                    _siteCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => System.Diagnostics.Process.Start("https://cp2s.sciencesetsport.fr/")
                    );
                }
                return _siteCommand;
            }
        }

        public ICommand TutorialsCommand
        {
            get
            {
                if (_tutorialsCommand == null)
                {
                    _tutorialsCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenTutorielsEvent?.Invoke()
                    );
                }
                return _tutorialsCommand;
            }
        }

        private ICommand _classesCommand = null;

        public ICommand ClassesCommand
        {
            get
            {
                if (_classesCommand == null)
                {
                    _classesCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenClassesEvent?.Invoke()
                    );
                }
                return _classesCommand;
            }
        }

        private ICommand _contactCommand = null;

        public ICommand ContactCommand
        {
            get
            {
                if (_contactCommand == null)
                {
                    _contactCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenContactEvent?.Invoke()
                    );
                }
                return _contactCommand;
            }
        }


        private ICommand _exitCommand = null;

        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => System.Windows.Application.Current.Shutdown()
                    );
                }
                return _exitCommand;
            }
        }

        private ICommand _menu1Command = null;
        private ICommand _menu2Command = null;
        private ICommand _menu3Command = null;
        private ICommand _menu4Command = null;

        public event ActionHandlerFromViewModel OpenMenu1Event;
        public event ActionHandlerFromViewModel OpenMenu2Event;
        public event ActionHandlerFromViewModel OpenMenu3Event;
        public event ActionHandlerFromViewModel OpenMenu4Event;

        public ICommand CommandMenu1
        {
            get
            {
                if (_menu1Command == null)
                {
                    _menu1Command = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenMenu1Event?.Invoke()
                    );
                }
                return _menu1Command;
            }
        }

        public ICommand CommandMenu2
        {
            get
            {
                if (_menu2Command == null)
                {
                    _menu2Command = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenMenu2Event?.Invoke()
                    );
                }
                return _menu2Command;
            }
        }

        public ICommand CommandMenu3
        {
            get
            {
                if (_menu3Command == null)
                {
                    _menu3Command = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenMenu3Event?.Invoke()
                    );
                }
                return _menu3Command;
            }
        }

        public ICommand CommandMenu4
        {
            get
            {
                if (_menu4Command == null)
                {
                    _menu4Command = new RelayCommand<object>(
                        param => ReturnTrue(),
                        param => OpenMenu4Event?.Invoke()
                    );
                }
                return _menu4Command;
            }
        }
    }
}
