using System;
using System.Threading;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Cookie_Clicker.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    private double _cookies = 0;
    private double _perClick = 1;
    private int _baseCost = 15;
    private int _forUpgrade = 15;

    private int _upgradeLevel = 0;

    private double _cps = 0;
    private int _cpsBaseCost = 15;
    private int _cpsForUpgrade = 15;
    private int _cpsUpgradeLevel = 0;

    private readonly DispatcherTimer _timer;

    [ObservableProperty]
    public partial double CookieCount { get; set; } = 0;

    [ObservableProperty]
    public partial double PerClick { get; set; } = 1;
    [ObservableProperty]
    public partial int UpgradePrice { get; set; } = 15;
    [ObservableProperty]
    public partial int UpgradeLevel { get; set; } = 0;

    [ObservableProperty]
    public partial double Cps { get; set; } = 0;
    [ObservableProperty]
    public partial double CpsUpgradePrice { get; set; } = 15;
    [ObservableProperty]
    public partial double CpsUpgradeLevel { get; set; } = 0;

    public MainViewModel()
    {
        _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Background, (s, e) =>
        {
            OnTimerTick();
        });
        _timer.Start();
    }

    public void OnCookieClick()
    {
        _cookies += _perClick;
        CookieCount = _cookies;
    }
    public void OnUpgradeClick()
    {
        if (_cookies >= _forUpgrade)
        {
            _upgradeLevel += 1;
            _perClick += 0.1;
            _cookies -= _forUpgrade;
            _forUpgrade = (int)Math.Round(_baseCost * Math.Pow(1.1, _upgradeLevel + 1));
            UpgradePrice = _forUpgrade;
            UpgradeLevel = _upgradeLevel;
            PerClick = _perClick;
        }
        CookieCount = _cookies;
    }
    public void OnUpgradeCpsClick()
    {
        if (_cookies >= _cpsForUpgrade)
        {
            _cpsUpgradeLevel += 1;
            _cps += 0.1;
            _cookies -= _cpsForUpgrade;
            _cpsForUpgrade = (int)Math.Round(_cpsBaseCost * Math.Pow(1.1, _cpsUpgradeLevel + 1));
            CpsUpgradePrice = _cpsForUpgrade;
            CpsUpgradeLevel = _cpsUpgradeLevel;
            Cps = _cps;
        }
        CookieCount = _cookies;
    }

    public void OnTimerTick() {
        _cookies += _cps;
        CookieCount = _cookies;
    }

    public void TimerStop() => _timer.Stop();

}
