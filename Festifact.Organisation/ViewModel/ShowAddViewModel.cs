using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Room), (nameof(Room)))]
[QueryProperty(nameof(Movie), (nameof(Movie)))]

public partial class ShowAddViewModel : BaseViewModel
{ 
    public ShowAddViewModel(ShowService showService)
    {
        Title = "Add Show";
        Show = new();
        this.showService = showService;
    }
    ShowService showService;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Festival festival;

    [ICommand]
    async Task AddShowAsync(Show show)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await showService.AddShow(show, festival);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Show: {ex.Message}");
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