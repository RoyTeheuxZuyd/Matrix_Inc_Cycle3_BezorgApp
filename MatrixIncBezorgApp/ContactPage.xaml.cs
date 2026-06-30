using System;
using System.Collections.Generic;
using System.Text;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp;

public partial class ContactPage : ContentPage
{
    public string EmailAddress => ContactStore.Email;

    public string PhoneNumber => ContactStore.PhoneNumber;

    public string ManagerName => ContactStore.ManagerName;

    public ContactPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnEmailClicked(object sender, TappedEventArgs e)
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = "Contact vanuit BezorgApp",
                To = new List<string>
                {
                    ContactStore.Email
                }
            };

            await Email.Default.ComposeAsync(message);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen e-mailapp worden geopend.","OK");
        }
    }

    private async void OnPhoneClicked(object sender, TappedEventArgs e)
    {
        try
        {
            PhoneDialer.Default.Open(ContactStore.PhoneNumber);
        }
        catch
        {
            await DisplayAlertAsync("Fout", "Er kon geen telefoonapp worden geopend.", "OK");
        }
    }
}