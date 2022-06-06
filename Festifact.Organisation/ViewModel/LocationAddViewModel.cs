using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Model.Location), (nameof(Model.Location)))]
public partial class LocationAddViewModel : BaseViewModel
{
    public LocationAddViewModel(LocationService locationService)
    {
        Title = "Add Location";
        Location = new();
        this.locationService = locationService;
    }
    LocationService locationService;

    [ObservableProperty]
    Model.Location location;


    [ICommand]
    async Task AddLocationAsync(Model.Location location)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await locationService.AddLocation(location);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Location: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(LocationsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
