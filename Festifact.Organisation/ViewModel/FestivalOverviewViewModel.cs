using CommunityToolkit.Mvvm.ComponentModel;
using Festifact.Organisation.Model;

namespace Festifact.Organisation.ViewModel;

public class FestivalOverviewViewModel : BaseViewModel
{
    [ObservableProperty]
    Festival festival;
}