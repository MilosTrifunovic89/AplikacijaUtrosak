using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain.Products;
using Domain.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aplikacija.AllProducts.Table.Fittings
{
    class FittingsTableViewModel : ContainerViewModelBase, IFittingsTableViewModel
    {
        #region Fields
        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _insertFitting;
        private RelayCommand _removeFitting;
        private RelayCommand _proba;
        #endregion

        private ObservableCollection<FittingsClass> _allFittings;
        private TableClass _table;
        private FittingsClass _selectedFitting;
        private FittingsClass _selectedFittingToRemove;
        private float _nuber;

        #region IsEnabledFields
        private bool _isEnabledInsert;
        private bool _isEnabledRemove;
        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand InsertFittingCommand => _insertFitting;
        public RelayCommand RemoveFittingCommand => _removeFitting;
        public RelayCommand Proba => _proba;
        #endregion
        public ObservableCollection<FittingsClass> AllFittings
        {
            get { return _allFittings; }
            set
            {
                if (_allFittings != value)
                {
                    _allFittings = value;
                    OnPropertyChanged(nameof(Fittings));
                }
            }
        }
        public FittingsClass SelectedFittingToRemove
        {
            get { return _selectedFittingToRemove; }
            set
            {
                if (_selectedFittingToRemove != value)
                {
                    _selectedFittingToRemove = value;

                    if (_selectedFittingToRemove != null)
                        IsEnabledRemove = true;

                    OnPropertyChanged(nameof(SelectedFittingToRemove));
                }
            }
        }
        public FittingsClass SelectedFitting
        {
            get { return _selectedFitting; }
            set
            {
                if (_selectedFitting != value)
                {
                    _selectedFitting = value;

                    if (_selectedFitting != null)
                        IsEnabledInsert = true;

                    OnPropertyChanged(nameof(SelectedFitting));
                }
            }
        }
        public float Number
        {
            get { return _nuber; }
            set
            {
                if (_nuber != value)
                {
                    _nuber = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }
        public ObservableCollection<FittingsClass> FittingsInElement => _table.FittingsInElement;
        #region IsEnabledProperties
        public bool IsEnabledRemove
        {
            get { return _isEnabledRemove; }
            set
            {
                if (_isEnabledRemove != value)
                {
                    _isEnabledRemove = value;
                    OnPropertyChanged(nameof(IsEnabledRemove));
                }
            }
        }
        public bool IsEnabledInsert
        {
            get { return _isEnabledInsert; }
            set
            {
                if (_isEnabledInsert != value)
                {
                    _isEnabledInsert = value;
                    OnPropertyChanged(nameof(IsEnabledInsert));
                }
            }
        }
        #endregion
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        #endregion

        #region Constructors
        public FittingsTableViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _insertFitting = new RelayCommand(executeInsertFittingCommand);
            _removeFitting = new RelayCommand(executeRemoveFittingCommand);
            _proba = new RelayCommand(PROBA);
        }
        #endregion

        #region Methods
        private void PROBA()
        {
            foreach (var item in _table.FittingsInElement)
            {
                MessageBox.Show($"{item.ID}\n{item.FittingName}\n{item.Quantity}\n{item.UnitOfMeasure}\n{item.Price}");
            }
        }

        private void executeRemoveFittingCommand()
        {
            _table.RemoveFittings(_selectedFittingToRemove);
            IsEnabledRemove = false;
        }

        private void executeInsertFittingCommand()
        {
            FittingsClass fitting = new FittingsClass()
            {
                ID = SelectedFitting.ID,
                FittingName = SelectedFitting.FittingName,
                Price = SelectedFitting.Price,
                UnitOfMeasure = SelectedFitting.UnitOfMeasure,
                Quantity = _nuber
            };

            if (_table != null)
                _table.AddFittings(fitting);

            Number = 0f;
        }

        private void ResetToDefault()
        {
            Number = 0f;
            SelectedFitting = null;
            SelectedFittingToRemove = null;
        }

        private void executeGoBackCommand()
        {
            ResetToDefault();
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start(TableClass table)
        {
            AllFittings = Broker.Instance.LoadAllFittings();
            _table = table;
            IsEnabledRemove = false;
            IsEnabledInsert = false;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
