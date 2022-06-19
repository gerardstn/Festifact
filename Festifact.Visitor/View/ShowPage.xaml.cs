namespace Festifact.Visitor;

public partial class ShowPage : ContentPage
{
    public ShowPage(ShowViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ShowViewModel)BindingContext;
        await vm.SetAccountText();
        if (vm.Artist == null)
            await vm.GetShowArtistCommand.ExecuteAsync(null);
    }
}