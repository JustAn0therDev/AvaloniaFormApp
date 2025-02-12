using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

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
        Messenger.Send(new LoginEvent(Username));
        
        await Task.Delay(TimeSpan.FromSeconds(2));

        Messenger.Send(new LoginEvent(Username));
    }

    private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
}

public record LoginEvent(string Username);