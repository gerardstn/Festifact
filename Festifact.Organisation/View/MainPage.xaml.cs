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
}