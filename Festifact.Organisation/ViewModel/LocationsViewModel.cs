using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class LocationsViewModel : BaseViewModel
{

    public ObservableCollection<Model.Location> Locations { get; } = new();

    LocationService locationService;
    public LocationsViewModel(LocationService locationService)
    {
        Title = "Manage Locations";
        this.locationService = locationService;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetLocationsAsync()
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var locations = await locationService.GetLocations();

            Locations.Clear();
            foreach (var location in locations)
                Locations.Add(location);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Locations: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [ICommand]
    async Task AddLocationPage()
    {
        var route = $"{nameof(LocationAddPage)}";
        await Shell.Current.GoToAsync(route);
    }

}
