namespace Festifact.Organisation;

public partial class PerformersPage : ContentPage
{
	public PerformersPage(PerformersViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}