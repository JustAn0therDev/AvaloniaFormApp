using Avalonia.Controls;
using AvaloniaFormApp.ViewModels;

namespace AvaloniaFormApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        LoadingGrid.DataContext = new LoadingViewModel();
    }
}