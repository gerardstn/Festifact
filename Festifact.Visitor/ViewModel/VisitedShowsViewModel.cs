using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

public partial class VisitedShowsViewModel : BaseViewModel
{
    ShowService showService;
    public VisitedShowsViewModel(ShowService showService)
    {
        Title = "Your visited shows";
        this.showService = showService;
    }

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Model.Visitor visitor;

    /*Ratingservice maken*/
    /*Shows ophalen waar hij/zij een ticket van heeft gehad na datetime.now*/
    /*Post maken met een rating*/

}