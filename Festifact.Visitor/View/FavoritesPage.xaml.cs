namespace Festifact.Visitor;

public partial class FavoritesPage : ContentPage
{
    public FavoritesPage(FavoritesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FavoritesViewModel)BindingContext;
        await vm.SetAccountText();
        if (vm.Favorites.Count == 0)
            await vm.GetFavoriteShowsCommand.ExecuteAsync(null);
            await vm.GetFavoriteArtistsCommand.ExecuteAsync(null);
    }
}