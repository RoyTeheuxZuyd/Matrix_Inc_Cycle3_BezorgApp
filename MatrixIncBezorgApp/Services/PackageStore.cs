using System.Collections.ObjectModel;
using MatrixIncBezorgApp.Models;

namespace MatrixIncBezorgApp.Services
{
    public static class PackageStore
    {
        public static ObservableCollection<PackageItem> Packages { get; set; } = new ObservableCollection<PackageItem>
        {
            new PackageItem { PackageId = "PKG-100234", RackLocation = "A-12", IsScanned = false },
            new PackageItem { PackageId = "PKG-100235", RackLocation = "A-14", IsScanned = false },
            new PackageItem { PackageId = "PKG-100236", RackLocation = "B-03", IsScanned = false },
            new PackageItem { PackageId = "PKG-100237", RackLocation = "C-09", IsScanned = false },
            new PackageItem { PackageId = "PKG-100238", RackLocation = "D-01", IsScanned = false }
        };
    }
}