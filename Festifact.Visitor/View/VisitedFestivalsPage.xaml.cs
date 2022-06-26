namespace Festifact.Visitor;

public partial class VisitedFestivalsPage : ContentPage
{
    public VisitedFestivalsPage(VisitedFestivalsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var festival = e.CurrentSelection.FirstOrDefault() as Festival;
		if (festival == null)
			return;

		await Shell.Current.GoToAsync(nameof(RateFestivalPage), true, new Dictionary<string, object>
	{
		{"Festival", festival }
	});

		((CollectionView)sender).SelectedItem = null;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (VisitedFestivalsViewModel)BindingContext;
            await vm.GetFestivalsToRateCommand.ExecuteAsync(null);
    }
}