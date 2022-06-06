namespace Festifact.Organisation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(FestivalsPage), typeof(FestivalsPage));
        Routing.RegisterRoute(nameof(FestivalEditPage), typeof(FestivalEditPage));
        Routing.RegisterRoute(nameof(FestivalAddPage), typeof(FestivalAddPage));
        Routing.RegisterRoute(nameof(ShowAddPage), typeof(ShowAddPage));
        Routing.RegisterRoute(nameof(ShowEditPage), typeof(ShowEditPage));
        Routing.RegisterRoute(nameof(RoomAddPage), typeof(RoomAddPage));
        Routing.RegisterRoute(nameof(RoomEditPage), typeof(RoomEditPage));
        Routing.RegisterRoute(nameof(ArtistsPage), typeof(ArtistsPage));
        Routing.RegisterRoute(nameof(ArtistAddPage), typeof(ArtistAddPage));
        Routing.RegisterRoute(nameof(ArtistEditPage), typeof(ArtistEditPage));
        Routing.RegisterRoute(nameof(MoviesPage), typeof(MoviesPage));
        Routing.RegisterRoute(nameof(MovieAddPage), typeof(MovieAddPage));
        Routing.RegisterRoute(nameof(MovieEditPage), typeof(MovieEditPage));
        Routing.RegisterRoute(nameof(LocationsPage), typeof(LocationsPage));
        Routing.RegisterRoute(nameof(LocationAddPage), typeof(LocationAddPage));
        Routing.RegisterRoute(nameof(LocationEditPage), typeof(LocationEditPage));
    }
}