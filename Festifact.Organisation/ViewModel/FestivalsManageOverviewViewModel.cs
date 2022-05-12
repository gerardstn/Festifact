using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class FestivalsManageOverviewViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();
    FestivalService festivalService;
    public FestivalsManageOverviewViewModel(FestivalService festivalService)
    {
        Title = "Festival Finder";
        this.festivalService = festivalService;
    }

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
        }

    }

}
