using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Location), (nameof(Location)))]
public partial class LocationEditViewModel : BaseViewModel
{
    public ObservableCollection<Room> Rooms { get; set; } = new();


    LocationService locationService;
    RoomService roomService;

    public LocationEditViewModel(LocationService locationService, RoomService roomService)
    {
        this.locationService = locationService;
        this.roomService = roomService;
    }



    [ObservableProperty]
    Model.Location location;

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetLocationRoomsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var rooms = await roomService.GetRooms(location.LocationId);

            Rooms.Clear();
            foreach (var room in rooms)
                Rooms.Add(room);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Rooms: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

    [ICommand]
    async Task UpdateLocationAsync(Model.Location location)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await locationService.UpdateLocation(location);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Location: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(LocationsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }

    [ICommand]
    async Task AddRoomPage()
    {
        var route = $"{nameof(RoomAddPage)}";
        await Shell.Current.GoToAsync(route, true, new Dictionary<string, object>
    {
        {"Location", location }
    });
    }

}
