using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

    public partial class FestivalsViewModel : BaseViewModel
    {
        public ObservableCollection<Festival> Festivals { get; } = new();

        FestivalService festivalService;
        public FestivalsViewModel(FestivalService festivalService)
        {
        Title = "Festifact";
        this.festivalService = festivalService;
        }

    [ObservableProperty]
    bool isRefreshing;

    public Task SetAccountText() { 
         if (Preferences.Get("VisitorId", 0) != 0)
        {
            AccountText = "Account";
            return Task.CompletedTask;
        }
        else
        {
            AccountText = "Login / Register";
            return Task.CompletedTask;
        }
    }

    [ICommand] 
    async Task GetFestivalsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var festivals = await festivalService.GetFestivals();

            Festivals.Clear();
            foreach (var festival in festivals)
                Festivals.Add(festival);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Festivals: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }
    [ICommand]
    async Task SearchFestivals()
    {
        var route = $"{nameof(FestivalSearchPage)}";
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    async Task NavigateToAccount()
    {
        if (Preferences.Get("VisitorId", 0) != 0){ 
        var route = $"{nameof(AccountPage)}";
        await Shell.Current.GoToAsync(route);
        }
        else
        {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
        }
    }
    
}
