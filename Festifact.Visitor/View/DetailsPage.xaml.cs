namespace Festifact.Visitor;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(FestivalDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}