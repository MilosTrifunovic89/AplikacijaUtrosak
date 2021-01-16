using Aplikacija.Base.ViewModel;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Corpus.EdgeTapes
{
    public interface IEdgeTapeCorpusViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(CorpusClass corpus);
    }
}
