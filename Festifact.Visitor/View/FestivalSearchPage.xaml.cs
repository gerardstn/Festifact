namespace Festifact.Visitor;

public partial class FestivalSearchPage : ContentPage
{
	public FestivalSearchPage(FestivalsSearchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var festival = e.CurrentSelection.FirstOrDefault() as Festival;
		if (festival == null)
			return;

		await Shell.Current.GoToAsync(nameof(FestivalDetailsPage), true, new Dictionary<string, object>
	{
		{"Festival", festival }
	});

		((CollectionView)sender).SelectedItem = null;
	}


	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var vm = (FestivalsSearchViewModel)BindingContext;
		if (vm.Festivals.Count == 0)
			await vm.GetFestivalsCommand.ExecuteAsync(null);
	}

}