namespace Festifact.Organisation;

public partial class LocationEditPage : ContentPage
{
	public LocationEditPage(LocationEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var room = e.CurrentSelection.FirstOrDefault() as Room;
        if (room == null)
            return;

        await Shell.Current.GoToAsync(nameof(RoomEditPage), true, new Dictionary<string, object>
    {
        {"Room", room }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (LocationEditViewModel)BindingContext;
        if (vm.Rooms.Count == 0)
            await vm.GetLocationRoomsCommand.ExecuteAsync(null);
    }


}