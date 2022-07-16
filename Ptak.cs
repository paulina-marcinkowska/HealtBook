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

        public void AddVisit()
        {
            try
            {
                int orAdd = int.Parse(Console.ReadLine());

                if (orAdd == 1)
                {
                    Console.WriteLine("Podaj date wizyty: ");
                    DateTime nDateOfVisit = new DateTime();
                    nDateOfVisit = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwe kliniki: ");
                    string nClinic = Console.ReadLine();
                    Console.WriteLine("Podaj adres kliniki: ");
                    string nAddress = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko lekarza: ");
                    string nDoctor = Console.ReadLine();
                    Visit nVisit = new Visit(nClinic, nAddress, nDoctor, nDateOfVisit);
                    HistoriaChoroby.Add(nVisit);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
}
