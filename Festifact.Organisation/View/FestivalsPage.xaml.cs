namespace Festifact.Organisation;

public partial class FestivalsPage : ContentPage
{
	public FestivalsPage(FestivalsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}