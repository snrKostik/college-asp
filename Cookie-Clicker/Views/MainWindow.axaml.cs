using System;
using System.Net;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using Cookie_Clicker.ViewModels;

namespace Cookie_Clicker.Views;

public partial class MainWindow : Window
{
    private readonly MainViewModel _vm = new();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = _vm;
        // var timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Background, (s,e) => {
        //
        //         // Console.WriteLine("1 sec");
        //
        //
        //         });
        // timer.Start();

    }
    protected override void OnClosed(EventArgs e)
    {
        _vm.TimerStop();
        base.OnClosed(e);
    }
}
