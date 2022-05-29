namespace Festifact.Organisation;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var movie = e.CurrentSelection.FirstOrDefault() as Movie;
        if (movie == null)
            return;

        await Shell.Current.GoToAsync(nameof(MovieEditPage), true, new Dictionary<string, object>
    {
        {"Movie", movie }
    });

        ((CollectionView)sender).SelectedItem = null;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (MoviesViewModel)BindingContext;
        if (vm.Movies.Count == 0)
            await vm.GetMoviesCommand.ExecuteAsync(null);
    }
}




