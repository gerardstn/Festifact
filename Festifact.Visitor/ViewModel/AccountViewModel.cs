using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

public partial class AccountViewModel : BaseViewModel
{

    VisitorService visitorService;

    public AccountViewModel(VisitorService visitorService)
    {
        Title = "Account";
        this.visitorService = visitorService;
    }

    [ObservableProperty]
    Model.Visitor visitor;

    [ICommand]
    async Task Logout()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Preferences.Set("VisitorId", 0);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Login details: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"//MainPage";
            await Shell.Current.GoToAsync(route);
        }

    }

    [ICommand]
    async Task GetVisitor()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            visitor = await visitorService.GetVisitor(Preferences.Get("VisitorId", 0));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get account info: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [ICommand]
    async Task NavigateToVisitedFestivals()
    {
        var route = $"{nameof(VisitedFestivalsPage)}";
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    async Task NavigateToFavoriteArtists()
    {
        var route = $"{nameof(FavoriteArtistsPage)}";
        await Shell.Current.GoToAsync(route);
    }
    [ICommand]
    async Task NavigateToFavoriteShows()
    {
        var route = $"{nameof(FavoriteShowsPage)}";
        await Shell.Current.GoToAsync(route);
    }
}