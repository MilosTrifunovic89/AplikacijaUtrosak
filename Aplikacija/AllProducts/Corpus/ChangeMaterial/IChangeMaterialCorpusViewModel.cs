using Aplikacija.Base.ViewModel;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Corpus.ChangeMaterial
{
    public interface IChangeMaterialCorpusViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(CorpusClass corpus);
    }
}
