namespace Festifact.Visitor;

public partial class FavoriteArtistsPage : ContentPage
{
    public FavoriteArtistsPage(FavoritesViewModel viewModel)
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
            await vm.GetFavoriteArtistsCommand.ExecuteAsync(null);
    }
}