namespace Festifact.Organisation;

public partial class LocationAddPage : ContentPage
{
	public LocationAddPage(LocationAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}