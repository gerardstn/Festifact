namespace Festifact.Organisation.View;

public partial class MainPage : ContentPage
{

    public MainPage(MainpageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async Task ManageFestivals()
    {
        await Shell.Current.GoToAsync(nameof(FestivalsPage));
    }
    async Task ManagePerformers()
    {
        await Shell.Current.GoToAsync(nameof(PerformersPage));
    }
    async Task ManageLocations()
    {
        await Shell.Current.GoToAsync(nameof(LocationsPage));
    }
}