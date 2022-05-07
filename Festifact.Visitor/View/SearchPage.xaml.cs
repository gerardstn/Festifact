namespace Festifact.Visitor;

public partial class SearchPage : ContentPage
{
	public SearchPage(FestivalSearchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var festival = e.CurrentSelection.FirstOrDefault() as Festival;
		if (festival == null)
			return;

		await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
	{
		{"Festival", festival }
	});

		((CollectionView)sender).SelectedItem = null;
	}

}