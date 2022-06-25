using Festifact.Visitor.Services;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using IronBarCode;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Visitor), (nameof(Visitor)))]
[QueryProperty(nameof(Ticket), (nameof(Ticket)))]

public partial class FestivalTicketViewModel : BaseViewModel
    {

        TicketService ticketService;
        VisitorService visitorService;
        public FestivalTicketViewModel(TicketService ticketService, VisitorService visitorService){
        Title = "Tickets";
        Ticket = new();
        this.ticketService = ticketService;
        this.visitorService = visitorService;
        }



    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Ticket ticket;

    [ObservableProperty]
    Model.Visitor visitor;



    [ICommand]
    async Task TicketPayment()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            if(Preferences.Get("VisitorId", 0) == 0)
            {
                await visitorService.AddVisitor(visitor);
            }
            else
            {
                if(visitor.Iban != null)
                    await visitorService.UpdateVisitor(visitor);
                else
                {
                    IsBusy = false;
                    return;
                }
            }
            if(festival.TicketsAvailable > 0) {
                ticket.VisitorId = visitor.VisitorId;
                ticket.FestivalId = festival.FestivalId;
                await ticketService.AddTicket(ticket, festival);
            }
            else { 
                await Application.Current.MainPage.DisplayAlert("Error!", "No tickets available", "OK");
            }
            await EmailTicketInfo();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to pay for the ticket: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    async Task EmailTicketInfo()
    {
        try
        {
            IsBusy = true;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("maxime.purdy89@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(visitor.Email));
            email.Subject = "Festifact Ticket - " + festival.Name.ToString();
            string BarCodeValue = ticket.FestivalId.ToString() + ticket.VisitorId.ToString() + "B" + ticket.TicketId.ToString();
            var BarCode = IronBarCode.BarcodeWriter.CreateBarcode(BarCodeValue, BarcodeEncoding.Code128);
            BarCode.AddAnnotationTextAboveBarcode(festival.Name);
            BarCode.AddBarcodeValueTextBelowBarcode();
            BarCode.SetMargins(100);
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "<img width=\"350\" height=\"200\" src=\"" + festival.Banner + "\"><h1>Thanks " + visitor.Name + " for your purchase for: " + festival.Name + "</h1>" +
                "<p>" + festival.Description + "</p> <br>" +
                "<ul>" +
                "<li> Type: " + festival.Type + "</li>" +
                "<li> Genre: " + festival.Genre + "</li>" +
                "<li> Age: " + festival.AgeCatagory + "</li>" +
                "<li> Start date: " + festival.EndDate + "</li>" +
                "<li> End date: " + festival.EndDate + "</li>" +
                "</ul><h2> See you soon!</h2>" + BarCode.ToHtmlTag()
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("maxime.purdy89@ethereal.email", "DNrDetJghy3Sq7fMX2");
            smtp.Send(email);
            smtp.Disconnect(true);


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to mail ticket: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }

    }

    [ICommand]
    async Task GetVisitor()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Visitor = await visitorService.GetVisitor(Preferences.Get("VisitorId", 0));
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get account info: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}


