using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplikacija.Home;
using Aplikacija.Main;
using System;
using System.Windows;
using Aplikacija.AllProducts.Table.Main;
using Aplikacija.MiddleWindow;
using Aplikacija.AllProducts.Table.Fittings;
using Aplikacija.AllProducts.Table.ChangeMaterial;
using Aplikacija.AllProducts.Table.EdgeTapes;
using Aplikacija.LogIn;
using Aplikacija.AllProducts.Corpus.Main;
using Aplikacija.AllProducts.Corpus.ChangeMaterial;
using Aplikacija.AllProducts.Corpus.Fittings;
using Aplikacija.AllProducts.Corpus.EdgeTapes;
using Aplikacija.AllProducts.Corpus.Details;
using Aplikacija.Offer.Customer;
using Aplikacija.Offer.Main;
using Aplikacija.Offer.ArticlesInOffer;

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration ConfigurationProvider { get; private set; }

        public App()
        {
            ServiceProvider = createServiceProvider(ConfigurationProvider);
        }

        private IServiceProvider createServiceProvider(IConfiguration configuration)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();
            serviceCollection.AddTransient<IHomeViewModel, HomeViewModel>();
            serviceCollection.AddTransient<ITableViewModel, TableViewModel>();
            serviceCollection.AddTransient<IMiddleViewModel, MiddleViewModel>();
            serviceCollection.AddTransient<IFittingsTableViewModel, FittingsTableViewModel>();
            serviceCollection.AddTransient<IChangeMaterialTableViewModel, ChangeMaterialTableViewModel>();            
            serviceCollection.AddTransient<IEdgeTapeTableViewModel, EdgeTapeTableViewModel>();            
            serviceCollection.AddTransient<ILogInViewModel, LogInViewModel>();
            serviceCollection.AddTransient<IChangeMaterialTableViewModel, ChangeMaterialTableViewModel>();
            serviceCollection.AddTransient<ICorpusViewModel, CorpusViewModel>();
            serviceCollection.AddTransient<IChangeMaterialCorpusViewModel, ChangeMaterialCorpusViewModel>();
            serviceCollection.AddTransient<IFittingsCorpusViewModel, FittingsCorpusViewModel>();
            serviceCollection.AddTransient<IEdgeTapeCorpusViewModel, EdgeTapeCorpusViewModel>();
            serviceCollection.AddTransient<IAddDetailViewModel, AddDetailViewModel>();
            serviceCollection.AddTransient<ICustomerViewModel, CustomerViewModel>();
            serviceCollection.AddTransient<IOfferViewModel, OfferViewModel>();
            serviceCollection.AddTransient<IArticlesInOfferViewModel, ArticlesInOfferViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
