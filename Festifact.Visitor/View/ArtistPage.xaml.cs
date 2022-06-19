namespace Festifact.Visitor;

public partial class ArtistPage : ContentPage
{
    public ArtistPage(ArtistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ArtistViewModel)BindingContext;
        await vm.SetAccountText();
    }
}