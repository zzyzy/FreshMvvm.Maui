using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace FreshMvvm.Maui.IOC
{
    public static class DependancyService
    {
        public static IServiceProvider Services => Application.Current!.Handler!.MauiContext!.Services;
        
        /// <summary>
        /// Returns a resolved instance of the requested type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : class
        {
            var result = Services.GetRequiredService<T>();

            return result;
        }

        public static object Resolve(Type serviceType)
        {
            var result = Services.GetRequiredService(serviceType);

            return result;
        }
    }
}

