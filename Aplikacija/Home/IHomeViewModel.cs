using Aplikacija.Base.ViewModel;
using Domain;
using DomainEntity;
using System;

namespace Aplikacija.Home
{
    public interface IHomeViewModel : IViewModel
    {
        HomeViewModelResultType? Result { get; }
        User User { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler LogOut;
        event EventHandler Customer;

        void Start(User user);
    }
}
