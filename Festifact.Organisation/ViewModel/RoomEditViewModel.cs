using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Room), (nameof(Room)))]
public partial class RoomEditViewModel : BaseViewModel
{
    [ObservableProperty]
    Room room;
}