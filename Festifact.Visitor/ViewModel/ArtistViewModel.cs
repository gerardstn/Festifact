using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Favorite), (nameof(Favorite)))]
public partial class ArtistViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();

    ShowService showService;
    ArtistService artistService;
    FavoriteService favoriteService;
    public ArtistViewModel(ArtistService artistService, ShowService showService, FavoriteService favoriteService)
    {
        this.artistService = artistService;
        this.showService = showService;
        this.favoriteService = favoriteService;
    }


    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Artist artist;

    [ObservableProperty]
    Favorite favorite;

    [ICommand]
    async Task AddArtistToFavorites()
    {
        if (IsBusy)
            return;
        if (Preferences.Get("VisitorId", 0) == 0)
        {
            var route = $"{nameof(LoginPage)}";
            await Shell.Current.GoToAsync(route);
            return;
        }
        try
        {
            IsBusy = true;
            if (favorite == null)
                favorite = await favoriteService.AddArtistFavorite(Artist.ArtistId);
            else
                await Application.Current.MainPage.DisplayAlert("Alert", "This Artist is already in your favorites", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Artist to favorites: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}