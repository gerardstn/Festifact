using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Favorite), (nameof(Favorite)))]
public partial class FavoritesViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; } = new();
    public ObservableCollection<Show> Shows { get; } = new();
    public ObservableCollection<Favorite> Favorites { get; } = new();


    ShowService showService;
    ArtistService artistService;
    FavoriteService favoriteService;

    public FavoritesViewModel(ShowService showService, ArtistService artistService, FavoriteService favoriteService)
    {
        Title = "Favorite artists and shows";
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
    Model.Visitor visitor;


    [ICommand]
    async Task GetFavoriteShows()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var shows = await favoriteService.GetFavoriteShows();

            Shows.Clear();
            foreach (var show in shows)
                Shows.Add(show);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get favorite Shows: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [ICommand]
    async Task GetFavoriteArtists()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var artists = await favoriteService.GetFavoriteArtists();
            Artists.Clear();
            foreach (var artist in artists)
                Artists.Add(artist);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get favorite Artists: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }



    [ICommand]
    async Task RemoveFavorite()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            await favoriteService.RemoveFavorite(favorite);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Login details: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}