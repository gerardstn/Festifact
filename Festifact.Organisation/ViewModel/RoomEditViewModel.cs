using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Room), (nameof(Room)))]
public partial class RoomEditViewModel : BaseViewModel
{
    public RoomEditViewModel(RoomService roomService)
    {
        Title = "Edit room";
        Room = new();
        this.roomService = roomService;
    }

    RoomService roomService;

    [ObservableProperty]
    Room room;



    [ICommand]
    async Task UpdateRoomAsync(Room room)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await roomService.UpdateRoom(room);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Room: {ex.Message}");
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