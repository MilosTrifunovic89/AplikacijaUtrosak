using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using Domain;
using System;

namespace Aplikacija.Home
{
    public enum HomeViewModelResultType
    {
        RequestTable,
        RequestCorpus
    }

    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        #region Fields
        private HomeViewModelResultType? _result;
        private User _user;

        private RelayCommand _requestTable;
        private RelayCommand _requestCorpus;
        private RelayCommand _logOut;
        private RelayCommand _quit;
        private RelayCommand _customer;
        #endregion

        #region Properties
        public HomeViewModelResultType? Result => _result;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public RelayCommand RequestTableCommand => _requestTable;
        public RelayCommand RequestCorpusCommand => _requestCorpus;
        public RelayCommand LogOutCommand => _logOut;
        public RelayCommand QuitCommand => _quit;
        public RelayCommand CustomerCommand => _customer;
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler LogOut;
        public event EventHandler Customer;
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            _requestTable = new RelayCommand(executeRequestTableCommand);
            _requestCorpus = new RelayCommand(executeRequestCorpusCommand);
            _logOut = new RelayCommand(executeLogOutCommand);
            _quit = new RelayCommand(executeQutiCommand);
            _customer = new RelayCommand(executeCustomerCommand);
        }
        #endregion

        #region Methods
        private void executeCustomerCommand()
        {
            Customer?.Invoke(this, new EventArgs());
        }

        private void executeQutiCommand()
        {
            App.Current.Shutdown();
        }

        private void executeLogOutCommand()
        {
            LogOut?.Invoke(this, new EventArgs());
        }

        private void executeRequestTableCommand()
        {
            _result = HomeViewModelResultType.RequestTable;
            Succeeded?.Invoke(this, new EventArgs());
        }

        private void executeRequestCorpusCommand()
        {
            _result = HomeViewModelResultType.RequestCorpus;
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start(User user)
        {
            _user = user;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}