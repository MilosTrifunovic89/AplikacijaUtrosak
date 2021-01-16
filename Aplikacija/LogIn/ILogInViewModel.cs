using Aplikacija.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.LogIn
{
    public interface ILogInViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler<UserEventArgs> Succeeded;
        //event EventHandler<UserEventArgs> UserEvent;

        void Start();
    }
}
