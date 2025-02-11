using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaFormApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _username = string.Empty;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;
    
    [ObservableProperty]
    private bool _isLoadingVisible;

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        IsLoadingVisible = true;
        
        await Task.Delay(TimeSpan.FromSeconds(2));
        
        Greeting = $"Welcome, {Username}!";
        
        IsLoadingVisible = false;
    }
    
    private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
}