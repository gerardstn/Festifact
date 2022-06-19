using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;


[QueryProperty(nameof(Visitor), (nameof(Visitor)))]
public partial class LoginViewModel : BaseViewModel
{

    VisitorService visitorService;

    public LoginViewModel(VisitorService visitorService)
    {
        Visitor = new();
        Title = "Login";
        this.visitorService = visitorService;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    Model.Visitor visitor;

    [ICommand]
    async Task CheckLoginDetails(Model.Visitor visitor)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            visitor = await visitorService.GetVisitorLogin(visitor.Email, visitor.Password);
            if (visitor.VisitorId == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Account not found.", "OK");
                IsBusy = false;
                isRefreshing = false;
                return;
            }
            Preferences.Set("VisitorId", visitor.VisitorId);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Login details: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
            var route = $"//MainPage";
            await Shell.Current.GoToAsync(route);
        }

    }

    [ICommand]
    async Task NavigateToRegister()
    {
        var route = $"{nameof(RegisterPage)}";
        await Shell.Current.GoToAsync(route);
    }
}