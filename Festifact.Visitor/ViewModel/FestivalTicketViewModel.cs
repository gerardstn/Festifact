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

}
/* Payment provider er in gooien, mollie, stripe wat dan ook. */
/* Visitor data ophalen, mocht iemand ingelogd zijn*/
/* Post naar ticket koppeltabel wanneer payment is gedaan*/
/* zelfde mail spul gebruiken als festival info voor het ticket met een ID in een soort streepjescode ofzo*/
/* Festival telkens updaten als er een ticket is gekocht met availabletickets -1 */
