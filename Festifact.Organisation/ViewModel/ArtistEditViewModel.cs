using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Artist), "Artist")]
public partial class ArtistEditViewModel : BaseViewModel
{

    [ObservableProperty]
    Artist artist;

    /*Save artist moet nog worden toegevoegd */

}
