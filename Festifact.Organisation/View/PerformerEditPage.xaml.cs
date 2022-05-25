namespace Festifact.Organisation;

public partial class PerformerEditPage : ContentPage
{
	public PerformerEditPage(PerformerEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}