using System.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Cookie_Clicker.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    private int _cookies = 00;
    private int _perClick = 1;

    [ObservableProperty]
    public partial int CookieCount {get; set;} = 0;

    public void OnCookieClick()
    {
        _cookies += _perClick;
        CookieCount = _cookies;
    }
    public void OnUpgradeClick()
    {
        if (_cookies >= 50)
        {
            _perClick += 5;
            _cookies -= 50;
        }
        CookieCount = _cookies;
    }
}
