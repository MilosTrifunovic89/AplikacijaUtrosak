using Aplikacija.Base.ViewModel;
using Aplikacija.Common;
using Domain;
using Domain.Products;
using System;
using System.Collections.ObjectModel;

namespace Aplikacija.AllProducts.Corpus.Details
{
    public class AddDetailViewModel : ContainerViewModelBase, IAddDetailViewModel
    {
        #region Fields
        #region RelayCommandFields
        private RelayCommand _goBack;
        private RelayCommand _addDetail;
        private RelayCommand _removeDetail;
        #endregion
        private Material _material;
        private CorpusClass _corpus;
        private int _number;
        private string _selectedDetail;
        private Detail _detailToRemove;
        #region IsEnabled/VisibleFields
        private bool _isEnabledInsert;
        private bool _isEnabledRemove;
        #endregion
        #endregion

        #region Properties
        #region RelayCommandProperties
        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand AddDetailCommand => _addDetail;
        public RelayCommand RemoveDetailCommand => _removeDetail;
        #endregion
        public ObservableCollection<string> DetailToAdd => new ObservableCollection<string> { "Pregrada", "Polica", "Sokla", "Vrata", "Top", "Stranica" };
        public ObservableCollection<Detail> DetailsInElement => _corpus.DetailList;
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
        public Detail DetailToRemove
        {
            get { return _detailToRemove; }
            set
            {
                if (_detailToRemove != value)
                {
                    _detailToRemove = value;
                    if (_detailToRemove != null)
                    {
                        IsEnabledRemove = true;
                        SelectedDetail = null;
                    }
                    else
                        IsEnabledRemove = false;
                    OnPropertyChanged(nameof(DetailToRemove));
                }
            }
        }
        public string SelectedDetail
        {
            get { return _selectedDetail; }
            set
            {
                if (_selectedDetail != value)
                {
                    _selectedDetail = value;
                    if (_selectedDetail != null)
                    {
                        IsEnabledInsert = true;
                        DetailToRemove = null;
                    }
                    else
                        IsEnabledInsert = false;
                    OnPropertyChanged(nameof(SelectedDetail));
                }
            }
        }
        #region IsEnabled/VisibleProperties
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

        #region Constructors
        public AddDetailViewModel()
        {
            _goBack = new RelayCommand(executeGoBackCommand);
            _addDetail = new RelayCommand(executeAddDetailCommand);
            _removeDetail = new RelayCommand(executeRemoveDetailCommand);
        }
        #endregion

        #region Events
        public event EventHandler Started;
        public event EventHandler Succeeded;
        #endregion

        #region Methods
        private void executeRemoveDetailCommand()
        {
            _corpus.RemoveDetail(DetailToRemove);
        }

        private void executeAddDetailCommand()
        {
            _corpus.AddDetail(_selectedDetail, _number, _material);
            Number = 0;
        }

        private void ResetToDefault()
        {
            Number = 0;
            IsEnabledInsert = false;
            IsEnabledRemove = false;
            SelectedDetail = null;
            DetailToRemove = null;
        }

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start(CorpusClass corpus, Material material)
        {
            _corpus = corpus;
            _material = material;
            IsEnabledRemove = false;
            IsEnabledInsert = false;
            Started?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
