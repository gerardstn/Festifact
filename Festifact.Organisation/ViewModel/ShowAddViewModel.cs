using Festifact.Organisation.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Show), (nameof(Show)))]
[QueryProperty(nameof(Artist), (nameof(Artist)))]
[QueryProperty(nameof(Model.Location), (nameof(Model.Location)))]
[QueryProperty(nameof(Room), (nameof(Room)))]
[QueryProperty(nameof(Movie), (nameof(Movie)))]
[QueryProperty(nameof(RoomReservation), (nameof(RoomReservation)))]


public partial class ShowAddViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();
    public ObservableCollection<Model.Location> Locations { get; set; } = new();
    public ObservableCollection<Movie> Movies { get; set; } = new();
    public ObservableCollection<Room> Rooms { get; set; } = new();
    public ObservableCollection<RoomReservation> RoomReservations { get; set; } = new();


    public ShowAddViewModel(ShowService showService, ArtistService artistService, LocationService locationService, RoomService roomService, MovieService movieService, RoomReservationService roomReservationService)
    {
        Title = "Add Show";
        Show = new();
        roomReservation = new();
        this.showService = showService;
        this.artistService = artistService;
        this.locationService = locationService;
        this.roomService = roomService;
        this.movieService = movieService;
        this.roomReservationService = roomReservationService;
    }
    ShowService showService;
    ArtistService artistService;
    LocationService locationService;
    RoomService roomService;
    MovieService movieService;
    RoomReservationService roomReservationService;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Artist artist;

    [ObservableProperty]
    Model.Location location;

    [ObservableProperty]
    Room room;

    [ObservableProperty]
    Movie movie;

    [ObservableProperty]
    Artist selectedArtist;

    [ObservableProperty]
    Model.Location selectedLocation;

    [ObservableProperty]
    Room selectedRoom;

    [ObservableProperty]
    Movie selectedMovie;

    [ObservableProperty]
    RoomReservation roomReservation;

    [ObservableProperty]
    public TimeSpan startTime;

    [ObservableProperty]
    public TimeSpan endTime;

    async Task ShowReserveRoom(RoomReservation roomReservation)
        {
        roomReservation.RoomId = 1;

        roomReservation.StartDateTime = show.StartDate.Add(startTime);
        roomReservation.EndDateTime = show.EndDate.Add(endTime);

        var roomReservations = await roomReservationService.GetRoomReservations(roomReservation.RoomId);
            RoomReservations.Clear();
            foreach (var reservation in roomReservations) { 
                RoomReservations.Add(reservation);  
            }
             bool error = false;
            
                foreach (var existingRoomReservation in roomReservations) {
                    if(existingRoomReservation.StartDateTime > roomReservation.StartDateTime && existingRoomReservation.StartDateTime >= roomReservation.EndDateTime || 
                    existingRoomReservation.StartDateTime < roomReservation.StartDateTime && existingRoomReservation.StartDateTime <= roomReservation.EndDateTime)
                    {
                    error = true;
                    break;
                    }
                }

                if (error == false)
                {
                await roomReservationService.AddRoomReservation(roomReservation);
                }
            
    }
    
    [ICommand]
    async Task AddShowAsync(Show show)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            
            if (selectedMovie == null && selectedArtist == null)
            {
                return;
            }else if (selectedMovie == null)
            {
            show.MovieId = 0;
            show.ArtistId = selectedArtist.ArtistId;
            }else if (selectedArtist == null) { 
            show.ArtistId = 0;
            show.MovieId = selectedMovie.MovieId;
            }
            await ShowReserveRoom(roomReservation);

            if(roomReservation == null)
            {
                Toast.Make("Unable to reserve the room.", ToastDuration.Short, 14);
            }
            else
            {
                show.RoomReservationId = roomReservation.RoomReservationId;
            }
            

            await showService.AddShow(show, festival);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Show: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(FestivalsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }


    [ICommand]
    async Task GetExtraShowInformation()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var artists = await artistService.GetArtists();
            var locations = await locationService.GetLocations();
            var movies = await movieService.GetMovies();


            Artists.Clear();
            Locations.Clear();
            Movies.Clear();
            foreach (var artist in artists)
                Artists.Add(artist);
            foreach (var location in locations)
                Locations.Add(location);
            foreach (var movie in movies)
                Movies.Add(movie);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get extra information: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }


}