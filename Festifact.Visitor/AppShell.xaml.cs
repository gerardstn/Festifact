namespace Festifact.Visitor;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(FestivalDetailsPage), typeof(FestivalDetailsPage));
        Routing.RegisterRoute(nameof(FestivalSearchPage), typeof(FestivalSearchPage)); 

    }
}
