using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Favorite), (nameof(Favorite)))]

public partial class ShowViewModel : BaseViewModel
{

    ShowService showService;
    ArtistService artistService;
    FavoriteService favoriteService;

    public ShowViewModel(ShowService showService, ArtistService artistService, FavoriteService favoriteService)
    {
        Favorite favorite = new();
        this.showService = showService;
        this.artistService = artistService;
        this.favoriteService = favoriteService;
    }

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Artist artist;

    [ObservableProperty]
    Favorite favorite;


    [ObservableProperty]
    string favoriteShowState;


    public Task setFavoriteShowStateText(string text)
    {
            favoriteShowState = text;
            return Task.CompletedTask;
    }

    [ICommand]
    async Task AddShowToFavorites()
    {
        if (IsBusy)
            return;
        if(Preferences.Get("VisitorId", 0) == 0)
        {
            var route = $"{nameof(LoginPage)}";
            await Shell.Current.GoToAsync(route);
            return;
        }
        try
        {
            IsBusy = true;
            if(favorite == null)
            favorite = await favoriteService.AddShowFavorite(Show.ShowId);
            else
                await Application.Current.MainPage.DisplayAlert("Alert", "This show is already in your favorites", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add show to favorites: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [ICommand]
    async Task GetShowArtist()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Artist = await artistService.GetShowArtist(Show.ArtistId);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get artist from show: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [ICommand]
    async Task NavigateToArtist()
    {
        var route = $"{nameof(ArtistPage)}";
        await Shell.Current.GoToAsync(route, true, new Dictionary<string, object>
    {
        {"Artist", artist }
    });
    }

    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}