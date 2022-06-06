using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;


[QueryProperty(nameof(Movie), (nameof(Movie)))]
public partial class MovieAddViewModel : BaseViewModel
{
    public MovieAddViewModel(MovieService movieService)
    {
        Title = "Add Movie";
        Movie = new();
        this.movieService = movieService;
    }
    MovieService movieService;

    [ObservableProperty]
    Movie movie;


    [ICommand]
    async Task AddMovieAsync(Movie movie)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await movieService.AddMovie(movie);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Movie: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(MoviesPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }


}
