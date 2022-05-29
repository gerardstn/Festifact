namespace Festifact.Organisation;

public partial class ArtistEditPage : ContentPage
{
	public ArtistEditPage(ArtistEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}