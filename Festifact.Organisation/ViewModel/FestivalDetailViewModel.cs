using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class FestivalDetailViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;
    public FestivalDetailViewModel(FestivalService festivalService)
    {
        Title = "Festival Finder";
        this.festivalService = festivalService;
    }


}
