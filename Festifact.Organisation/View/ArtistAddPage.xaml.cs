namespace Festifact.Organisation;

public partial class ArtistAddPage : ContentPage
{
	public ArtistAddPage(ArtistAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

}