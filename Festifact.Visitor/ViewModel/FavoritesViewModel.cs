using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Favorite), (nameof(Favorite)))]
public partial class FavoritesViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; } = new();
    public ObservableCollection<Show> Shows { get; } = new();

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
    Model.Visitor visitor;


    /*Get visitor favorite shows*/
    /*Get visitor favorite Artists*/
    /*Remove visitor favorite*/

}