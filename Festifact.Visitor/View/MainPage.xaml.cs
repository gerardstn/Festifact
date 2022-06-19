namespace Festifact.Visitor.View;

public partial class MainPage : ContentPage
{
	public MainPage(FestivalsViewModel viewModel)
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

        var vm = (FestivalsViewModel)BindingContext;
		await vm.SetAccountText();
        if (vm.Festivals.Count == 0)
			await vm.GetFestivalsCommand.ExecuteAsync(null);
	}


}