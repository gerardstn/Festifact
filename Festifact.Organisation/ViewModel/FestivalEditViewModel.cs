using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Show), "Show")]
[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalEditViewModel : BaseViewModel
{
    public ObservableCollection<Show> Shows { get; } = new();

    ShowService showService;

    public FestivalEditViewModel(ShowService showService)
    {
        this.showService = showService;
    }

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetFestivalShowsAsync(int festivalId)
    {
        festivalId = 1;
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var shows = await showService.GetShows(festivalId);

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

}