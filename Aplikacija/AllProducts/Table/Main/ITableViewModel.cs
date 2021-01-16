using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.AllProducts.Table.Main
{
    public interface ITableViewModel : IContainerViewModel
    {
        TableClass Table { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler ChangeMaterial;
        event EventHandler EdgeTape;
        event EventHandler Fittings;

        void Start(Material material, User user);
    }
}
