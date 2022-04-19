using Festifact.Organisation.ViewModel;

namespace Festifact.Organisation;

public partial class FestivalOverviewPage : ContentPage
{
	public FestivalOverviewPage(FestivalOverviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}