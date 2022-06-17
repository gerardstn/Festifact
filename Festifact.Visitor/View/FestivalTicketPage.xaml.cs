namespace Festifact.Visitor;

public partial class FestivalTicketPage : ContentPage
{
    public FestivalTicketPage(FestivalTicketViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}