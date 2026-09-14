using System.Net;
using Avalonia.Controls;
using Avalonia.Input;
using Cookie_Clicker.ViewModels;

namespace Cookie_Clicker.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();

    }
}
