using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aplikacija.AllProducts.Table.Main
{
    public class TableViewModel : ContainerViewModelBase, ITableViewModel
    {
        #region Fields
        private Material _material = new Material();
        private long _id;
        private decimal _marza;
        private string _specification;
        private User _user;

        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _getMaxRegularID;
        private RelayCommand _getMaxTenderID;
        private RelayCommand _create;
        private RelayCommand _changeMaterial;
        private RelayCommand _reset;
        private RelayCommand _edgeTape;
        private RelayCommand _fittings;
        private RelayCommand _getSpecification;
        private RelayCommand _insertIntoBase;
        private RelayCommand _choseWoodenConstruction;
        private RelayCommand _choseMetalConstruction;
        #endregion

        #region IsEnabled/Checked
        private bool _isEnabled;
        private bool _isEnabledMarza;
        private bool _isEnableButton;
        private bool _isCheckedRegular;
        private bool _isCheckedTender;
        private bool _isEnabledDataBase;
        private bool _metalConstruction;
        private bool _woodenConstruction;
        private bool _woodenConstructionIsEnabled;
        private bool _metalConstructionIsEnabled;
        #endregion

        #region TableFields
        private string _tableName;
        private int _width;
        private int _depth;
        private int _height;
        private int _binderWidth;
        private TableClass _table;
        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand GetMaxRegilarID => _getMaxRegularID;
        public RelayCommand GetMaxTenderID => _getMaxTenderID;
        public RelayCommand CreateCommand => _create;
        public RelayCommand ChangeMaterialCommand => _changeMaterial;
        public RelayCommand ResetCommand => _reset;
        public RelayCommand EdgeTapeCommand => _edgeTape;
        public RelayCommand FittingsCommand => _fittings;
        public RelayCommand GetSpecificationCommand => _getSpecification;
        public RelayCommand InsertIntoBaseCommand => _insertIntoBase;
        public RelayCommand ChoseWoodenConstruction => _choseWoodenConstruction;
        public RelayCommand ChoseMetalConstruction => _choseMetalConstruction;
        #endregion
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public Material Material
        {
            get { return _material; }
            set { _material = value; }
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
        public decimal Marza
        {
            get { return _marza; }
            set
            {
                if (_marza != value)
                {
                    _marza = value;
                    OnPropertyChanged(nameof(Marza));
                }
            }
        }
        public string Specification
        {
            get { return _specification; }
            set
            {
                if (_specification != value)
                {
                    _specification = value;
                    OnPropertyChanged(nameof(Specification));
                }
            }
        }

        #region IsEnabled/Checked
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
        public bool IsEnabledMarza
        {
            get { return _isEnabledMarza; }
            set
            {
                if (_isEnabledMarza != value)
                {
                    _isEnabledMarza = value;
                    OnPropertyChanged(nameof(IsEnabledMarza));
                }
            }
        }
        public bool IsCheckedRegular
        {
            get { return _isCheckedRegular; }
            set
            {
                if (_isCheckedRegular != value)
                {
                    _isCheckedRegular = value;
                    OnPropertyChanged(nameof(IsCheckedRegular));
                }
            }
        }
        public bool IsEnabledDataBase
        {
            get { return _isEnabledDataBase; }
            set
            {
                if (_isEnabledDataBase != value)
                {
                    _isEnabledDataBase = value;
                    OnPropertyChanged(nameof(IsEnabledDataBase));
                }
            }
        }
        public bool IsCheckedTender
        {
            get { return _isCheckedTender; }
            set
            {
                if (_isCheckedTender != value)
                {
                    _isCheckedTender = value;
                    OnPropertyChanged(nameof(IsCheckedTender));
                }
            }
        }
        public bool IsEnableButton
        {
            get { return _isEnableButton; }
            set
            {
                if (_isEnableButton != value)
                {
                    _isEnableButton = value;
                    OnPropertyChanged(nameof(IsEnableButton));
                }
            }
        }
        public bool WoodenConstruction
        {
            get { return _woodenConstruction; }
            set
            {
                if (_woodenConstruction != value)
                {
                    _woodenConstruction = value;
                    OnPropertyChanged(nameof(WoodenConstruction));
                }
            }
        }
        public bool MetalConstruction
        {
            get { return _metalConstruction; }
            set
            {
                if (_metalConstruction != value)
                {
                    _metalConstruction = value;
                    OnPropertyChanged(nameof(MetalConstruction));
                }
            }
        }
        public bool WoodenConstructionIsEnabled
        {
            get { return _woodenConstructionIsEnabled; }
            set
            {
                if (_woodenConstructionIsEnabled != value)
                {
                    _woodenConstructionIsEnabled = value;
                    OnPropertyChanged(nameof(WoodenConstructionIsEnabled));
                }
            }
        }
        public bool MetalConstructionIsEnabled
        {
            get { return _metalConstructionIsEnabled; }
            set
            {
                if (_metalConstructionIsEnabled != value)
                {
                    _metalConstructionIsEnabled = value;
                    OnPropertyChanged(nameof(MetalConstructionIsEnabled));
                }
            }
        }
        #endregion

        #region TableProperties
        public int BinderWidth
        {
            get { return _binderWidth; }
            set
            {
                if (_binderWidth != value)
                {
                    _binderWidth = value;
                    OnPropertyChanged(nameof(BinderWidth));
                }
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }
        public int Depth
        {
            get { return _depth; }
            set
            {
                if (_depth != value)
                {
                    _depth = value;
                    OnPropertyChanged(nameof(Depth));
                }
            }
        }
        public int Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }
        public string TableName
        {
            get { return _tableName; }
            set
            {
                if (_tableName != value)
                {
                    _tableName = value;
                    OnPropertyChanged(nameof(TableName));
                }
            }
        }
        public TableClass Table
        {
            get { return _table; }
            set { _table = value; }
        }
        #endregion
        #endregion

        #region Constructor
        public TableViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _getMaxRegularID = new RelayCommand(executeGetMaxRegularIDCommand);
            _getMaxTenderID = new RelayCommand(executeGetMaxTenderIDCommand);
            _create = new RelayCommand(executeCreateCommand);
            _changeMaterial = new RelayCommand(executeChangeMaterialCommand);
            _reset = new RelayCommand(executeResetCommand);
            _edgeTape = new RelayCommand(executeEdgeTapeCommand);
            _fittings = new RelayCommand(executeFittingsCommand);
            _getSpecification = new RelayCommand(executeGetSpecificationCommand);
            _insertIntoBase = new RelayCommand(executeInsertIntoBaseCommand);
            _choseMetalConstruction = new RelayCommand(executeChoseMetalConstruction);
            _choseWoodenConstruction = new RelayCommand(executeWoodenConstruction);
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler ChangeMaterial;
        public event EventHandler EdgeTape;
        public event EventHandler Fittings;
        #endregion

        #region Methods
        private void executeWoodenConstruction()
        {
            WoodenConstruction = true;
            MetalConstruction = false;
            WoodenConstructionIsEnabled = true;
            MetalConstructionIsEnabled = true;
        }

        private void executeChoseMetalConstruction()
        {
            MetalConstruction = true;
            WoodenConstruction = false;
            WoodenConstructionIsEnabled = false;
            MetalConstructionIsEnabled = true;
        }

        private void executeInsertIntoBaseCommand()
        {
            Broker.Instance.InsertElementIntoBase(_table, _user);
            IsEnabledDataBase = false;
            ResetToDefault();
        }

        private void executeGetSpecificationCommand()
        {
            if (Marza <= 1)
            {
                Specification = _table.GetSpecification(1);
                IsEnabledDataBase = true;
            }
            else if (Marza > 1)
            {
                Specification = _table.GetSpecification(Marza);
                IsEnabledDataBase = true;
            }
        }

        private void executeFittingsCommand()
        {
            if (IsEnableButton == false && _table != null)
                Fittings?.Invoke(this, new EventArgs());
        }

        private void executeEdgeTapeCommand()
        {
            if (IsEnableButton == false && _table != null)
                EdgeTape?.Invoke(this, new EventArgs());
        }

        private void executeResetCommand()
        {
            ResetToDefault();
        }

        private void executeChangeMaterialCommand()
        {
            if (IsEnableButton == false && _table != null)
                ChangeMaterial?.Invoke(this, new EventArgs());
        }

        private void executeCreateCommand()
        {
            if (!IsDefaultValues() && WoodenConstruction == true)
            {
                _table = new TableClass(_id, _tableName, _width, _height, _depth, _binderWidth, _material);
                IsEnableButton = false;
                IsEnabled = false;
                IsEnabledMarza = true;
                _table.CuttingList();
            }
            else if (!IsDefaultValuesConstruction() && MetalConstruction == true)
            {
                _table = new TableClass(_id, _tableName, _width, _depth, _height, _material);
                IsEnabled = false;
                IsEnableButton = false;
                IsEnabledMarza = true;
                _table.CuttingList();
            }
        }

        private bool IsDefaultValuesConstruction()
        {
            if (String.IsNullOrWhiteSpace(_tableName))
                return true;
            else if (_width == 0)
                return true;
            else if (_depth == 0)
                return true;
            return false;
        }

        private void executeGetMaxTenderIDCommand()
        {
            if (_table == null)
            {
                ID = Broker.Instance.GetMaxProductID("tender");
                IsEnabled = true;
                IsCheckedTender = true;
            }
        }

        private void executeGetMaxRegularIDCommand()
        {
            if (_table == null)
            {
                ID = Broker.Instance.GetMaxProductID("regular");
                IsEnabled = true;
                IsCheckedRegular = true;
            }
        }

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
            ResetToDefault();
            Material = null;
        }

        private bool IsDefaultValues()
        {
            if (String.IsNullOrWhiteSpace(_tableName))
                return true;
            else if (_width == 0)
                return true;
            else if (_height == 0)
                return true;
            else if (_depth == 0)
                return true;
            else if (_binderWidth == 0)
                return true;
            return false;
        }

        private void ResetToDefault()
        {
            ID = 0;
            IsEnabled = false;
            IsEnableButton = true;
            Table = null;
            TableName = null;
            Width = 0;
            Depth = 0;
            Height = 0;
            BinderWidth = 0;
            IsCheckedRegular = false;
            IsCheckedTender = false;
            IsEnabledMarza = false;
            Marza = 0;
            Specification = null;
            IsEnabledDataBase = false;
            MetalConstruction = false;
            WoodenConstruction = false;
            MetalConstructionIsEnabled = false;
            WoodenConstructionIsEnabled = false;
        }

        public void Start(Material material, User user)
        {
            _user = user;
            IsEnabledDataBase = false;
            IsCheckedRegular = false;
            IsCheckedTender = false;
            IsEnabled = false;
            _material = material;
            IsEnableButton = true;
            MetalConstruction = false;
            WoodenConstruction = false;
            MetalConstructionIsEnabled = false;
            WoodenConstructionIsEnabled = false;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}