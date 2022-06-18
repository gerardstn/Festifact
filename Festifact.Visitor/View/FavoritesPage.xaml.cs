namespace Festifact.Visitor;

public partial class FavoritesPage : ContentPage
{
    public FavoritesPage(FavoritesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}