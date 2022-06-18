namespace Festifact.Visitor;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}