using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataBaseBroker;

namespace Aplikacija.LogIn
{
    public class LogInViewModel : ContainerViewModelBase, ILogInViewModel
    {
        #region Fields
        private RelayCommand _logIn;
        private RelayCommand _quit;

        private string _firstName;
        private string _password;
        private User _user;

        public User User
        {
            get { return _user = Broker.Instance.LogInSuccessful(_firstName, _password); }
            set { _user = value; }
        }

        #endregion

        #region Properties
        public RelayCommand LogInCommand => _logIn;
        public RelayCommand QuitCommand => _quit;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value.ToUpper();
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value.ToUpper(); }
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler<UserEventArgs> Succeeded;
        //public event EventHandler<UserEventArgs> UserEvent;
        #endregion

        #region Constructors
        public LogInViewModel()
        {
            _logIn = new RelayCommand(executeLogInCommand);
            _quit = new RelayCommand(executeQuitCommand);
        }

        #endregion

        #region Methods
        private void executeLogInCommand()
        {
            _user = Broker.Instance.LogInSuccessful(_firstName, _password);
            if (_user != null)
            {
                Succeeded?.Invoke(this, new UserEventArgs(_user));
                ResetToDefault();
            }
        }

        private void executeQuitCommand()
        {
            App.Current.Shutdown();
        }

        private void ResetToDefault()
        {
            _firstName = string.Empty;
            _password = string.Empty;
        }
        public void Start()
        {
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
