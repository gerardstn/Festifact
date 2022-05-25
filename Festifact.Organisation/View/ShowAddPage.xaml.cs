namespace Festifact.Organisation;

public partial class ShowAddPage : ContentPage
{
	public ShowAddPage(ShowEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var show = e.CurrentSelection.FirstOrDefault() as Show;
        if (show == null)
            return;

        await Shell.Current.GoToAsync(nameof(ShowAddPage), true, new Dictionary<string, object>
    {
        {"Show", show }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

}