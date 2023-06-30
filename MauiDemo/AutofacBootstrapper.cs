using Autofac;
using MauiDemo.ViewModels;

namespace MauiDemo;

public static class AutofacBootstrapper
{
    private static IComponentContext? _scope;

    public static IComponentContext Scope
    {
        get
        {
            if (_scope == null)
            {
                throw new InvalidOperationException("Autofac scope has not been initialized");
            }

            return _scope;
        }
    }

    public static void RegisterAutofacModules(ContainerBuilder builder, IAppEnvironment appEnvironment)
    {
        builder.RegisterBuildCallback(scope => _scope = scope);
        builder.RegisterModule(new EnvironmentModule(appEnvironment));
        builder.RegisterModule(new UiModule());
    }
}

public class EnvironmentModule : Module
{
    private readonly IAppEnvironment _appEnvironment;

    public EnvironmentModule(IAppEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(_appEnvironment).As<IAppEnvironment>().SingleInstance();
    }
}

public class UiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainViewModel>().AsSelf().InstancePerDependency();
    }
}