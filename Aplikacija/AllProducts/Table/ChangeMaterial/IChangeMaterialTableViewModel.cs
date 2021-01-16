using Aplikacija.Base.ViewModel;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Table.ChangeMaterial
{
    public interface IChangeMaterialTableViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(TableClass table);
    }
}
