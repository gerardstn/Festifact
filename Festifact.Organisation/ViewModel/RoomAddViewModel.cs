using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

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


    [ICommand]
    async Task AddRoomAsync(Room room)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await roomService.AddRoom(room);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Room: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(FestivalEditPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }

}