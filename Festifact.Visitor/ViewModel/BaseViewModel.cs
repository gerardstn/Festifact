namespace Festifact.Visitor.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string login;

    [ObservableProperty]
    string accountText;
    public bool IsNotBusy => !IsBusy;

    public Task SetAccountText()
    {
        if (Preferences.Get("VisitorId", 0) != 0)
        {
            AccountText = "Account";
            return Task.CompletedTask;
        }
        else
        {
            AccountText = "Login / Register";
            return Task.CompletedTask;
        }
    }

    [ICommand]
    async Task NavigateToAccount()
    {
        if (Preferences.Get("VisitorId", 0) != 0)
        {
            var route = $"{nameof(AccountPage)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            var route = $"{nameof(LoginPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }

}