using Festifact.Visitor.Services;
using System.Linq;

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
            var favorites = await favoriteService.GetFavoriteShows();

            Shows.Clear();
            foreach (var favorite in favorites)
            Shows.Add(await showService.GetShowById((int)favorite.ShowId));
            Favorites.Add(favorite);

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
            var favorites = await favoriteService.GetFavoriteArtists();

            Favorites.Clear();
            foreach (var favorite in favorites)
            Artists.Add(await artistService.GetArtist((int)favorite.ArtistId));
                Favorites.Add(favorite);
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
    async void DeleteShow (Show show)
    {
        if (Shows.Contains(show))
        {
            var favorites = await favoriteService.GetFavoriteShows();
            foreach (var favorite in favorites)
                if(favorite.ShowId.Equals(show.ShowId))
                    await favoriteService.RemoveFavorite(favorite);
            Shows.Remove(show);
        }
    }

    [ICommand]
    async void DeleteArtist(Artist artist)
    {
        if (Artists.Contains(artist))
        {
            var favorites = await favoriteService.GetFavoriteArtists();
            foreach (var favorite in favorites)
                if (favorite.ArtistId.Equals(artist.ArtistId))
                    await favoriteService.RemoveFavorite(favorite);
            Artists.Remove(artist);
        }
    }


}