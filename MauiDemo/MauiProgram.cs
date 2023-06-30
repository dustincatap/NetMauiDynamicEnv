using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        IAppEnvironment? currentAppEnvironment = null;
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureEnvironment(appEnvironment => currentAppEnvironment = appEnvironment)
            .ConfigureContainer(new AutofacServiceProviderFactory(),
                containerBuilder =>
                {
                    AutofacBootstrapper.RegisterAutofacModules(containerBuilder, currentAppEnvironment!);
                });

#if !RELEASE
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}