using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Show), (nameof(Show)))]
public partial class ArtistViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();

    ShowService showService;
    ArtistService artistService;
    public ArtistViewModel(ArtistService artistService, ShowService showService)
    {
        this.artistService = artistService;
        this.showService = showService;
    }


    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Artist artist;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}