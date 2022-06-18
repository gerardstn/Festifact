using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]

public partial class ShowViewModel : BaseViewModel
{

    ShowService showService;
    ArtistService artistService;

    public ShowViewModel(ShowService showService, ArtistService artistService)
    {
        this.showService = showService;
        this.artistService = artistService;
    }

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Artist artist;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetShowArtist()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Artist = await artistService.GetShowArtist(Show.ArtistId);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get artist from show: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

    [ICommand]
    async Task NavigateToArtist()
    {
        var route = $"{nameof(ArtistPage)}";
        await Shell.Current.GoToAsync(route, true, new Dictionary<string, object>
    {
        {"Artist", artist }
    });
    }

    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}