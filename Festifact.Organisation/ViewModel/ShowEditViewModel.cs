using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Show), "Show")]
public partial class ShowEditViewModel : BaseViewModel
{
    [ObservableProperty]
    Show show;
}