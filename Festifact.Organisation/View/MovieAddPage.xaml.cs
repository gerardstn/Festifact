namespace Festifact.Organisation;

public partial class MovieAddPage : ContentPage
{
	public MovieAddPage(MovieAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}