using Microsoft.Maui.ApplicationModel.Communication;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp;

public partial class MeldingPage : ContentPage
{
    public string WarehouseName => MeldingStore.WarehouseName;
    public string WarehouseEmail => MeldingStore.WarehouseEmail;
    public string WarehousePhone => MeldingStore.WarehousePhone;

    public string HelpdeskName => MeldingStore.HelpdeskName;
    public string HelpdeskEmail => MeldingStore.HelpdeskEmail;
    public string HelpdeskPhone => MeldingStore.HelpdeskPhone;

    public MeldingPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnWarehouseEmailClicked(object sender, TappedEventArgs e)
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = "Contact met magazijn",
                To = new List<string> { MeldingStore.WarehouseEmail }
            };

            await Email.Default.ComposeAsync(message);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen e-mailapp worden geopend.", "OK");
        }
    }

    private async void OnWarehousePhoneClicked(object sender, TappedEventArgs e)
    {
        try
        {
            PhoneDialer.Default.Open(MeldingStore.WarehousePhone);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen telefoonapp worden geopend.", "OK");
        }
    }

    private async void OnHelpdeskEmailClicked(object sender, TappedEventArgs e)
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = "Contact met helpdesk",
                To = new List<string> { MeldingStore.HelpdeskEmail }
            };

            await Email.Default.ComposeAsync(message);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen e-mailapp worden geopend.", "OK");
        }
    }

    private async void OnHelpdeskPhoneClicked(object sender, TappedEventArgs e)
    {
        try
        {
            PhoneDialer.Default.Open(MeldingStore.HelpdeskPhone);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen telefoonapp worden geopend.", "OK");
        }
    }
}