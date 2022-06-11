using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Show), nameof(Show))]
[QueryProperty(nameof(Festival), nameof(Festival))]
public partial class FestivalEditViewModel : BaseViewModel
{
    public ObservableCollection<Show> Shows { get; set; } = new();

    ShowService showService;
    FestivalService festivalService;

    public FestivalEditViewModel(ShowService showService, FestivalService festivalService)
    {
        this.showService = showService;
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetFestivalShowsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var shows = await showService.GetShows(festival.FestivalId);

            Shows.Clear();
            foreach (var show in shows)
                Shows.Add(show);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Shows: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

    [ICommand]
    async Task UpdateFestivalAsync(Festival festival)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await festivalService.UpdateFestival(festival);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Festival: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(FestivalsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }

    [ICommand]
    async Task AddShowPage()
    {
        var route = $"{nameof(ShowAddPage)}";
        await Shell.Current.GoToAsync(route, true, new Dictionary<string, object>
    {
        {"Festival", festival }
    });
    }
}