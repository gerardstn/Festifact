using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]

public partial class FestivalTicketViewModel : BaseViewModel
    {
        public ObservableCollection<Festival> Festivals { get; } = new();

        TicketService ticketService;
        public FestivalTicketViewModel(TicketService ticketService)
        {
            Title = "Tickets";
            this.ticketService = ticketService;
        }

    [ObservableProperty]
    Festival festival;

}/* Payment privder er in gooien, mollie, stripe wat dan ook. */
