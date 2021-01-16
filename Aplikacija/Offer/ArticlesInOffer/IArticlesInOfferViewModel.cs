using Aplikacija.Base.ViewModel;
using Domain.Offer;
using System;
using System.Collections.ObjectModel;

namespace Aplikacija.Offer.ArticlesInOffer
{
    public interface IArticlesInOfferViewModel : IViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler Accept;

        void Start(ObservableCollection<OfferProduct> offerProducts/*, ref bool Accepted*/);        
    }
}
