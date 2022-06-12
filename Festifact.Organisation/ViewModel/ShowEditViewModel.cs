using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Show), (nameof(Show)))]
public partial class ShowEditViewModel : BaseViewModel
{
    public ShowEditViewModel(ShowService showService)
    {
        Title = "Edit show";
        Show = new();
        this.showService = showService;
    }

    ShowService showService;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Festival festival;

    [ICommand]
    async Task UpdateShowAsync(Show show)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await showService.UpdateShow(show);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Show: {ex.Message}");
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