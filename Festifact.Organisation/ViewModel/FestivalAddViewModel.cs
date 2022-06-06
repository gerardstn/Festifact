using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
public partial class FestivalAddViewModel : BaseViewModel
{

    FestivalService festivalService;
    public FestivalAddViewModel(FestivalService festivalService)
    {
        Title = "Add Festival";
        Festival = new();
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task AddFestivalAsync(Festival festival)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await festivalService.AddFestival(festival);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Festival: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(FestivalsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}