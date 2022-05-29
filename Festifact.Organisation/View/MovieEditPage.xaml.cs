namespace Festifact.Organisation;

public partial class MovieEditPage : ContentPage
{
	public MovieEditPage(MovieEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}