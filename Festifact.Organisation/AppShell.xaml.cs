﻿namespace Festifact.Organisation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(FestivalsManageOverviewPage), typeof(FestivalsManageOverviewPage));
    }
}