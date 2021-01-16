using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain;
using Domain.Customer;
using Domain.Offer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aplikacija.Offer.Main
{
    public class OfferViewModel : ContainerViewModelBase, IOfferViewModel
    {
        #region Fields
        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _endInsert;
        private RelayCommand _insert;
        private RelayCommand _create;
        private RelayCommand _addImage;
        private RelayCommand _createOfferProduct;
        //private RelayCommand _checkOfferFields;
        #endregion
        #region OfferFields
        private long _offerNumber;
        private int _deliveryTime;
        private int _paymentTime;
        private int _offerValidity;
        private int _discount;
        private string _image;
        private bool _accepted;
        OfferClass _offer;
        #endregion
        private string _description;
        private int _number;
        User _user;
        CivilCustomer _civilCustomer;
        PublicCustomer _publicCustomer;
        private Product _selectedElement;
        private string _customerInfo;
        private ObservableCollection<Product> _allElements;
        private ObservableCollection<OfferProduct> _elementsForOffer = new ObservableCollection<OfferProduct>();
        private OfferProduct _offerProduct = new OfferProduct();
        #region IsEnabledFields
        private bool _isSelected;
        private bool _finishedAdding;
        private bool _isChecked;
        private bool _checkOfferFields;

        public bool CheckOfferFields
        {
            get { return CheckOfferFieldsFill(); }
        }

        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand EndInsertCommand => _endInsert;
        public RelayCommand InsertCommand => _insert;
        public RelayCommand CreateCommand => _create;
        public RelayCommand AddImageCommand => _addImage;
        public RelayCommand CreateOfferCommand => _createOfferProduct;
        //public RelayCommand CheckOfferFieldsFillCommand => _checkOfferFields;
        #endregion
        #region OfferProperties
        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged();
                }
            }
        }
        public long OfferNumber
        {
            get { /*return Broker.Instance.GetMaxOFferID();*/ return _offerNumber; }
            set
            {
                if (_offerNumber != value)
                {
                    _offerNumber = value;
                    OnPropertyChanged(nameof(OfferNumber));
                }
            }
        }
        public int Discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged(nameof(Discount));
                }
            }
        }
        public int OfferValidity
        {
            get { return _offerValidity; }
            set
            {
                if (_offerValidity != value)
                {
                    _offerValidity = value;
                    OnPropertyChanged(nameof(OfferValidity));
                }
            }
        }
        public int PaymentTime
        {
            get { return _paymentTime; }
            set
            {
                if (_paymentTime != value)
                {
                    _paymentTime = value;
                    OnPropertyChanged(nameof(PaymentTime));
                }
            }
        }
        public int DeliveryTime
        {
            get { return _deliveryTime; }
            set
            {
                if (_deliveryTime != value)
                {
                    _deliveryTime = value;
                    OnPropertyChanged(nameof(DeliveryTime));
                }
            }
        }
        #endregion
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)

                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public int Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }
        public string CustomerInfo
        {
            get { return _customerInfo; }
            set
            {
                if (_customerInfo != value)
                {
                    _customerInfo = value;
                    OnPropertyChanged(nameof(CustomerInfo));
                }
            }
        }
        public OfferProduct OfferProduct
        {
            get { return _offerProduct; }
            set { _offerProduct = value; }
        }
        public ObservableCollection<Product> AllElements
        {
            get { return _allElements; }
            set { _allElements = value; }
        }
        public ObservableCollection<OfferProduct> ElementsForOffer
        {
            get { return _elementsForOffer; }
            set { _elementsForOffer = value; }
        }
        public Product SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                if (_selectedElement != value)
                {
                    _selectedElement = value;
                    OnPropertyChanged(nameof(SelectedElement));
                }
            }
        }
        #region IsEnabledProperties
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
        public bool FinishedAdding
        {
            get { return _finishedAdding; }
            set
            {
                if (_finishedAdding != value)
                {
                    _finishedAdding = value;
                    OnPropertyChanged(nameof(FinishedAdding));
                }
            }
        }
        public bool Accepted
        {
            get { return _accepted; }
            set
            {
                if (_accepted != value)
                {
                    _accepted = value;
                    if (_accepted == true)
                        IsChecked = false;
                    OnPropertyChanged(nameof(Accepted));
                }
            }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
        #endregion
        #endregion

        #region Constructors
        public OfferViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _endInsert = new RelayCommand(executeFinishAddingCommand);
            _addImage = new RelayCommand(executeAddImageCommand);
            _insert = new RelayCommand(executeInsertCommand);
            _createOfferProduct = new RelayCommand(executeCreateOfferProduct);
            _create = new RelayCommand(executeCreateCommand);
            //_checkOfferFields=new RelayCommand()
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler CheckOffer;
        #endregion

        #region Methods
        private void executeCreateCommand()
        {
            CreateNewOffer();

            if (Broker.Instance.InsertOffer(_offer, _user))
            {
                _offer.CreateOffer();
                OfferNumber = Broker.Instance.GetMaxOfferID();
                IsChecked = true;
                Accepted = false;
                ResetToDefault();
            }   
            
        }

        private bool CheckOfferFieldsFill()
        {
            if (DeliveryTime < 1)
                return false;
            else if (PaymentTime < 1)
                return false;
            else if (OfferValidity < 1)
                return false;
            return true;
        }

        private void CreateNewOffer()
        {
            _offer = new OfferClass()
            {
                ID = OfferNumber,
                CivilCustomer = _civilCustomer,
                PublicCustomer = _publicCustomer,
                Year = DateTime.Now.Year,
                ElementList = ElementsForOffer,
                DeliveryTime = DeliveryTime,
                Discount = Discount,
                OfferValidity = OfferValidity,
                PaymentTime = PaymentTime
            };
        }

        private void ResetToDefault()
        {
            ElementsForOffer = null;
            SelectedElement = null;
            Description = string.Empty;
            Number = 0;
            DeliveryTime = 0;
            Discount = 0;
            PaymentTime = 0;
            OfferValidity = 0;
            _offer = null;
            Image = string.Empty;
        }
        private void executeCreateOfferProduct()
        {
            CreateOfferProduct();
        }
        private void executeInsertCommand()
        {
            ElementsForOffer.Add(OfferProduct);
            SelectedElement = null;
            Number = 0;
            Image = string.Empty;
        }
        private void CreateOfferProduct()
        {
            _offerProduct = new OfferProduct();
            //_offerProduct.OfferID = OfferNumber;
            _offerProduct.ProductID = SelectedElement.ID;
            _offerProduct.ProductName = SelectedElement.Name;
            _offerProduct.Dimension = SelectedElement.Dimenzion;
            _offerProduct.Price = SelectedElement.Price;
            _offerProduct.Description = Description;
            _offerProduct.Image = Image;
            _offerProduct.Quantity = Number;
        }
        private void executeAddImageCommand()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|"
              + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
              + "Zip Files|*.zip;*.rar";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Image = dialog.FileName;
            }
        }
        private void executeFinishAddingCommand()
        {
            CheckOffer?.Invoke(this, new EventArgs());
        }
        private void executeGoBackCommand()
        {
            ResetToDefault();
            Succeeded?.Invoke(this, new EventArgs());
        }
        //private void ResetToDefault()
        //{
        //    SelectedElement = null;
        //    Discount = 0;
        //    PaymentTime = 0;
        //    OfferValidity = 0;
        //    DeliveryTime = 0;
        //    Number = 0;
        //}
        public void Start(User user, CivilCustomer civilCustomer, PublicCustomer publicCustomer)
        {
            Accepted = false;
            IsChecked = true;
            _user = user;
            _civilCustomer = civilCustomer;
            _publicCustomer = publicCustomer;
            if (_civilCustomer != null)
                _customerInfo = $"ID:\t{_civilCustomer.ID}\nIme:\t{_civilCustomer.FirstName} {_civilCustomer.LastName}\nAdresa:\t{_civilCustomer.Address}\nJMBG:\t{_civilCustomer.IDnumber}";
            else if (_publicCustomer != null)
                _customerInfo = $"ID:\t\t{_publicCustomer.ID}\nNaziv firme:\t{_publicCustomer.CompanyName}\nAdresa:\t\t{_publicCustomer.CompanyAddress}\nPIB:\t\t{_publicCustomer.PIB}\nMaticni broj:\t{_publicCustomer.CompanyIDnumber}";
            IsSelected = true;
            FinishedAdding = false;
            AllElements = Broker.Instance.LoadAllElements();
            OfferNumber = Broker.Instance.GetMaxOfferID();
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}