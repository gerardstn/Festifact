namespace Festifact.Organisation;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(ArtistsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}