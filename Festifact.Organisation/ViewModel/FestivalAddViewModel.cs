using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalAddViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;
    public FestivalAddViewModel(FestivalService festivalService)
    {
        Title = "Add Festival";
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    bool isRefreshing;

}