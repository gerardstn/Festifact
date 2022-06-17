namespace Festifact.Visitor;

public partial class ArtistPage : ContentPage
{
    public ArtistPage(ArtistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}