using System;
using System.IO;
using System.Timers;
using System.Windows.Controls;
using C2S.ViewModel;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Navigation;

namespace C2S.Application
{

    public class ApplicationBusinessLogic
    {
        private readonly DateTime MAX_APPLICATION_VALIDITY = new DateTime(2030, 12, 26);

#if DEBUG
        private readonly string APPLICATION_PATH = Directory.GetParent(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.FullName;
#else
        private readonly string APPLICATION_PATH = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
#endif

        private Frame _contentFrame;

        public ApplicationBusinessLogic()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            _splashScreen = new SplashScreenVM();
            _splashScreen.ApplicationVersionNumber = fvi.FileVersion;

            // TODO Check application validity

            if (DateTime.Now <= MAX_APPLICATION_VALIDITY)
            {
                TimeSpan Difference = MAX_APPLICATION_VALIDITY - DateTime.Now;
                _splashScreen.ApplicationLicenseMessage = "La license est valide jusqu'au " + MAX_APPLICATION_VALIDITY.ToString("dd/MM/yyyy")
                    + " (" + Difference.Days + " jours restant)";
                _splashScreen.ApplicationLicenseMessageColor = "#84ff00";
                _splashScreen.ApplicationOptionVisibility = System.Windows.Visibility.Hidden;

                // We wait for 5 second in the splashscreen then we open the Home page
                var splashScreenTimer = new Timer();

                splashScreenTimer.Elapsed += delegate (object source, ElapsedEventArgs e)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(OpenHomePage);
                };

                splashScreenTimer.Interval = 5000;
                splashScreenTimer.AutoReset = false;
                splashScreenTimer.Start();
            }
            else
            {
                _splashScreen.ApplicationLicenseMessage = "La license n'est plus valide, merci de nous contacter pour renouvellement.";
                _splashScreen.ApplicationLicenseMessageColor = "#ff0000";
                _splashScreen.ApplicationOptionVisibility = System.Windows.Visibility.Visible;
            }
        }

        public void SetContentFrame(Frame contentFrame)
        {
            _contentFrame = contentFrame;
        }

        private View.Accueil _accueilPage = null;
        
        //BOBMenu
        private View.BOBMenu _BOBPage = null;
        private View.BOBVirApp _BOBVirAppPage = null;
        private View.BOBLogiciel _BOBLogicielPage = null;
        private View.BOBCahier _BOBCahierPage = null;
        private View.BOBTutorial _BOBTutorialPage = null;
        private Process _externalProcess;
        
        //USAINMenu
        private View.USAINMenu _USAINPage = null;

        //DEMENYMenu
        private View.DEMENYMenu _DEMENYPage = null;

        //MARIEMenu
        private View.MARIEMenu _MARIEPage = null;

        private SplashScreenVM _splashScreen = null;
        private HomeVM _accueil = null;
        
        //BOBMenu
        private BOBVM _BOB = null;
        private BOBVirAppVM _BOBVirApp = null;
        private BOBLogicielVM _BOBLogiciel = null;
        private BOBCahierVM _BOBCahier = null;
        private BOBTutorialVM _BOBTutorial = null;
        
        //USAINMenu
        private USAINVM _USAIN = null;

        //DEMENYMenu
        private DEMENYVM _DEMENY = null;

        //MARIEMenu
        private MARIEVM _MARIE = null;

        public void OpenSplashScreen()
        {
            _contentFrame.NavigationService.Navigate(new View.Splashscreen(_splashScreen));
        }
        
        public void OpenHomePage()
        {
            if (_accueilPage == null)
            {
                _accueil = new HomeVM();

                _accueil.OpenMenu1Event += OpenBOBMenu;

                _accueil.OpenMenu2Event += OpenUSAINMenu;

                _accueil.OpenMenu3Event += OpenDEMENYMenu;

                _accueil.OpenMenu4Event += OpenMARIEMenu;

                _accueilPage = new View.Accueil(_accueil);
            }

            _contentFrame.NavigationService.Navigate(_accueilPage);
        }

        public void OpenBOBMenu()
        {
            if (_BOBPage == null)
            {
                _BOB = new BOBVM();

                _BOB.ReturnToHomeEvent += OpenHomePage;

                _BOB.OpenVirtualApplicationEvent += OpenBOBVirApp;

                _BOB.OpenLogicielEvent += OpenBOBLogiciel;

                _BOB.OpenCahierEvent += OpenBOBCahier;

                _BOB.OpenTutorialEvent += OpenBOBTutorial;

                _BOBPage = new View.BOBMenu(_BOB);
            }

            _contentFrame.NavigationService.Navigate(_BOBPage);
        }

        public void OpenBOBVirApp()
        {
            string externalApplicationPath = "C:\\Users\\User\\Desktop\\C2S-project-forked\\C2S-Forked\\Data" +
                "\\Applications\\App-Sautdusiecle\\TP Analyse du saut en longueur v02.1.exe";
            OpenExternalApp(externalApplicationPath);

            if (_BOBVirAppPage == null)
            {
                _BOBVirApp = new BOBVirAppVM();

                _BOBVirApp.ExitApplicationEvent += ExitExternalApp;

                _BOBVirAppPage = new View.BOBVirApp(_BOBVirApp);
            }

            _contentFrame.NavigationService.Navigate(_BOBVirAppPage);
        }

        public void OpenBOBLogiciel()
        {
            if (_BOBLogicielPage == null)
            {
                _BOBLogiciel = new BOBLogicielVM();

                _BOBLogiciel.ReturnToBOBMenuEvent += OpenBOBMenu;

                _BOBLogicielPage = new View.BOBLogiciel(_BOBLogiciel);
            }

            _contentFrame.NavigationService.Navigate(_BOBLogicielPage);
        }

        public void OpenBOBCahier()
        {
            if (_BOBCahierPage == null)
            {
                _BOBCahier = new BOBCahierVM();

                _BOBCahier.ReturnToBOBMenuEvent += OpenBOBMenu;

                _BOBCahierPage = new View.BOBCahier(_BOBCahier);
            }

            _contentFrame.NavigationService.Navigate(_BOBCahierPage);
        }

        public void OpenBOBTutorial()
        {
            if (_BOBTutorialPage == null)
            {
                _BOBTutorial = new BOBTutorialVM();

                _BOBTutorial.ReturnToBOBMenuEvent += OpenBOBMenu;

                _BOBTutorialPage = new View.BOBTutorial(_BOBTutorial);
            }

            _contentFrame.NavigationService.Navigate(_BOBTutorialPage);
        }

        public void OpenExternalApp(string externalApplicationPath)
        {
            _externalProcess = new Process();
            _externalProcess.StartInfo.FileName = externalApplicationPath;
            _externalProcess.EnableRaisingEvents = true;
            _externalProcess.Start();

            _externalProcess.Exited += (sender, e) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    _contentFrame.NavigationService.Navigate(_BOBPage);
                });
            };
        }

        public void ExitExternalApp()
        {
            if (_externalProcess != null && !_externalProcess.HasExited)
            {
                _externalProcess.Kill();
            }
        }

        public void OpenUSAINMenu()
        {
            if (_USAINPage == null)
            {
                _USAIN = new USAINVM();

                _USAIN.ReturnToHomeEvent += OpenHomePage;

                //_BOB.OpenVirtualApplicationEvent += OpenBOBVirApp;

                //_BOB.OpenLogicielEvent += OpenBOBLogiciel;

                //_USAIN.OpenCahierEvent += OpenUSAINCahier;

                //_BOB.OpenTutorialEvent += OpenBOBTutorial;

                _USAINPage = new View.USAINMenu(_USAIN);
            }

            _contentFrame.NavigationService.Navigate(_USAINPage);
        }

        public void OpenDEMENYMenu()
        {
            if (_DEMENYPage == null)
            {
                _DEMENY = new DEMENYVM();

                _DEMENY.ReturnToHomeEvent += OpenHomePage;

                //_BOB.OpenVirtualApplicationEvent += OpenBOBVirApp;

                //_BOB.OpenLogicielEvent += OpenBOBLogiciel;

                //_BOB.OpenCahierEvent += OpenBOBCahier;

                //_BOB.OpenTutorialEvent += OpenBOBTutorial;

                _DEMENYPage = new View.DEMENYMenu(_DEMENY);
            }

            _contentFrame.NavigationService.Navigate(_DEMENYPage);
        }

        public void OpenMARIEMenu()
        {
            if (_MARIEPage == null)
            {
                _MARIE = new MARIEVM();

                _MARIE.ReturnToHomeEvent += OpenHomePage;

                //_BOB.OpenVirtualApplicationEvent += OpenBOBVirApp;

                //_BOB.OpenLogicielEvent += OpenBOBLogiciel;

                //_BOB.OpenCahierEvent += OpenBOBCahier;

                //_BOB.OpenTutorialEvent += OpenBOBTutorial;

                _MARIEPage = new View.MARIEMenu(_MARIE);
            }

            _contentFrame.NavigationService.Navigate(_MARIEPage);
        }
    }
}
