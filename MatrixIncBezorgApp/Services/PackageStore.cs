using System.Collections.ObjectModel;
using MatrixIncBezorgApp.Models;

namespace MatrixIncBezorgApp.Services
{
    public static class PackageStore
    {
        public static ObservableCollection<PackageItem> Packages { get; set; } = new ObservableCollection<PackageItem>
        {
            new PackageItem { PackageId = "PKG-100234", RackLocation = "A-12", IsScanned = false, IsDelivered = false, Adress = "Vrijthof 1, 6211 LC Maastricht, Netherlands"},
            new PackageItem { PackageId = "PKG-100235", RackLocation = "A-14", IsScanned = false, IsDelivered = false, Adress = "Pancratiusplein 45, 6411 JZ Heerlen, Netherlands"},
            new PackageItem { PackageId = "PKG-100236", RackLocation = "B-03", IsScanned = false, IsDelivered = false, Adress = "Rijksweg Zuid 10, 6131 AN Sittard, Netherlands"},
            new PackageItem { PackageId = "PKG-100237", RackLocation = "C-09", IsScanned = false, IsDelivered = false, Adress = "Heerstraat Zuid 5, 6171 XD Stein, Netherlands"},
            new PackageItem { PackageId = "PKG-100238", RackLocation = "D-01", IsScanned = false, IsDelivered = false, Adress = "Amerikalaan 20, 6199 AE Maastricht-Airport, Netherlands"}
        };
    }
}