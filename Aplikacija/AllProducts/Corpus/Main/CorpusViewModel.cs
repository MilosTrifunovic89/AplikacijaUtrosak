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

namespace Aplikacija.AllProducts.Corpus.Main
{
    public class CorpusViewModel : ContainerViewModelBase, ICorpusViewModel
    {
        #region Fields
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
        private RelayCommand _addDetail;
        #endregion

        private CorpusClass _corpus;
        private Material _material;
        private User _user;
        private decimal _marza;
        private string _specification;

        #region IsEnabled/Checked
        private bool _isEnabled;
        private bool _isEnabledMarza;
        private bool _isEnableButton;
        private bool _isCheckedRegular;
        private bool _isCheckedTender;
        private bool _isEnabledDataBase;
        #endregion

        #region CorpusFields
        private long _id;
        private string _corpusName;
        private int _width;
        private int _depth;
        private int _height;
        private int _legHeight;
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
        public RelayCommand AddDetailCommand => _addDetail;
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
        public CorpusClass Corpus
        {
            get { return _corpus; }
            set
            {
                if (_corpus != value)
                {
                    _corpus = value;
                    OnPropertyChanged(nameof(Corpus));
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
        #endregion

        #region TableProperties
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
        public int LegHeight
        {
            get { return _legHeight; }
            set
            {
                if (_legHeight != value)
                {
                    _legHeight = value;
                    OnPropertyChanged(nameof(LegHeight));
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
        public string CorpusName
        {
            get { return _corpusName; }
            set
            {
                if (_corpusName != value)
                {
                    _corpusName = value;
                    OnPropertyChanged(nameof(CorpusName));
                }
            }
        }
        #endregion
        #endregion

        #region Constructors
        public CorpusViewModel()
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
            _addDetail = new RelayCommand(executeAddDetailCommand);
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler AddDetail;
        public event EventHandler ChangeMaterial;
        public event EventHandler EdgeTape;
        public event EventHandler Fittings;
        #endregion

        #region Methods
        private void executeAddDetailCommand()
        {
            if (IsEnableButton == false && _corpus != null)
                AddDetail?.Invoke(this, new EventArgs());
        }

        private void executeGetSpecificationCommand()
        {
            if (Marza <= 1)
            {
                Specification = _corpus.GetSpecification(1);
                IsEnabledDataBase = true;
            }
            else if (Marza > 1)
            {
                Specification = _corpus.GetSpecification(Marza);
                IsEnabledDataBase = true;
            }
        }

        private void executeInsertIntoBaseCommand()
        {
            Broker.Instance.InsertElementIntoBase(_corpus, _user);
            IsEnabledDataBase = false;
            ResetToDefault();
        }

        private void executeResetCommand()
        {
            ResetToDefault();
        }

        private void executeFittingsCommand()
        {
            if (IsEnableButton == false && _corpus != null)
                Fittings?.Invoke(this, new EventArgs());
        }

        private void executeChangeMaterialCommand()
        {
            if (IsEnableButton == false && _corpus != null)
                ChangeMaterial?.Invoke(this, new EventArgs());
        }

        private void executeEdgeTapeCommand()
        {
            if (IsEnableButton == false && _corpus != null)
                EdgeTape?.Invoke(this, new EventArgs());
        }

        private void executeCreateCommand()
        {
            if (IsDefaultValues())
            {
                _corpus = new CorpusClass(_id, _corpusName, _width, _height, _depth, _legHeight, _material);
                IsEnableButton = false;
                IsEnabled = false;
                IsEnabledMarza = true;
                _corpus.CuttingList();
            }
        }

        private void executeGetMaxTenderIDCommand()
        {
            if (_corpus == null)
            {
                ID = Broker.Instance.GetMaxProductID("tender");
                IsEnabled = true;
                IsCheckedTender = true;
            }
        }

        private void executeGetMaxRegularIDCommand()
        {
            if (_corpus == null)
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

        private void ResetToDefault()
        {
            ID = 0;
            IsEnabled = false;
            IsEnableButton = true;
            Corpus = null;
            CorpusName = null;
            Width = 0;
            Depth = 0;
            Height = 0;
            LegHeight = 0;
            IsCheckedRegular = false;
            IsCheckedTender = false;
            IsEnabledMarza = false;
            Marza = 0;
            Specification = null;
            IsEnabledDataBase = false;
        }

        private bool IsDefaultValues()
        {
            if (String.IsNullOrWhiteSpace(_corpusName))
                return false;
            else if (_width == 0)
                return false;
            else if (_height == 0)
                return false;
            else if (_depth == 0)
                return false;
            else if (_legHeight == 0)
                return false;
            return true;
        }

        public void Start(Material material, User user)
        {
            _user = user;
            _material = material;
            IsEnabledDataBase = false;
            IsCheckedRegular = false;
            IsCheckedTender = false;
            IsEnabled = false;
            IsEnableButton = true;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
