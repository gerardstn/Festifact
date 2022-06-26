namespace Festifact.Visitor;

public partial class RateFestivalPage : ContentPage
{
    public RateFestivalPage(RateFestivalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


}