using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class MainpageViewModel : BaseViewModel
{

    public MainpageViewModel()
    {
        Title = "Festifact Organisation";
    }

    [ICommand]
    async Task ManageFestivals()
    {
        var route = $"{nameof(FestivalsPage)}";
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    async Task ManageArtists()
    {
        var route = $"{nameof(ArtistsPage)}";
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    async Task ManageMovies()
    {
        var route = $"{nameof(MoviesPage)}";
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    async Task ManageLocations()
    {
        var route = $"{nameof(LocationsPage)}";
        await Shell.Current.GoToAsync(route);
    }
}
