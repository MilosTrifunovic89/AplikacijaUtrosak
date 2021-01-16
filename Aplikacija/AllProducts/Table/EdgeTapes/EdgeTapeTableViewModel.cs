using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain.Products;
using Domain.Storage;

namespace Aplikacija.AllProducts.Table.EdgeTapes
{
    public enum ResetTape
    {
        One, Two, Three, Four
    }

    class EdgeTapeTableViewModel : ContainerViewModelBase, IEdgeTapeTableViewModel
    {
        #region Fields
        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _resetDetail;
        private RelayCommand _resetOne;
        private RelayCommand _resetTwo;
        private RelayCommand _resetThree;
        private RelayCommand _resetFour;
        private RelayCommand _setEdgeTapes;
        private RelayCommand _resetFromDetail;
        private RelayCommand _resetAll;
        #endregion

        private TableClass _table;
        private Detail _selectedDetail;

        #region IsEnabledFields
        private bool _isEnabled;
        private bool _isEnabledOne;
        private bool _isEnabledTwo;
        private bool _isEnabledThree;
        private bool _isEnabledFour;
        #endregion
        private ObservableCollection<Detail> _details;
        private ObservableCollection<EdgeTape> _allEdteTapse;
        #region VisibilityFields
        private bool _edgeOne;
        private bool _edgeTwo;
        private bool _edgeThree;
        private bool _edgeFour;
        #endregion
        #region SelectedEdgeTapesFields
        private EdgeTape _selectedEdgeTapeOne;
        private EdgeTape _selectedEdgeTapeTwo;
        private EdgeTape _selectedEdgeTapeThree;
        private EdgeTape _selectedEdgeTapeFour;
        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand ResetDetail => _resetDetail;
        public RelayCommand ResetCommandOne => _resetOne;
        public RelayCommand ResetCommandTwo => _resetTwo;
        public RelayCommand ResetCommandThree => _resetThree;
        public RelayCommand ResetCommandFour => _resetFour;
        public RelayCommand SetEdgeTape => _setEdgeTapes;
        public RelayCommand ResetFromDetail => _resetFromDetail;
        public RelayCommand ResetAll => _resetAll;
        #endregion

        public Detail SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                if (_selectedDetail != value)
                {
                    if (_selectedDetail != null)
                        resetComboBox();

                    _selectedDetail = value;

                    if (_selectedDetail != null && _selectedDetail.EdgeTapeList != null)
                    {
                        if (_selectedDetail.EdgeTapeList[0] != null)
                            SelectedEdgeTapeOne = _selectedDetail.EdgeTapeList[0];
                        if (_selectedDetail.EdgeTapeList[1] != null)
                            SelectedEdgeTapeTwo = _selectedDetail.EdgeTapeList[1];
                        if (_selectedDetail.EdgeTapeList[2] != null)
                            SelectedEdgeTapeThree = _selectedDetail.EdgeTapeList[2];
                        if (_selectedDetail.EdgeTapeList[3] != null)
                            SelectedEdgeTapeFour = _selectedDetail.EdgeTapeList[3];
                    }

                    if (_selectedDetail != null)
                        IsEnabled = true;
                    else
                        IsEnabled = false;

                    OnPropertyChanged(nameof(SelectedDetail));
                }
            }
        }
        public TableClass Table
        {
            get { return _table; }
            set { _table = value; }
        }

        #region IsEnableProperties
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }
        public bool IsEnabledFour
        {
            get { return _isEnabledFour; }
            set
            {
                if (_isEnabledFour != value)
                {
                    _isEnabledFour = value;
                    OnPropertyChanged(nameof(IsEnabledFour));
                }
            }
        }
        public bool IsEnabledThree
        {
            get { return _isEnabledThree; }
            set
            {
                if (_isEnabledThree != value)
                {
                    _isEnabledThree = value;
                    OnPropertyChanged(nameof(IsEnabledThree));
                }
            }
        }
        public bool IsEnabledTwo
        {
            get { return _isEnabledTwo; }
            set
            {
                if (_isEnabledTwo != value)
                {
                    _isEnabledTwo = value;
                    OnPropertyChanged(nameof(IsEnabledTwo));
                }
            }
        }
        public bool IsEnabledOne
        {
            get { return _isEnabledOne; }
            set
            {
                if (_isEnabledOne != value)
                {
                    _isEnabledOne = value;
                    OnPropertyChanged(nameof(IsEnabledOne));
                }
            }
        }
        #endregion
        public ObservableCollection<Detail> Details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
        }
        public ObservableCollection<EdgeTape> AllEdgeTapes
        {
            get { return _allEdteTapse; }
            set
            {
                if (_allEdteTapse != value)
                {
                    _allEdteTapse = value;
                    OnPropertyChanged(nameof(AllEdgeTapes));
                }
            }
        }
        #region VisibilityProperties
        public bool EdgeOne
        {
            get { return _edgeOne; }
            set
            {
                if (_edgeOne != value)
                {
                    _edgeOne = value;
                    OnPropertyChanged(nameof(EdgeOne));
                }
            }
        }
        public bool EdgeTwo
        {
            get { return _edgeTwo; }
            set
            {
                if (_edgeTwo != value)
                {
                    _edgeTwo = value;
                    OnPropertyChanged(nameof(EdgeTwo));
                }
            }
        }
        public bool EdgeThree
        {
            get { return _edgeThree; }
            set
            {
                if (_edgeThree != value)
                {
                    _edgeThree = value;
                    OnPropertyChanged(nameof(EdgeThree));
                }
            }
        }
        public bool EdgeFour
        {
            get { return _edgeFour; }
            set
            {
                if (_edgeFour != value)
                {
                    _edgeFour = value;
                    OnPropertyChanged(nameof(EdgeFour));
                }
            }
        }
        #endregion
        #region SelectedEdgeTapesProperties
        public EdgeTape SelectedEdgeTapeOne
        {
            get { return _selectedEdgeTapeOne; }
            set
            {
                if (_selectedEdgeTapeOne != value)
                {
                    _selectedEdgeTapeOne = value;
                    if (_selectedEdgeTapeOne != null)
                    {
                        EdgeOne = true;
                        IsEnabledOne = true;
                    }
                    else
                    {
                        EdgeOne = false;
                        IsEnabledOne = false;
                    }
                    OnPropertyChanged(nameof(SelectedEdgeTapeOne));
                }
            }
        }
        public EdgeTape SelectedEdgeTapeTwo
        {
            get { return _selectedEdgeTapeTwo; }
            set
            {
                if (_selectedEdgeTapeTwo != value)
                {
                    _selectedEdgeTapeTwo = value;
                    if (_selectedEdgeTapeTwo != null)
                    {
                        EdgeTwo = true;
                        IsEnabledTwo = true;
                    }
                    else
                    {
                        EdgeTwo = false;
                        IsEnabledTwo = false;
                    }
                    OnPropertyChanged(nameof(SelectedEdgeTapeTwo));
                }
            }
        }
        public EdgeTape SelectedEdgeTapeThree
        {
            get { return _selectedEdgeTapeThree; }
            set
            {
                if (_selectedEdgeTapeThree != value)
                {
                    _selectedEdgeTapeThree = value;
                    if (_selectedEdgeTapeThree != null)
                    {
                        EdgeThree = true;
                        IsEnabledThree = true;
                    }
                    else
                    {
                        EdgeThree = false;
                        IsEnabledThree = false;
                    }
                    OnPropertyChanged(nameof(SelectedEdgeTapeThree));
                }
            }
        }
        public EdgeTape SelectedEdgeTapeFour
        {
            get { return _selectedEdgeTapeFour; }
            set
            {
                if (_selectedEdgeTapeFour != value)
                {
                    _selectedEdgeTapeFour = value;
                    if (_selectedEdgeTapeFour != null)
                    {
                        EdgeFour = true;
                        IsEnabledFour = true;
                    }
                    else
                    {
                        EdgeFour = false;
                        IsEnabledFour = false;
                    }
                    OnPropertyChanged(nameof(SelectedEdgeTapeFour));
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
        public EdgeTapeTableViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _resetDetail = new RelayCommand(executeResetDetailCommand);
            _resetOne = new RelayCommand(executeResetCommandOne);
            _resetTwo = new RelayCommand(executeResetCommandTwo);
            _resetThree = new RelayCommand(executeResetCommandThree);
            _resetFour = new RelayCommand(executeResetCommandFour);
            _setEdgeTapes = new RelayCommand(executeSetEdgeTapesCommand);
            _resetFromDetail = new RelayCommand(executeResetFromDetailCommand);
            _resetAll = new RelayCommand(executeResetAllCommand);
        }
        #endregion

        #region Methods
        #region ResetMethods
        private void executeResetCommandOne()
        {
            reset(ResetTape.One);
        }

        private void executeResetCommandTwo()
        {
            reset(ResetTape.Two);
        }

        private void executeResetCommandThree()
        {
            reset(ResetTape.Three);
        }

        private void executeResetCommandFour()
        {
            reset(ResetTape.Four);
        }

        private void reset(ResetTape resetEdgeTape)
        {
            switch (resetEdgeTape)
            {
                case ResetTape.One:
                    ResetTapes(SelectedEdgeTapeOne, 0);

                    this.SelectedEdgeTapeOne = null;
                    break;
                case ResetTape.Two:
                    ResetTapes(SelectedEdgeTapeTwo, 1);

                    this.SelectedEdgeTapeTwo = null;
                    break;
                case ResetTape.Three:
                    ResetTapes(SelectedEdgeTapeThree, 2);

                    this.SelectedEdgeTapeThree = null;
                    break;
                case ResetTape.Four:
                    ResetTapes(SelectedEdgeTapeFour, 3);

                    this.SelectedEdgeTapeFour = null;
                    break;

                default:
                    break;
            }
        }

        public void ResetTapes(EdgeTape selectedTape, int orderNumber)
        {
            SelectedDetail.EdgeTapeList[orderNumber] = null;
        }

        private void executeResetDetailCommand()
        {
            SelectedDetail = null;
        }

        private void executeResetFromDetailCommand()
        {
            deleteAllEdgeTapesFromDetail();
        }

        private void executeResetAllCommand()
        {
            _table.RemoveAllEdgeTapes();

            this.SelectedEdgeTapeOne = null;
            this.SelectedEdgeTapeTwo = null;
            this.SelectedEdgeTapeThree = null;
            this.SelectedEdgeTapeFour = null;
        }

        private void deleteAllEdgeTapesFromDetail()
        {
            if (_table != null)
                _table.RemoveAllEdgeTapesFromDetail(_selectedDetail);

            this.SelectedEdgeTapeOne = null;
            this.SelectedEdgeTapeTwo = null;
            this.SelectedEdgeTapeThree = null;
            this.SelectedEdgeTapeFour = null;
        }

        private void resetComboBox()
        {
            this.SelectedEdgeTapeOne = null;
            this.SelectedEdgeTapeTwo = null;
            this.SelectedEdgeTapeThree = null;
            this.SelectedEdgeTapeFour = null;
        }
        #endregion

        private void executeSetEdgeTapesCommand()
        {
            if (_table != null)
                _table.AddEdgeTapes(SelectedDetail, _selectedEdgeTapeOne, _selectedEdgeTapeTwo, _selectedEdgeTapeThree, _selectedEdgeTapeFour);
        }

        private void executeGoBackCommand()
        {
            ResetToDefault();
            Succeeded?.Invoke(this, new EventArgs());
        }

        private void ResetToDefault()
        {
            IsEnabled = false;
            IsEnabledOne = false;
            IsEnabledTwo = false;
            IsEnabledThree = false;
            IsEnabledFour = false;
            SelectedDetail = null;
        }

        public void Start(TableClass table)
        {
            IsEnabled = false;
            IsEnabledOne = false;
            IsEnabledTwo = false;
            IsEnabledThree = false;
            IsEnabledFour = false;
            AllEdgeTapes = Broker.Instance.LoadAllEdgeTapes();
            _table = table;
            Details = _table.DetailList;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
