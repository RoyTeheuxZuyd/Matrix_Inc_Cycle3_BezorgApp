using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixIncBezorgApp.Services;

public static class SettingsStore
{
    public static string Theme { get; set; } = "System";
    // color: light, dark, system

    public static int FontSize { get; set; } = 100;
    // sizes: 80, 90, 100, 110, 120

    public static bool GpsNotifications { get; set; } = true;

    public static bool MessageNotifications { get; set; } = true;
}