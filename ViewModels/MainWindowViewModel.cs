using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaFormApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _username = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;

    [ObservableProperty] private bool _isLoadingVisible;

    [ObservableProperty] private int _loadingProgress;

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        Task loadingProgress = ProgressUp();
        
        IsLoadingVisible = true;

        await Task.Delay(TimeSpan.FromSeconds(2));

        await loadingProgress;

        IsLoadingVisible = false;
        
        Greeting = $"Welcome, {Username}!";
    }

    private async Task ProgressUp()
    {
        while (LoadingProgress < 100)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(20));
            LoadingProgress++;
        }
    }

    private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
}