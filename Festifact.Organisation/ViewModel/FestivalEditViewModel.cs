using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalEditViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();
    public ObservableCollection<Show> Shows { get; } = new();

    FestivalService festivalService;
    public FestivalEditViewModel(FestivalService festivalService)
    {
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Festival festival;


}