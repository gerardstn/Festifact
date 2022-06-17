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

    }
}
