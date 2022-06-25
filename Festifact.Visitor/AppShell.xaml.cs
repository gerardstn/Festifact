
namespace Festifact.Visitor;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(FestivalDetailsPage), typeof(FestivalDetailsPage));
        Routing.RegisterRoute(nameof(FestivalSearchPage), typeof(FestivalSearchPage)); 
        Routing.RegisterRoute(nameof(FestivalTicketPage), typeof(FestivalTicketPage));
        Routing.RegisterRoute(nameof(ShowPage), typeof(ShowPage));
        Routing.RegisterRoute(nameof(ArtistPage), typeof(ArtistPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
        Routing.RegisterRoute(nameof(FavoriteShowsPage), typeof(FavoriteShowsPage));
        Routing.RegisterRoute(nameof(FavoriteArtistsPage), typeof(FavoriteArtistsPage));
        Routing.RegisterRoute(nameof(VisitedShowsPage), typeof(VisitedShowsPage));

    }
}
