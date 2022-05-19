namespace Festifact.Organisation;

public partial class FestivalDetailPage : ContentPage
{
	public FestivalDetailPage(FestivalDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}