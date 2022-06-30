using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
public partial class FestivalsSearchViewModel : BaseViewModel, INotifyPropertyChanged
{

    string type, genre, age, location;
    DateTime date = new DateTime(2022, 8, 3);
    public string Type { 
        get => type; 
        set { 
            type = value; 
            OnPropertyChanged(nameof(Type)); 
        } 
    }
    public string Genre { 
        get => genre;
        set { 
            genre = value;
            OnPropertyChanged(nameof(Genre));
        } 
    }
    
    public string Age { 
        get => age; 
        set { 
            age = value;
            OnPropertyChanged(nameof(Age));
        }
    }
    public string Location { 
        get => location; 
        set { 
            location = value;
            OnPropertyChanged(nameof(Location));
        } 
    }
    public DateTime Date { 
        get => date; 
        set { 
            date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string type) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(type));


    public ObservableCollection<Festival> Festivals { get; } = new();

    public void ClearFields()
    {
        Type = string.Empty;
        Genre = string.Empty;
        Age = string.Empty;
        Location = string.Empty;
        Date = new DateTime(2022, 8, 3);
    }

    FestivalService festivalService;
    public FestivalsSearchViewModel(FestivalService festivalService)
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
            ClearFields();

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
            var festivals = await festivalService.SearchFestivals(type, genre, age, location, Date);
            
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
    async Task GotoFestivalDetails(Festival festival)
    {
        if (festival == null)
            return;

        await Shell.Current.GoToAsync(nameof(FestivalDetailsPage), true, new Dictionary<string, object>
        {
            {"Festival", festival }
        });
    }

    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}