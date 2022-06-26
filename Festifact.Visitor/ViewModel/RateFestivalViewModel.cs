using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Rating), (nameof(Rating)))]
public partial class RateFestivalViewModel : BaseViewModel
{
    RatingService ratingService;
    public RateFestivalViewModel(RatingService ratingService)
    {
        Rating = new();
        Title = "RateFestival";
        this.ratingService = ratingService;
    }

    [ObservableProperty]
    Ticket ticket;

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Rating rating;

    [ObservableProperty]
    Model.Visitor visitor;

    [ICommand]
    async Task AddRatingAsync(Rating rating)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            rating.VisitorId = Preferences.Get("VisitorId", 0);
            rating.FestivalId = festival.FestivalId;
            await ratingService.AddRating(rating);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Rating: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(AccountPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}