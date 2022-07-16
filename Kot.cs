using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "cat")]
    public class Kot:Zwierze
    {
        [XmlElement(ElementName = "breed")]
        public string Rasa { get; set; }
        [XmlElement(ElementName = "deworming")]
        public DateTime Odrobaczanie { get; set; }

        public Kot(string imie, DateTime dataUrodzenia, string rasa) : base(imie, dataUrodzenia)
        {
            this.Rasa = rasa;
        }

        public Kot() : base()
        {
        }

        public void WypiszDane(Kot e)
        {
            Console.WriteLine("imię: " + Imie);
            Console.WriteLine("rasa: " + Rasa);
            Console.WriteLine("data urodzenia: " + DataUrodzenia);
            Console.WriteLine("waga: " + Waga);
            Console.WriteLine("odrobaczanie: " + Odrobaczanie);
            Console.WriteLine("wizyta: " + Visit);
            Console.WriteLine("klinika: " + Clinic.Name);
            foreach (Visit element in HistoriaChoroby)
            {
                Console.WriteLine(element.Diagnosis);
            }
        }
        public void EdytujDaneKota()
        {
            try
            {
                Console.WriteLine("Podaj wagę: ");
                Waga = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego odrobaczania (rok, miesiąc, dzień : ");
                Odrobaczanie = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void DodajWizyte()
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

