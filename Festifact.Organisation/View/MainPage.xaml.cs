namespace Festifact.Organisation.View;

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async Task FestivalsManageOverviewPage()
        {
            await Shell.Current.GoToAsync(nameof(FestivalsManageOverviewPage));
        }
    }
