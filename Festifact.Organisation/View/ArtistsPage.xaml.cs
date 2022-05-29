namespace Festifact.Organisation;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(ArtistsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var artist = e.CurrentSelection.FirstOrDefault() as Artist;
        if (artist == null)
            return;

        await Shell.Current.GoToAsync(nameof(ArtistEditPage), true, new Dictionary<string, object>
    {
        {"Artist", artist }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ArtistsViewModel)BindingContext;
        if (vm.Artists.Count == 0)
            await vm.GetArtistsCommand.ExecuteAsync(null);
    }
}