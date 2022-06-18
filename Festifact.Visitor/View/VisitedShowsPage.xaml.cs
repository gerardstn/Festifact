namespace Festifact.Visitor;

public partial class VisitedShowsPage : ContentPage
{
    public VisitedShowsPage(VisitedShowsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}