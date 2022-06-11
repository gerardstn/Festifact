namespace Festifact.Organisation;

public partial class RoomAddPage : ContentPage
{
	public RoomAddPage(RoomAddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var room = e.CurrentSelection.FirstOrDefault() as Room;
        if (room == null)
            return;

        await Shell.Current.GoToAsync(nameof(RoomAddPage), true, new Dictionary<string, object>
    {
        {"Room", room }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

}