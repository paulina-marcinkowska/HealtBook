using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace KsiazeczkaZdrowia
{

    [XmlRoot(ElementName = "bird")]
    public class Ptak : Zwierze
    {
        [XmlElement(ElementName = "species")]
        public string Gatunek { get; set; }

        [XmlElement(ElementName = "breed")]
        public string Rasa { get; set; }

        public Ptak(string imie, DateTime dataUrodzenia, string gatunek, string rasa) : base(imie, dataUrodzenia)
        {
            this.Gatunek = gatunek;
            this.Rasa = rasa;

        }

        public Ptak():base()
        {
        }

        public void DodajWizyte()
        {
            try
            {
                int czyDodac = int.Parse(Console.ReadLine());

                if (czyDodac == 1)
                {
                    Console.WriteLine("Podaj date wizyty: ");
                    DateTime nDataWizyty = new DateTime();
                    nDataWizyty = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwe kliniki: ");
                    string nKlinika = Console.ReadLine();
                    Console.WriteLine("Podaj adres kliniki: ");
                    string nAdres = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko lekarza: ");
                    string nLekarz = Console.ReadLine();
                    Wizyta nWizyta = new Wizyta(nKlinika, nAdres, nAdres, nDataWizyty);
                    HistoriaChoroby.Add(nWizyta);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
}
