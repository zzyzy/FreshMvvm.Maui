using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace FreshMvvm.Maui.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseFreshMvvm(this MauiAppBuilder app)
    {
        app.Services.AddSingleton<IPageModelCoreMethodsFactory, DefaultPageModelCoreMethodsFactory>();
        app.Services.AddSingleton<IFreshPageModelMapper, FreshPageModelMapper>();
        return app;
    }
}