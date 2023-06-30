using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDemo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAppEnvironment _appEnvironment;

    public MainViewModel(IAppEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CounterText))]
    private int _counter;

    public string CounterText => $"Clicked {Counter} times";

    public string Title => _appEnvironment.AppName;

    [RelayCommand]
    private void Increment()
    {
        Counter++;
    }
}