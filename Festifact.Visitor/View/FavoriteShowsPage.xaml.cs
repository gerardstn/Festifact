namespace Festifact.Visitor;

public partial class FavoriteShowsPage : ContentPage
{
    public FavoriteShowsPage(FavoritesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FavoritesViewModel)BindingContext;
        await vm.SetAccountText();
        await vm.GetFavoriteShowsCommand.ExecuteAsync(null);
    }
}