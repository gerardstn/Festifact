namespace Festifact.Organisation.View;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    async Task ManageFestivals()
    {
        await Shell.Current.GoToAsync(nameof(FestivalsPage));
    }
}