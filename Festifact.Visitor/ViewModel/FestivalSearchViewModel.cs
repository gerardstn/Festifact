using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalSearchViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;
    public FestivalSearchViewModel(FestivalService festivalService)
    {
        Title = "Search Festival";
        this.festivalService = festivalService;
    }
    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetFestivalsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var festivals = await festivalService.GetFestivals();

            Festivals.Clear();
            foreach (var festival in festivals)
                Festivals.Add(festival);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Festivals: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

}