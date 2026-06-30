using System;
using System.Collections.Generic;
using System.Text;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp;

public partial class InstellingenPage : ContentPage
{
    public InstellingenPage()
    {
        InitializeComponent();
        LoadSettings();
    }

    private void LoadSettings()
    {
        // Theme (default system)
        switch (SettingsStore.Theme)
        {
            case "Light":
                break;
            case "Dark":
                break;
            default:
                break;
        }

        // Font size
        FontSizePicker.SelectedItem = $"{SettingsStore.FontSize}%";

        // Notifications
        GpsPicker.SelectedItem = SettingsStore.GpsNotifications ? "Aan" : "Uit";
        MessagePicker.SelectedItem = SettingsStore.MessageNotifications ? "Aan" : "Uit";
    }

    private void OnThemeChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && rb.IsChecked)
        {
            SettingsStore.Theme = rb.Value.ToString();
        }
    }

    private void OnFontSizeChanged(object sender, EventArgs e)
    {
        if (FontSizePicker.SelectedItem is string value)
        {
            SettingsStore.FontSize = int.Parse(value.Replace("%", ""));
        }
    }

    private void OnGpsChanged(object sender, EventArgs e)
    {
        SettingsStore.GpsNotifications =
            GpsPicker.SelectedItem?.ToString() == "Aan";
    }

    private void OnMessageChanged(object sender, EventArgs e)
    {
        SettingsStore.MessageNotifications =
            MessagePicker.SelectedItem?.ToString() == "Aan";
    }
}