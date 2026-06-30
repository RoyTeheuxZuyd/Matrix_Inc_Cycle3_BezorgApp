using MatrixIncBezorgApp.Models;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp;

public partial class BerichtenPage : ContentPage
{
    public BerichtenPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BerichtList.ItemsSource = BerichtStore.Berichten;
    }

    private void OnToggleExpand(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is BerichtItem item)
        {
            item.IsExpanded = !item.IsExpanded;
        }
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is BerichtItem item)
        {
            BerichtStore.Berichten.Remove(item);
        }
    }

    private void OnDeleteAllClicked(object sender, EventArgs e)
    {
        BerichtStore.Berichten.Clear();
    }
}