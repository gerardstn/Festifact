﻿using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
public partial class ShowAddViewModel : BaseViewModel
{ 
    public ShowAddViewModel(ShowService showService)
    {
        Title = "Add Show";
        Show = new();
        this.showService = showService;
    }
    ShowService showService;

    [ObservableProperty]
    Show show;


    [ICommand]
    async Task AddShowAsync(Show show)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await showService.AddShow(show);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Show: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"{nameof(FestivalEditPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }


}