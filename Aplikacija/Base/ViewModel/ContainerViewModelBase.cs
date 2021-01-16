namespace Aplikacija.Base.ViewModel
{
    public abstract class ContainerViewModelBase : ViewModelBase, IContainerViewModel
    {
        private IViewModel _currentViewModel;

        public IViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            protected set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
