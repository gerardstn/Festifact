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
            await vm.GetFavoriteArtistsCommand.ExecuteAsync(null);
    }
}