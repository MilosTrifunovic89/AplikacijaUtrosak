using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using Aplikacija.Home;
using DataBaseBroker;
using Domain;
using System;
using System.Collections.ObjectModel;

namespace Aplikacija.MiddleWindow
{
    public class MiddleViewModel : ContainerViewModelBase, IMiddleViewModel
    {
        #region Fields
        HomeViewModelResultType _result;
        private User _user;

        private Material _material;
        private Material _selectedMaterial;
        private bool _isEnabled;
        private ObservableCollection<Material> _allMaterials;

        private RelayCommand _goBack;
        private RelayCommand _choseMaterial;
        private RelayCommand _next;
        private RelayCommand _plyWood;
        private RelayCommand _mdf;
        #endregion

        #region Properties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand ChoseMaterialCommand => _choseMaterial;
        public RelayCommand NextCommand => _next;
        public RelayCommand PlyWoodCommand => _plyWood;
        public RelayCommand MDFCpmmand => _mdf;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public ObservableCollection<Material> AllMaterials
        {
            get
            {
                return _allMaterials;
            }
            set
            {
                if (_allMaterials != value)
                {
                    _allMaterials = value;
                    OnPropertyChanged(nameof(AllMaterials));
                }
            }
        }
        public Material Material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
            }
        }
        public Material SelectedMaterial
        {
            get
            {
                return _selectedMaterial;
            }
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }
        public string Header
        {
            get
            {
                if (_result == HomeViewModelResultType.RequestTable)
                    return "STO";
                return "ORMAR";
            }
        }

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
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler Next;
        #endregion

        #region Constructors
        public MiddleViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _choseMaterial = new RelayCommand(executeChoseMaterialCommand);
            _next = new RelayCommand(executeNextCommand);
            _plyWood = new RelayCommand(executePlyWoodCommand);
            _mdf = new RelayCommand(executeMDFCommand);
        }
        #endregion

        #region Methods
        private void executeMDFCommand()
        {
            AllMaterials = Broker.Instance.LoadAllMaterialsByType("MDF");
            IsEnabled = true;
        }

        private void executePlyWoodCommand()
        {
            AllMaterials = Broker.Instance.LoadAllMaterialsByType("Iverica");
            IsEnabled = true;
        }

        private void executeNextCommand()
        {
            Next?.Invoke(this, new EventArgs());
            ResetToDefault();
        }

        private void executeChoseMaterialCommand()
        {
            _material = _selectedMaterial;
        }

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
            ResetToDefault();
        }

        public void Start(HomeViewModelResultType result, User user)
        {
            _user = user;
            IsEnabled = false;
            _result = result;
            Started?.Invoke(this, new EventArgs());
        }

        private void ResetToDefault()
        {
            _material = null;
            _isEnabled = false;
            _selectedMaterial = null;
            _allMaterials = null;
        }
        #endregion
    }
}
