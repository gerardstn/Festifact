using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Location), "Location")]
public partial class LocationEditViewModel : BaseViewModel
{

    [ObservableProperty]
    Model.Location location;

    /*Save location moet nog worden toegevoegd */

}
