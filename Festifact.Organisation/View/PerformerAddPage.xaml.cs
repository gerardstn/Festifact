namespace Festifact.Organisation;

public partial class PerformerAddPage : ContentPage
{
	public PerformerAddPage(PerformerAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}