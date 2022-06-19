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

}