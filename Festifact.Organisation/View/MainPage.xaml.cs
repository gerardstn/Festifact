namespace Festifact.Organisation.View;

public partial class MainPage : ContentPage
{

    public MainPage(MainpageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async Task ManageFestivals()
    {
        await Shell.Current.GoToAsync(nameof(FestivalsPage));
    }
    async Task ManageArtists()
    {
        await Shell.Current.GoToAsync(nameof(ArtistsPage));
    }
    async Task ManageMovies()
    {
        await Shell.Current.GoToAsync(nameof(MoviesPage));
    }
    async Task ManageLocations()
    {
        await Shell.Current.GoToAsync(nameof(LocationsPage));
    }
}