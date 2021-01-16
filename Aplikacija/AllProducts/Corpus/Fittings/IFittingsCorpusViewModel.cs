using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Corpus.Fittings
{
    public interface IFittingsCorpusViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(CorpusClass corpus);
    }
}
