using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Location), (nameof(Location)))]
[QueryProperty(nameof(Room), (nameof(Room)))]
public partial class RoomAddViewModel : BaseViewModel
{
    public RoomAddViewModel(RoomService roomService)
    {
        Title = "Add Room";
        Room = new();
        this.roomService = roomService;
    }
    RoomService roomService;

    [ObservableProperty]
    Room room;

    [ObservableProperty]
    Model.Location location;

    [ICommand]
    async Task AddRoomAsync(Room room)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await roomService.AddRoom(room, location);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Room: {ex.Message}");
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