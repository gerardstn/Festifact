using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class MainpageViewModel : BaseViewModel
{

    FestivalService festivalService;
    public MainpageViewModel(FestivalService festivalService)
    {
        Title = "Festifact Organisation";
        this.festivalService = festivalService;
    }

    [ICommand]
    async Task ManageFestivals()
    {
        var route = $"{nameof(FestivalsPage)}";
        await Shell.Current.GoToAsync(route);
    }


}