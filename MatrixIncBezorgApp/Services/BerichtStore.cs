using System.Collections.ObjectModel;
using MatrixIncBezorgApp.Models;

namespace MatrixIncBezorgApp.Services;

public static class BerichtStore
{
    public static ObservableCollection<BerichtItem> Berichten { get; set; }
        = new ObservableCollection<BerichtItem>
    {
        new BerichtItem
        {
            Onderwerp = "Nieuw bedrijfsbeleid",
            Bericht = "Het bedrijfsbeleid gaat veranderen na de grote uitbreidingen bij Matrix Inc. Wij zijn trots om 20 nieuwe collega's erbij te hebben bij ons team. We hopen dat iedereen in de toekomst fijn met elkaar kunnen werken.",
            Auteur = "Management",
            Datum = DateTime.Now.AddDays(-5)
        },
        new BerichtItem
        {
            Onderwerp = "Nieuwe app update",
            Bericht = "De app is onlangs geupdatet met nieuwe features voor stabiliteit en kwaliteit voor de bezorgers van Matrix Inc.",
            Auteur = "Systeem",
            Datum = DateTime.Now.AddDays(-2)
        },
        new BerichtItem
        {
            Onderwerp = "10 jaar Matrix Inc",
            Bericht = "10 jaar lang levert Matrix Inc kwaliteit aan klanten. We zijn trots op onze groei en onze medewerkers.",
            Auteur = "Management",
            Datum = DateTime.Now.AddDays(-11)
        }
    };
}