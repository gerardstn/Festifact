using Festifact.Organisation.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Festifact.Organisation.View;

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
    public ObservableCollection<Show> Shows { get; set; } = new();



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

    async Task<bool> ShowReserveRoom(RoomReservation roomReservation)
    {
        roomReservation.RoomId = 1;
        roomReservation.StartDateTime = show.StartDate;
        roomReservation.EndDateTime = show.EndDate;

        var roomReservations = await roomReservationService.GetRoomReservations(roomReservation.RoomId);
        RoomReservations.Clear();
        foreach (var reservation in roomReservations)
        {
            RoomReservations.Add(reservation);
        }

        bool error = false;

        foreach (var existingRoomReservation in roomReservations)
        {
            if (existingRoomReservation.StartDateTime.CompareTo(show.EndDate) <= 0 &&
                existingRoomReservation.EndDateTime.CompareTo(show.StartDate) >= 0)
            {
                error = true;
                break;
            }
        }
        if (error == false)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Reserving the room.", "OK");
            await roomReservationService.AddRoomReservation(roomReservation);
            return true;
        }
        else
        {
            return false;
        }

    }

    [ICommand]
    async Task AddShowAsync(Show show)
    {
        if (IsBusy)
            return;

        try
        {
            show.StartDate = show.StartDate.Add(startTime);
            show.EndDate = show.EndDate.Add(endTime);
            IsBusy = true;

            if (selectedMovie == null && selectedArtist == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "No artist or movie selected, try again.", "OK");
                IsBusy = false;
                return;
            }
            else if (selectedMovie == null)
            {
                show.MovieId = 0;
                show.ArtistId = selectedArtist.ArtistId;

                if (await ArtistAvailable(show) == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "The selected artist is not available at that time.", "OK");
                }

            }
            else if (selectedArtist == null)
            {
                show.ArtistId = 0;
                show.MovieId = selectedMovie.MovieId;
            }

            if (!await ShowReserveRoom(roomReservation))
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Unable to reserve the room at that time.", "OK");

            }
            else
            {

                show.RoomReservationId = roomReservation.RoomReservationId;
                await showService.AddShow(show, festival);
            }

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

    async Task<bool> ArtistAvailable(Show show)
    {

        var shows = await showService.GetArtistShowsSpecific(show);
        Shows.Clear();
        foreach (var existingShow in shows)
        {
            Shows.Add(existingShow);
        }

        bool error = false;

        foreach (var existingShow in shows)
        {
            if (existingShow.StartDate.CompareTo(show.EndDate) <= 0 &&
                existingShow.EndDate.CompareTo(show.StartDate) >= 0 )
            {
                error = true;
                break;

            }
        }
        if (error == false)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Artist is available", "OK");
            return true;
        }
        else
        {
            return false;
        }
    }

    [ICommand]
    async Task GetLocationRooms()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            int locationId = selectedLocation.LocationId;

            var rooms = await roomService.GetRooms(locationId);

            Rooms.Clear();
            foreach (var room in rooms)
                Rooms.Add(room);
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
