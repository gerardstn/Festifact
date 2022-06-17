using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

    public partial class FestivalTicketViewModel : BaseViewModel
    {
        public ObservableCollection<Festival> Festivals { get; } = new();

        TicketService ticketService;
        public FestivalTicketViewModel(TicketService ticketService)
        {
            Title = "Tickets";
            this.ticketService = ticketService;
        }

    

}/* Payment privder er in gooien, mollie, stripe wat dan ook. */
