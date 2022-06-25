namespace Festifact.Visitor;

public partial class FestivalTicketPage : ContentPage
{
    public FestivalTicketPage(FestivalTicketViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FestivalTicketViewModel)BindingContext;
            await vm.GetVisitorCommand.ExecuteAsync(null);
    }
}