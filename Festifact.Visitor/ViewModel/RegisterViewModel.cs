using Festifact.Visitor.Services;

namespace Festifact.Visitor.ViewModel;

[QueryProperty(nameof(Visitor), (nameof(Visitor)))]
public partial class RegisterViewModel : BaseViewModel
{

    VisitorService visitorService;

    public RegisterViewModel(VisitorService visitorService)
    {
        Visitor = new();
        Title = "Register";
        this.visitorService = visitorService;
    }


    [ObservableProperty]
    Model.Visitor visitor;

    [ICommand]
    async Task AddVisitorAsync(Model.Visitor visitor)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            await visitorService.AddVisitor(visitor);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to add Visitor: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            var route = $"//MainPage";
            await Shell.Current.GoToAsync(route);
        }
    }

    [ICommand]
    async Task NavigateToMainPage()
    {
        var route = $"//MainPage";
        await Shell.Current.GoToAsync(route);
    }

}