using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Artist), (nameof(Artist)))]
public partial class ArtistEditViewModel : BaseViewModel
{
    public ArtistEditViewModel(ArtistService artistService)
    {
        Title = "Edit artist";
        Artist = new();
        this.artistService = artistService;
    }

    ArtistService artistService;

    [ObservableProperty]
    Artist artist;

    [ICommand]
    async Task UpdateArtistAsync(Artist artist)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await artistService.UpdateArtist(artist);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Artist: {ex.Message}");
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
