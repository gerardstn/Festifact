namespace Festifact.Organisation;

public partial class FestivalAddPage : ContentPage
{
	public FestivalAddPage(FestivalAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


}