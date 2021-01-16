using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.Offer.Customer
{
    public interface ICustomerViewModel : IViewModel
    {
        CivilCustomer CivilCustomer { get; set; }
        PublicCustomer PublicCustomer { get; set; }
        User User { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler Offer;

        void Start(User user);
    }
}
