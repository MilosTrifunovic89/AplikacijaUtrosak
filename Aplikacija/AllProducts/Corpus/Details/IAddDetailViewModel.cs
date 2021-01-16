using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Corpus.Details
{
    public interface IAddDetailViewModel : IContainerViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start(CorpusClass corpus, Material material);
    }
}
