using Aplikacija.AllProducts.Corpus.ChangeMaterial;
using Aplikacija.AllProducts.Corpus.Details;
using Aplikacija.AllProducts.Corpus.EdgeTapes;
using Aplikacija.AllProducts.Corpus.Fittings;
using Aplikacija.AllProducts.Corpus.Main;
using Aplikacija.AllProducts.Table.ChangeMaterial;
using Aplikacija.AllProducts.Table.EdgeTapes;
using Aplikacija.AllProducts.Table.Fittings;
using Aplikacija.AllProducts.Table.Main;
using Aplikacija.Base.ViewModel;
using Aplikacija.Home;
using Aplikacija.LogIn;
using Aplikacija.MiddleWindow;
using Aplikacija.Offer.ArticlesInOffer;
using Aplikacija.Offer.Customer;
using Aplikacija.Offer.Main;
using System;

namespace Aplikacija.Main
{
    public class MainViewModel : ContainerViewModelBase, IMainViewModel
    {
        private ILogInViewModel _logInViewModel;
        private IHomeViewModel _homeViewModel;
        private ITableViewModel _tableViewModel;
        private IMiddleViewModel _middleViewModel;
        private IFittingsTableViewModel _fittingsTableViewModel;
        private IChangeMaterialTableViewModel _changeMaterialTableViewModel;
        private IEdgeTapeTableViewModel _edgeTapeTableViewModel;
        private ICorpusViewModel _corpusViewModel;
        private IChangeMaterialCorpusViewModel _changeMaterialCorpusViewModel;
        private IFittingsCorpusViewModel _fittingsCorpusViewModel;
        private IEdgeTapeCorpusViewModel _edgeTapeCorpusViewModel;
        private IAddDetailViewModel _addDetailViewModel;
        private IOfferViewModel _offerViewModel;
        private ICustomerViewModel _customerViewModel;
        private IArticlesInOfferViewModel _articlesInOffer;

        public MainViewModel(IHomeViewModel homeViewModel, ITableViewModel tableViewModel, IMiddleViewModel middleViewModel, IFittingsTableViewModel fittingsTableViewModel,
            IChangeMaterialTableViewModel changeMaterialViewModel, IEdgeTapeTableViewModel edgeTapeTableViewModel, ILogInViewModel logInViewModel,
            ICorpusViewModel corpusVeiwModel, IChangeMaterialCorpusViewModel changeMaterialCorpusVIewModel, IFittingsCorpusViewModel fittingsCorpusViewModel,
            IEdgeTapeCorpusViewModel edgeTapeCorpusViewModel, IAddDetailViewModel addDetailViewModel, ICustomerViewModel customerViewModel,
            IOfferViewModel offerViewModel, IArticlesInOfferViewModel articlesInOffer)
        {
            _homeViewModel = homeViewModel;
            _homeViewModel.Started += homeViewModel_Started;
            _homeViewModel.Succeeded += homeViewModel_Succeeded;
            _homeViewModel.LogOut += homeViewModel_LogOut;
            _homeViewModel.Customer += homeViewModel_Customer;

            #region Table
            _tableViewModel = tableViewModel;
            _tableViewModel.Started += tableViewModel_Started;
            _tableViewModel.Succeeded += tableViewModel_Succeeded;
            _tableViewModel.ChangeMaterial += tableViewModel_ChangeMaterial;
            _tableViewModel.EdgeTape += tableViewModel_EdgeTape;
            _tableViewModel.Fittings += tableViewModel_Fittings;

            _middleViewModel = middleViewModel;
            _middleViewModel.Started += middleViewModel_Started;
            _middleViewModel.Succeeded += middleViewModel_Succeeded;
            _middleViewModel.Next += middleViewModel_Next;

            _fittingsTableViewModel = fittingsTableViewModel;
            _fittingsTableViewModel.Started += fittingsTableViewModel_Started;
            _fittingsTableViewModel.Succeeded += fittingsTableViewModel_Succeeded;

            _changeMaterialTableViewModel = changeMaterialViewModel;
            _changeMaterialTableViewModel.Started += changeMaterialTableViewModel_Started;
            _changeMaterialTableViewModel.Succeeded += changeMaterialTableViewModel_Succeeded;

            _edgeTapeTableViewModel = edgeTapeTableViewModel;
            _edgeTapeTableViewModel.Started += edgeTapeTableViewModel_Started;
            _edgeTapeTableViewModel.Succeeded += edgeTapeTableViewModel_Succeeded;
            #endregion

            _logInViewModel = logInViewModel;
            _logInViewModel.Started += logInViewModel_Started;
            _logInViewModel.Succeeded += logInViewModel_Succeeded;

            #region Corpus
            _corpusViewModel = corpusVeiwModel;
            _corpusViewModel.Started += corpusViewModel_Started;
            _corpusViewModel.Succeeded += corpusVeiwModel_Succeeded;
            _corpusViewModel.ChangeMaterial += corpusVeiwModel_ChangeMaterial;
            _corpusViewModel.EdgeTape += corpusVeiwModel_EdgeTape;
            _corpusViewModel.Fittings += corpusVeiwModel_Fittings;
            _corpusViewModel.AddDetail += corpusVeiwModel_AddDetail;

            _changeMaterialCorpusViewModel = changeMaterialCorpusVIewModel;
            _changeMaterialCorpusViewModel.Started += changeMaterialCorpusVIewModel_Started;
            _changeMaterialCorpusViewModel.Succeeded += changeMaterialCorpusVIewModel_Succeeded;

            _fittingsCorpusViewModel = fittingsCorpusViewModel;
            _fittingsCorpusViewModel.Started += fittingsCorpusViewModel_Started;
            _fittingsCorpusViewModel.Succeeded += fittingsCorpusViewModel_Succeeded;

            _edgeTapeCorpusViewModel = edgeTapeCorpusViewModel;
            _edgeTapeCorpusViewModel.Started += edgeTapeCorpusViewModel_Started;
            _edgeTapeCorpusViewModel.Succeeded += edgeTapeCorpusViewModel_Succeeded;

            _addDetailViewModel = addDetailViewModel;
            _addDetailViewModel.Started += addDetailViewModel_Started;
            _addDetailViewModel.Succeeded += addDetailViewModel_Succeeded;
            #endregion

            #region Offer
            _customerViewModel = customerViewModel;
            _customerViewModel.Started += customerViewModel_Started;
            _customerViewModel.Succeeded += customerViewModel_Succeeded;
            _customerViewModel.Offer += customerViewModel_Offer;

            _offerViewModel = offerViewModel;
            _offerViewModel.Started += offerViewModel_Started;
            _offerViewModel.Succeeded += offerViewModel_Succeeded;
            _offerViewModel.CheckOffer += offerViewModel_CheckOffer;

            _articlesInOffer = articlesInOffer;
            _articlesInOffer.Started += articlesInOffer_Started;
            _articlesInOffer.Succeeded += articlesInOffer_Succeeded;
            _articlesInOffer.Accept += articlesInOffer_Accept;
            #endregion

            setHomePageCurrent();
        }


        #region LogInView
        private void logInViewModel_Succeeded(object sender, UserEventArgs e)
        {
            _homeViewModel.Start(e.User);
        }

        private void logInViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _logInViewModel;
        }
        #endregion

        #region HomeView
        private void homeViewModel_Succeeded(object sender, EventArgs e)
        {
            switch (_homeViewModel.Result.Value)
            {
                case HomeViewModelResultType.RequestTable:
                    CurrentViewModel = null;
                    _middleViewModel.Start(HomeViewModelResultType.RequestTable, _homeViewModel.User);
                    break;
                case HomeViewModelResultType.RequestCorpus:
                    CurrentViewModel = null;
                    _middleViewModel.Start(HomeViewModelResultType.RequestCorpus, _homeViewModel.User);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void homeViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }

        private void homeViewModel_LogOut(object sender, EventArgs e)
        {
            _logInViewModel.Start();
            //CurrentViewModel = _logInViewModel;
        }

        private void homeViewModel_Customer(object sender, EventArgs e)
        {
            _customerViewModel.Start(_homeViewModel.User);
        }
        #endregion

        #region MiddleView
        private void middleViewModel_Next(object sender, EventArgs e)
        {
            switch (_homeViewModel.Result.Value)
            {
                case HomeViewModelResultType.RequestTable:
                    CurrentViewModel = null;
                    _tableViewModel.Start(_middleViewModel.Material, _middleViewModel.User);
                    break;
                case HomeViewModelResultType.RequestCorpus:
                    CurrentViewModel = null;
                    _corpusViewModel.Start(_middleViewModel.Material, _middleViewModel.User);
                    break;
                default:
                    break;
            }
        }

        private void middleViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
            //_homeViewModel.Start();
        }

        private void middleViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _middleViewModel;
        }
        #endregion

        #region TableView
        #region ChangeMaterialView
        private void changeMaterialTableViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _tableViewModel;
        }

        private void changeMaterialTableViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _changeMaterialTableViewModel;
        }
        #endregion
        #region EdgeTapeView
        private void edgeTapeTableViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _edgeTapeTableViewModel;
        }

        private void edgeTapeTableViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _tableViewModel;
        }
        #endregion
        #region FittingsView
        private void fittingsTableViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _tableViewModel;
        }

        private void fittingsTableViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _fittingsTableViewModel;
        }
        #endregion

        private void tableViewModel_ChangeMaterial(object sender, EventArgs e)
        {
            _changeMaterialTableViewModel.Start(_tableViewModel.Table);
        }

        private void tableViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }

        private void tableViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _tableViewModel;
        }

        private void tableViewModel_EdgeTape(object sender, EventArgs e)
        {
            _edgeTapeTableViewModel.Start(_tableViewModel.Table);
        }

        private void tableViewModel_Fittings(object sender, EventArgs e)
        {
            _fittingsTableViewModel.Start(_tableViewModel.Table);
        }
        #endregion

        #region CorpusView
        #region AddDetailView
        private void addDetailViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _corpusViewModel;
        }

        private void addDetailViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _addDetailViewModel;
        }
        #endregion
        #region FittingsView
        private void fittingsCorpusViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _corpusViewModel;
        }

        private void fittingsCorpusViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _fittingsCorpusViewModel;
        }
        #endregion
        #region ChangeMaterialView
        private void changeMaterialCorpusVIewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _changeMaterialCorpusViewModel;
        }

        private void changeMaterialCorpusVIewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _corpusViewModel;
        }
        #endregion
        #region EdgeTapeView
        private void edgeTapeCorpusViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _corpusViewModel;
        }

        private void edgeTapeCorpusViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _edgeTapeCorpusViewModel;
        }
        #endregion
        private void corpusVeiwModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }

        private void corpusViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _corpusViewModel;
        }

        private void corpusVeiwModel_AddDetail(object sender, EventArgs e)
        {
            _addDetailViewModel.Start(_corpusViewModel.Corpus, _corpusViewModel.Material);
        }

        private void corpusVeiwModel_Fittings(object sender, EventArgs e)
        {
            _fittingsCorpusViewModel.Start(_corpusViewModel.Corpus);
        }

        private void corpusVeiwModel_EdgeTape(object sender, EventArgs e)
        {
            _edgeTapeCorpusViewModel.Start(_corpusViewModel.Corpus);
        }

        private void corpusVeiwModel_ChangeMaterial(object sender, EventArgs e)
        {
            _changeMaterialCorpusViewModel.Start(_corpusViewModel.Corpus);
        }
        #endregion

        #region OfferView
        private void articlesInOffer_Accept(object sender, EventArgs e)
        {
            _offerViewModel.Accepted = true;
            CurrentViewModel = _offerViewModel;
        }

        private void articlesInOffer_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _articlesInOffer;
        }

        private void articlesInOffer_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _offerViewModel;
        }

        private void customerViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }

        private void customerViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _customerViewModel;
        }

        private void customerViewModel_Offer(object sender, EventArgs e)
        {
            _offerViewModel.Start(_customerViewModel.User, _customerViewModel.CivilCustomer, _customerViewModel.PublicCustomer);
        }

        private void offerViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _offerViewModel;
        }

        private void offerViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = _customerViewModel;
        }

        private void offerViewModel_CheckOffer(object sender, EventArgs e)
        {
            _articlesInOffer.Start(_offerViewModel.ElementsForOffer/*, ref _offerViewModel.Accepted*/);
        }
        #endregion

        #region SetHomePageCurrent
        private void setHomePageCurrent()
        {
            CurrentViewModel = null;
            _logInViewModel.Start();
        }
        #endregion
    }
}
