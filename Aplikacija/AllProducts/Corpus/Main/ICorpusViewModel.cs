using Aplikacija.Base.ViewModel;
using Domain;
using Domain.Products;
using System;

namespace Aplikacija.AllProducts.Corpus.Main
{
    public interface ICorpusViewModel : IContainerViewModel
    {
        CorpusClass Corpus { get; set; }
        Material Material { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler AddDetail;
        event EventHandler ChangeMaterial;
        event EventHandler EdgeTape;
        event EventHandler Fittings;

        void Start(Material material, User user);
    }
}
