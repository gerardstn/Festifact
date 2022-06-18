using Festifact.Visitor.Services;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Festival), (nameof(Festival)))]
[QueryProperty(nameof(Show), (nameof(Show)))]

public partial class FestivalDetailsViewModel : BaseViewModel
{
    public ObservableCollection<Show> Shows { get; set; } = new();

    ShowService showService;
    FestivalService festivalService;

    public FestivalDetailsViewModel(ShowService showService, FestivalService festivalService)
    {
        this.showService = showService;
        this.festivalService = festivalService;
    }

    [ObservableProperty]
    Festival festival;

    [ObservableProperty]
    Show show;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    string emailInformation;

    [ICommand]
    async Task EmailFestivalInformation()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jeanie.lebsack48@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(emailInformation));
            email.Subject = "Festifact - " + festival.Name.ToString();
            email.Body = new TextPart(TextFormat.Html) { Text = "<img width=\"350\" height=\"200\" src=\""+festival.Banner+"\"><h1>Information for: "+festival.Name+"</h1>" +
                "<p>"+festival.Description+"</p> <br>" +
                "<ul>" +
                "<li> Available tickets now: " + festival.TicketsAvailable + "</li>" +
                "<li> Type: " + festival.Type + "</li>" +
                "<li> Genre: " + festival.Genre + "</li>" +
                "<li> Age: " + festival.AgeCatagory+ "</li>" +
                "<li> Start date: " + festival.EndDate+"</li>" +
                "<li> End date: " + festival.EndDate + "</li>" +
                "</ul>"};

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("jeanie.lebsack48@ethereal.email", "CFHFACWnD6q5Hpzcd3");
            smtp.Send(email);
            smtp.Disconnect(true);


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to mail information: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

    [ICommand]
    async Task GetFestivalShowsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var shows = await showService.GetShows(festival.FestivalId);

            Shows.Clear();
            foreach (var show in shows)
                Shows.Add(show);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Shows: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }

    }

    [ICommand]
    async Task BuyTicketPage()
    {
        var route = $"{nameof(FestivalTicketPage)}";
        await Shell.Current.GoToAsync(route, true, new Dictionary<string, object>
    {
        {"Festival", festival }
    });
    }

    [ICommand]
    async Task NavigateToLogin()
    {
        var route = $"{nameof(LoginPage)}";
        await Shell.Current.GoToAsync(route);
    }
}
