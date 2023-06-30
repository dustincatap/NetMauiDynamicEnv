using Autofac;
using MauiDemo.ViewModels;

namespace MauiDemo.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = AutofacBootstrapper.Scope.Resolve<MainViewModel>();
    }
}