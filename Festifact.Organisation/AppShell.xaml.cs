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
        Routing.RegisterRoute(nameof(PerformersPage), typeof(PerformersPage));
        Routing.RegisterRoute(nameof(PerformerAddPage), typeof(PerformerAddPage));
        Routing.RegisterRoute(nameof(PerformerEditPage), typeof(PerformerEditPage));
        Routing.RegisterRoute(nameof(LocationsPage), typeof(LocationsPage));
        Routing.RegisterRoute(nameof(LocationAddPage), typeof(LocationAddPage));
        Routing.RegisterRoute(nameof(LocationEditPage), typeof(LocationEditPage));

    }
}