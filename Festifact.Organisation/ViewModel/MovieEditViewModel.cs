using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Movie), "Movie")]
public partial class MovieEditViewModel : BaseViewModel
{

    [ObservableProperty]
    Movie movie;

    /*Save movie moet nog worden toegevoegd */
}
