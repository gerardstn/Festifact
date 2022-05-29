namespace Festifact.Organisation;

public partial class LocationsPage : ContentPage
{
	public LocationsPage(LocationsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var location = e.CurrentSelection.FirstOrDefault() as Model.Location;
        if (location == null)
            return;

        await Shell.Current.GoToAsync(nameof(LocationEditPage), true, new Dictionary<string, object>
    {
        {"Location", location }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (LocationsViewModel)BindingContext;
        if (vm.Locations.Count == 0)
            await vm.GetLocationsCommand.ExecuteAsync(null);
    }
}