namespace Festifact.Visitor;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}