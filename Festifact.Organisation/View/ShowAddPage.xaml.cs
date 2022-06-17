namespace Festifact.Organisation;

public partial class ShowAddPage : ContentPage
{
	public ShowAddPage(ShowAddViewModel viewModel)
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


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ShowAddViewModel)BindingContext;
        if (vm.Artists.Count == 0)
            await vm.GetExtraShowInformationCommand.ExecuteAsync(null);

    }
}