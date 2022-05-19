namespace Festifact.Organisation;

public partial class FestivalsPage : ContentPage
{
	public FestivalsPage(FestivalsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var festival = e.CurrentSelection.FirstOrDefault() as Festival;
        if (festival == null)
            return;

        await Shell.Current.GoToAsync(nameof(FestivalDetailPage), true, new Dictionary<string, object>
    {
        {"Festival", festival }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FestivalsViewModel)BindingContext;
        if (vm.Festivals.Count == 0)
            await vm.GetFestivalsCommand.ExecuteAsync(null);
    }
}