using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

    public partial class ArtistViewModel : BaseViewModel
    {
    ArtistService artistService;
    public ArtistViewModel(ArtistService artistService)
    {
        Title = "Festifact";
        this.artistService = artistService;
    }

    [ObservableProperty]
    Artist artist;
}
