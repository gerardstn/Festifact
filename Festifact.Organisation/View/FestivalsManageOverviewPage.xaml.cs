namespace Festifact.Organisation;

public partial class FestivalsManageOverviewPage : ContentPage
{
	public FestivalsManageOverviewPage(FestivalsManageOverviewViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}