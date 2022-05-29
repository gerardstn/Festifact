using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class ArtistsViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; } = new();

    ArtistService artistService;
    public ArtistsViewModel(ArtistService artistService)
    {
        Title = "Manage Artists";
        this.artistService = artistService;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetArtistsAsync()
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var artists = await artistService.GetArtists();

            Artists.Clear();
            foreach (var artist in artists)
                Artists.Add(artist);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Artists: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [ICommand]
    async Task AddArtistPage()
    {
        var route = $"{nameof(ArtistAddPage)}";
        await Shell.Current.GoToAsync(route);
    }
}