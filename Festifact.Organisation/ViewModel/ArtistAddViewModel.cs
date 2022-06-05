using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class ArtistAddViewModel : BaseViewModel
{
    public ArtistAddViewModel()
    {
        Title = "Add artist";
    }
    [ObservableProperty]
    Artist artist;
}