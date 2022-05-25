namespace Festifact.Organisation;

public partial class LocationEditPage : ContentPage
{
	public LocationEditPage(LocationEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}