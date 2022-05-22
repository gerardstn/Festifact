namespace Festifact.Organisation;

public partial class FestivalAddPage : ContentPage
{
	public FestivalAddPage(FestivalEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


}