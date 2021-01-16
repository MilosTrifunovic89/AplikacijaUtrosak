using Aplikacija.Base.ViewModel;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.AllProducts.Table.Fittings
{
    public interface IFittingsTableViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(TableClass table);
    }
}
