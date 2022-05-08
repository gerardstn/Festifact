using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), "Festival")]
public partial class FestivalSearchViewModel : BaseViewModel
{

    string type, genre, age, location;
    DateTime date;
    public string Type { get => type; set => type = value; }
    public string Genre { get => genre; set => type = value; }
    public string Age { get => age; set => age = value; }
    public string Location { get => location; set => location = value; }
    public DateTime Date { get => date; set => date = value; }

    public ObservableCollection<Festival> Festivals { get; } = new();

    FestivalService festivalService;
    public FestivalSearchViewModel(FestivalService festivalService)
    {
        Title = "Festifact";
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    bool isRefreshing;

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
    async Task SearchFestivalsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var festivals = await festivalService.SearchFestivals("music","o","all","Budapest","10-08-2022");
            
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

}