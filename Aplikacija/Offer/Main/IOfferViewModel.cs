                                                                                                                                using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Customer;
using Domain.Offer;
using System;
using System.Collections.ObjectModel;

namespace Aplikacija.Offer.Main
{
    public interface IOfferViewModel : IViewModel
    {
        ObservableCollection<OfferProduct> ElementsForOffer { get; set; }
        bool Accepted { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler CheckOffer;

        void Start(User user, CivilCustomer civilCustomer, PublicCustomer publicCustomer);
    }
}
