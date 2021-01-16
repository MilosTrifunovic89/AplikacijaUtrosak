using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using Domain.Offer;

namespace Aplikacija.Offer.ArticlesInOffer
{
    public class ArticlesInOfferViewModel : ContainerViewModelBase, IArticlesInOfferViewModel
    {
        #region Fields
        #region RelatCommandFields
        private RelayCommand _goBack;
        private RelayCommand _update;
        private RelayCommand _delete;
        private RelayCommand _accept;
        #endregion
        private ObservableCollection<OfferProduct> _offerProducts = new ObservableCollection<OfferProduct>();
        private OfferProduct _selectedElement;
        private string _description;
        private int _quantity;
        private bool _isEmpty;
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand UpdateCommand => _update;
        public RelayCommand DeleteCommand => _delete;
        public RelayCommand AcceptCommand => _accept;
        #endregion
        public ObservableCollection<OfferProduct> OfferProducts
        {
            get
            {
                return _offerProducts;
            }
            set
            {
                if (_offerProducts != value)
                {
                    _offerProducts = value;
                    OnPropertyChanged(nameof(OfferProducts));
                }
            }
        }
        public OfferProduct SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                if (_selectedElement != value)
                {
                    _selectedElement = value;
                    if (_selectedElement != null)
                    {
                        Quantity = _selectedElement.Quantity;
                        Description = _selectedElement.Description;
                    }
                    OnPropertyChanged(nameof(SelectedElement));
                }
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
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
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                if (_isEmpty != value)
                {
                    _isEmpty = value;
                    OnPropertyChanged(nameof(IsEmpty));
                }
            }
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler Accept;
        #endregion

        #region Constructors
        public ArticlesInOfferViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _update = new RelayCommand(executeUpdateCommand);
            _delete = new RelayCommand(executeDeleteCommand);
            _accept = new RelayCommand(executeAcceptCommand);
        }
        #endregion

        #region Methods
        private void executeAcceptCommand()
        {
            Accept?.Invoke(this, new EventArgs());
        }

        private void executeDeleteCommand()
        {
            foreach (var product in OfferProducts)
            {
                if (product.ProductID == SelectedElement.ProductID)
                {
                    OfferProducts.Remove(product);
                    break;
                }
            }
            if (_offerProducts.Count == 0)
                IsEmpty = false;

        }

        private void executeUpdateCommand()
        {
            for (int i = 0; i < _offerProducts.Count; i++)
            {
                if (_offerProducts[i].ProductID == SelectedElement.ProductID)
                {
                    _offerProducts[i].Description = Description;
                    _offerProducts[i].Quantity = Quantity;
                    SelectedElement.Quantity = Quantity;
                    SelectedElement.Description = Description;
                    break;
                }
            }
        }

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start(ObservableCollection<OfferProduct> offerProducts)
        {
            IsEmpty = true;
            SelectedElement = null;
            Description = string.Empty;
            Quantity = 0;
            _offerProducts = offerProducts;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
