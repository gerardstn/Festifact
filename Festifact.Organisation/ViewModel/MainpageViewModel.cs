using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class MainpageViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;

    public MainpageViewModel(FestivalService festivalService)
    {
        Title = "Festival Overview";
        this.festivalService = festivalService;
    }
    
    [ICommand]
    async Task GoToFestivalsManageOverviewPage()
    {
        var route = $"{nameof(FestivalsManageOverviewPage)}";
        await Shell.Current.GoToAsync(route);
    }

}