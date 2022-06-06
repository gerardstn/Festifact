using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Movie), (nameof(Movie)))]
public partial class MovieEditViewModel : BaseViewModel
{

    public MovieEditViewModel(MovieService movieService)
    {
        Title = "Edit movie";
        Movie = new();
        this.movieService = movieService;
    }

    MovieService movieService;

    [ObservableProperty]
    Movie movie;

    [ICommand]
    async Task UpdateMovieAsync(Movie movie)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await movieService.UpdateMovie(movie);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to update Movie: {ex.Message}");
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
