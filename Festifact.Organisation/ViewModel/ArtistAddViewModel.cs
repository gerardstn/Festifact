using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Artist), (nameof(Artist)))]
public partial class ArtistAddViewModel : BaseViewModel
{
    public ArtistAddViewModel(ArtistService artistService)
    {
        Title = "Add artist";
        Artist = new();
        this.artistService = artistService;
    }

    ArtistService artistService;

    [ObservableProperty]
    Artist artist;

    [ICommand]
    async Task AddArtistAsync(Artist artist)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await artistService.AddArtist(artist);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Artist: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(ArtistsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}