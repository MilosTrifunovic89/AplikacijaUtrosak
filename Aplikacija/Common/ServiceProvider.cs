using System;
using System.Windows;

namespace Aplikacija.Common
{
    public static class ServiceProvider
    {
        public static IServiceProvider Instance
        {
            get
            {
                return (Application.Current as App).ServiceProvider;
            }
        }
    }
}
