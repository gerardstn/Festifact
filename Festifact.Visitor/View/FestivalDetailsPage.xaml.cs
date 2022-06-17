namespace Festifact.Visitor;

public partial class FestivalDetailsPage : ContentPage
{
    public FestivalDetailsPage(FestivalDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var show = e.CurrentSelection.FirstOrDefault() as Show;
        if (show == null)
            return;

        await Shell.Current.GoToAsync(nameof(ShowPage), true, new Dictionary<string, object>
    {
        {"Show", show }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FestivalDetailsViewModel)BindingContext;
        if (vm.Shows.Count == 0)
            await vm.GetFestivalShowsCommand.ExecuteAsync(null);
    }
}