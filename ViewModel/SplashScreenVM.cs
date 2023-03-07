using System.Windows.Input;

namespace C2S.ViewModel
{
    public class SplashScreenVM : BaseViewModel
    {
        private string _applicationVersionNumber = "DEBUG";
        public string ApplicationVersionNumber
        {
            get => _applicationVersionNumber;
            set
            {
                _applicationVersionNumber = value;
                OnPropertyChanged();
            }
        }

        private string _applicationLicenseMessage = string.Empty;
        public string ApplicationLicenseMessage
        {
            get => _applicationLicenseMessage;
            set
            {
                _applicationLicenseMessage = value;
                OnPropertyChanged();
            }
        }

        private string _applicationLicenseMessageColor = "#84ff00";
        public string ApplicationLicenseMessageColor
        {
            get => _applicationLicenseMessageColor;
            set
            {
                _applicationLicenseMessageColor = value;
                OnPropertyChanged();
            }
        }

        private System.Windows.Visibility _applicationOptionVisibility = System.Windows.Visibility.Hidden;
        public System.Windows.Visibility ApplicationOptionVisibility
        {
            get => _applicationOptionVisibility;
            set
            {
                _applicationOptionVisibility = value;
                OnPropertyChanged();
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
                        param => System.Diagnostics.Process.Start("https://cp2s.sciencesetsport.fr/contact/")
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
    }
}
