﻿using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

public partial class MainpageViewModel : BaseViewModel
{

    public MainpageViewModel()
    {
        Title = "Festifact Organisation";
    }

    [ICommand]
    async Task ManageFestivals()
    {
        var route = $"{nameof(FestivalsPage)}";
        await Shell.Current.GoToAsync(route);
    }
}
