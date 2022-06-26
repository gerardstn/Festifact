using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Ticket), (nameof(Ticket)))]
public partial class VisitedFestivalsViewModel : BaseViewModel
{
    public ObservableCollection<Festival> Festivals { get; } = new();
    public ObservableCollection<Ticket> Tickets { get; } = new();

    FestivalService festivalService;
    TicketService ticketService;
    public VisitedFestivalsViewModel(FestivalService festivalService, TicketService ticketService)
    {
        Title = "Your visited festivals";
        this.festivalService = festivalService;
        this.ticketService = ticketService;
    }

    [ObservableProperty]
    Ticket ticket;

    [ObservableProperty]
    Festival festival;


    [ICommand]
    async Task GetFestivalsToRate()
    {
        if (IsBusy)
            return;
        try
        {
            var tickets = await ticketService.GetTickets();
            Tickets.Clear();
            Festivals.Clear();
            foreach (var ticket in tickets) { 
                festival = await festivalService.GetFestivalById(ticket.FestivalId);
                if (festival.EndDate.CompareTo(DateTime.Now) < 0) { 
                    Festivals.Add(festival);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Festivals to rate: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}