namespace Festifact.Organisation;

public partial class LocationsPage : ContentPage
{
	public LocationsPage(LocationsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}