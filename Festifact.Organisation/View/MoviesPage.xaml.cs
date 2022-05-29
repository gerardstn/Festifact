namespace Festifact.Organisation;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}