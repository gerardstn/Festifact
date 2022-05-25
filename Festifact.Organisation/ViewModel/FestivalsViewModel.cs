using Festifact.Organisation.Services;
using Festifact.Organisation.Infrastructure;

namespace Festifact.Organisation.ViewModel;

public partial class FestivalsViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;
    public FestivalsViewModel(FestivalService festivalService)
    {
        Title = "Manage Festivals";
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetFestivalsAsync()
    {
        int OrganisationId = Globals.OrganisationId;

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var festivals = await festivalService.GetFestivals(OrganisationId);

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

    [ICommand]
    async Task AddFestivalPage()
    {
        var route = $"{nameof(FestivalAddPage)}";
        await Shell.Current.GoToAsync(route);
    }
}