using Aplikacija.Base.ViewModel;
using Aplikacija.Home;
using Domain;
using System;

namespace Aplikacija.MiddleWindow
{
    public interface IMiddleViewModel : IContainerViewModel
    {
        Material Material { get; }
        User User { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler Next;

        void Start(HomeViewModelResultType result, User user);
    }
}
