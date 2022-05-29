using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class MoviesViewModel : BaseViewModel
{
    public ObservableCollection<Movie> Movies { get; } = new();

    MovieService movieService;
    public MoviesViewModel(MovieService movieService)
    {
        Title = "Manage Movies";
        this.movieService = movieService;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand]
    async Task GetMoviesAsync()
    {

        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var movies = await movieService.GetMovies();

            Movies.Clear();
            foreach (var movie in movies)
                Movies.Add(movie);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Movies: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [ICommand]
    async Task AddMoviePage()
    {
        var route = $"{nameof(MovieAddPage)}";
        await Shell.Current.GoToAsync(route);
    }
}
