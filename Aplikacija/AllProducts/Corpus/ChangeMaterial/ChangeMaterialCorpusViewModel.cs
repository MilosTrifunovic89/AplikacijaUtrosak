using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using DataBaseBroker;
using Domain;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.AllProducts.Corpus.ChangeMaterial
{
    public class ChangeMaterialCorpusViewModel : ContainerViewModelBase, IChangeMaterialCorpusViewModel
    {
        #region Fields
        private RelayCommand _changeMaterial;
        private RelayCommand _goBack;
        private RelayCommand _plyWood;
        private RelayCommand _mdf;

        private CorpusClass _corpus;
        private ObservableCollection<Detail> _details;
        private ObservableCollection<Material> _allMaterials;
        private Material _selectedMaterial;
        private Detail _selectedDetail;
        private bool _isEnabled;
        #endregion

        #region Properties
        public RelayCommand ChangeMaterialCommand => _changeMaterial;
        public RelayCommand PlyWoodCommand => _plyWood;
        public RelayCommand MDFCpmmand => _mdf;
        public RelayCommand GoBackCommand => _goBack;

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
        public Material SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }
        public Detail SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                if (_selectedDetail != value)
                {
                    _selectedDetail = value;
                    OnPropertyChanged(nameof(SelectedDetail.Material));
                }
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
        public ChangeMaterialCorpusViewModel()
        {
            _changeMaterial = new RelayCommand(executeChangeMaterialCommand);
            _plyWood = new RelayCommand(executePlyWoodCommand);
            _mdf = new RelayCommand(executeMDFCommand);
            _goBack = new RelayCommand(executeGoBackCommand);
        }
        #region Constructors

        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        #endregion

        #region Methods
        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
            ResetToDefault();
        }

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

        private void executeChangeMaterialCommand()
        {
            SelectedDetail.Material = SelectedMaterial;
        }

        private void ResetToDefault()
        {
            SelectedDetail = null;
            SelectedMaterial = null;
        }

        public void Start(CorpusClass corpus)
        {
            IsEnabled = false;
            _corpus = corpus;
            Details = _corpus.DetailList;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
