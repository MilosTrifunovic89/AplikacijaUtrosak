using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain;
using Domain.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.Offer.Customer
{
    class CustomerViewModel : ContainerViewModelBase, ICustomerViewModel
    {
        #region Fields
        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _loadAllCivilCustomers;
        private RelayCommand _loadAllPublicCustomers;
        private RelayCommand _createCustomer;
        private RelayCommand _civilVisibility;
        private RelayCommand _publicVisibility;
        private RelayCommand _createOffer;
        #endregion
        private User _user;
        private ObservableCollection<CustomerClass> _allCustomers;
        private CivilCustomer _selectedCivilCustomer;
        private PublicCustomer _selectedPublicCustomer;
        private CivilCustomer _civilCustomer;
        private PublicCustomer _publicCustomer;
        #region CivilCustomerFields
        private long _id;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _idNumber;
        #endregion
        #region CompanyCustomerFields
        private string _companyName;
        private string _companyAddress;
        private string _pib;
        private string _companyIDnumber;
        #endregion
        #region VisibleFields
        private bool _visibilityCustomerCivil;
        private bool _visibilityCustomerCompany;
        private bool _loadAllCivil;
        private bool _loadAllPublic;
        private bool _visibilityCivilCustomerCreate;
        private bool _visibilityPublicCustomerCreate;
        private bool _isSelected;
        #endregion
        #region EnabledFields
        private bool _searchCustomer;
        private bool _create;
        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand LoadAllCivilCustomersCommand => _loadAllCivilCustomers;
        public RelayCommand LoadAllPublicCustomersCommand => _loadAllPublicCustomers;
        public RelayCommand CreateCustomerCommand => _createCustomer;
        public RelayCommand CivilVisibilityCommand => _civilVisibility;
        public RelayCommand PublicVisibilityCommand => _publicVisibility;
        public RelayCommand CreateOfferCommand => _createOffer;
        #endregion
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public CivilCustomer CivilCustomer
        {
            get { return _civilCustomer; }
            set { _civilCustomer = value; }
        }
        public PublicCustomer PublicCustomer
        {
            get { return _publicCustomer; }
            set { _publicCustomer = value; }
        }
        public ObservableCollection<CustomerClass> AllCustomers
        {
            get { return _allCustomers; }
            set
            {
                if (_allCustomers != value)
                {
                    _allCustomers = value;
                    OnPropertyChanged(nameof(AllCustomers));
                }
            }
        }
        public PublicCustomer SelectedPublicCustomer
        {
            get { return _selectedPublicCustomer; }
            set
            {
                if (_selectedPublicCustomer != value)
                {
                    _selectedPublicCustomer = value;
                    if (_selectedPublicCustomer != null)
                    {
                        SelectedCivilCustomer = null;
                        IsSelected = true;
                    }
                    OnPropertyChanged(nameof(SelectedPublicCustomer));
                }
            }
        }
        public CivilCustomer SelectedCivilCustomer
        {
            get { return _selectedCivilCustomer; }
            set
            {
                if (_selectedCivilCustomer != value)
                {
                    _selectedCivilCustomer = value;
                    if (_selectedCivilCustomer != null)
                    {
                        SelectedPublicCustomer = null;
                        IsSelected = true;
                    }
                    OnPropertyChanged(nameof(SelectedCivilCustomer));
                }
            }
        }
        #region CivilCustomerProperties
        public string IDnumber
        {
            get { return _idNumber; }
            set
            {
                if (_idNumber != value)
                {
                    _idNumber = value;
                    OnPropertyChanged(nameof(IDnumber));
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public long ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        #endregion
        #region CompanyCustomerProperties
        public string CompanyIDnumber
        {
            get { return _companyIDnumber; }
            set
            {
                if (_companyIDnumber != value)
                {
                    _companyIDnumber = value;
                    OnPropertyChanged(nameof(CompanyIDnumber));
                }
            }
        }
        public string PIB
        {
            get { return _pib; }
            set
            {
                if (_pib != value)
                {
                    _pib = value;
                    OnPropertyChanged(nameof(PIB));
                }
            }
        }
        public string CompanyAddress
        {
            get { return _companyAddress; }
            set
            {
                if (_companyAddress != value)
                {
                    _companyAddress = value;
                    OnPropertyChanged(nameof(CompanyAddress));
                }
            }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)

                {
                    _companyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }
        #endregion
        #region VisibleProperties
        public bool VisibilityCustomerCivil
        {
            get { return _visibilityCustomerCivil; }
            set
            {
                if (_visibilityCustomerCivil != value)
                {
                    _visibilityCustomerCivil = value;
                    OnPropertyChanged(nameof(VisibilityCustomerCivil));
                }
            }
        }
        public bool VisibilityCustomerCompany
        {
            get { return _visibilityCustomerCompany; }
            set
            {
                if (_visibilityCustomerCompany != value)
                {
                    _visibilityCustomerCompany = value;
                    OnPropertyChanged(nameof(VisibilityCustomerCompany));
                }
            }
        }
        public bool LoadAllPublic
        {
            get { return _loadAllPublic; }
            set
            {
                if (_loadAllPublic != value)
                {
                    _loadAllPublic = value;
                    OnPropertyChanged(nameof(LoadAllPublic));
                }
            }
        }
        public bool LoadAllCivil
        {
            get { return _loadAllCivil; }
            set
            {
                if (_loadAllCivil != value)
                {
                    _loadAllCivil = value;
                    OnPropertyChanged(nameof(LoadAllCivil));
                }
            }
        }
        public bool VisibilityPublicCustomerCreate
        {
            get { return _visibilityPublicCustomerCreate; }
            set
            {
                if (_visibilityPublicCustomerCreate != value)
                {
                    _visibilityPublicCustomerCreate = value;
                    OnPropertyChanged(nameof(VisibilityPublicCustomerCreate));
                }
            }
        }
        public bool VisibilityCivilCustomerCreate
        {
            get { return _visibilityCivilCustomerCreate; }
            set
            {
                if (_visibilityCivilCustomerCreate != value)
                {
                    _visibilityCivilCustomerCreate = value;
                    OnPropertyChanged(nameof(VisibilityCivilCustomerCreate));
                }
            }
        }
        #endregion
        #region EnabledProperties
        public bool SearchCustomer
        {
            get { return _searchCustomer; }
            set
            {
                if (_searchCustomer != value)
                {
                    _searchCustomer = value;
                    OnPropertyChanged(nameof(SearchCustomer));
                }
            }
        }
        public bool Create
        {
            get { return _create; }
            set
            {
                if (_create != value)
                {
                    _create = value;
                    OnPropertyChanged(nameof(Create));
                }
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        #endregion
        #endregion

        #region Constructors
        public CustomerViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _loadAllCivilCustomers = new RelayCommand(executeLoadAllCivilCustomersCommand);
            _loadAllPublicCustomers = new RelayCommand(executeLoadAllPublicCustomersCommand);
            _createCustomer = new RelayCommand(executeCreateCustomerCommand);
            _civilVisibility = new RelayCommand(executeCivilVisibility);
            _publicVisibility = new RelayCommand(executePublicVisibility);
            _createOffer = new RelayCommand(executeCreateOfferCommand);
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler Offer;
        #endregion

        #region Methods
        private void executeCreateOfferCommand()
        {
            CivilCustomer = SelectedCivilCustomer;
            PublicCustomer = SelectedPublicCustomer;
            Offer?.Invoke(this, new EventArgs());
        }

        private void executePublicVisibility()
        {
            Create = true;
            VisibilityCustomerCivil = false;
            VisibilityCustomerCompany = true;
            VisibilityCivilCustomerCreate = false;
            VisibilityPublicCustomerCreate = true;
            ID = Broker.Instance.GetMaxCustomerID();
            ResetToDefaultCivil();
        }

        private void executeCivilVisibility()
        {
            Create = true;
            VisibilityCustomerCivil = true;
            VisibilityCustomerCompany = false;
            VisibilityCivilCustomerCreate = true;
            VisibilityPublicCustomerCreate = false;
            ID = Broker.Instance.GetMaxCustomerID();
            ResetToDefaultPublic();
        }

        private void executeCreateCustomerCommand()
        {
            if (VisibilityCivilCustomerCreate == true)
            {
                CivilCustomer civilCustomer = new CivilCustomer();
                if (!IsDefaultCivil())
                    civilCustomer = new CivilCustomer()
                    {
                        ID = ID,
                        FirstName = FirstName,
                        LastName = LastName,
                        Address = Address,
                        IDnumber = IDnumber,
                        Type = "FIZICKO LICE"
                    };

                Broker.Instance.InsertCustomerIntoBase(civilCustomer, null, _user);
                ResetToDefaultCivil();
                AllCustomers = Broker.Instance.LoadAllCustomers("Civil");
            }
            else if (VisibilityPublicCustomerCreate == true)
            {
                PublicCustomer publicCustomer = new PublicCustomer();
                if (!IsDefaultPublic())
                    publicCustomer = new PublicCustomer()
                    {
                        ID = ID,
                        CompanyName = CompanyName,
                        CompanyAddress = CompanyAddress,
                        PIB = PIB,
                        CompanyIDnumber = CompanyIDnumber,
                        Type = "PRAVNO LICE"
                    };

                Broker.Instance.InsertCustomerIntoBase(null, publicCustomer, _user);
                ResetToDefaultPublic();
                AllCustomers = Broker.Instance.LoadAllCustomers("Public");
            }
        }

        private void ResetToDefaultPublic()
        {
            CompanyName = string.Empty;
            CompanyAddress = string.Empty;
            PIB = string.Empty;
            CompanyIDnumber = string.Empty;
            ID = Broker.Instance.GetMaxCustomerID();
        }

        private void ResetToDefaultCivil()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            IDnumber = string.Empty;
            ID = Broker.Instance.GetMaxCustomerID();
        }

        private void executeLoadAllPublicCustomersCommand()
        {
            LoadAllPublic = true;
            LoadAllCivil = false;
            SearchCustomer = true;
            AllCustomers = Broker.Instance.LoadAllCustomers("Public");
        }

        private void executeLoadAllCivilCustomersCommand()
        {
            LoadAllCivil = true;
            LoadAllPublic = false;
            SearchCustomer = true;
            AllCustomers = Broker.Instance.LoadAllCustomers("Civil");
        }

        private void executeGoBackCommand()
        {
            ResetToDefaultCivil();
            ResetToDefaultPublic();
            Succeeded?.Invoke(this, new EventArgs());
        }

        private bool IsDefaultCivil()
        {
            if (ID == 0)
                return true;
            else if (FirstName == string.Empty)
                return true;
            else if (LastName == string.Empty)
                return true;
            else if (Address == string.Empty)
                return true;
            else if (IDnumber == string.Empty)
                return true;
            return false;
        }

        private bool IsDefaultPublic()
        {
            if (ID == 0)
                return true;
            else if (CompanyName == string.Empty)
                return true;
            else if (CompanyAddress == string.Empty)
                return true;
            else if (PIB == string.Empty)
                return true;
            else if (CompanyIDnumber == string.Empty)
                return true;
            return false;
        }

        public void Start(User user)
        {
            _user = user;
            IsSelected = false;
            Create = false;
            SearchCustomer = false;
            LoadAllCivil = false;
            LoadAllPublic = false;
            VisibilityCustomerCivil = false;
            VisibilityCustomerCompany = false;
            VisibilityCivilCustomerCreate = false;
            VisibilityPublicCustomerCreate = false;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
