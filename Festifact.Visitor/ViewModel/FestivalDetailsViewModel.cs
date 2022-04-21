namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalDetailsViewModel : BaseViewModel
{
    public FestivalDetailsViewModel()
    {
    }

    [ObservableProperty]
    Festival festival;
}
