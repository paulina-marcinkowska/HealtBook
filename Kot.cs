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
            Console.WriteLine("wizyta: " + Wizyta);
            Console.WriteLine("klinika: " + Klinika.Nazwa);
            foreach (Wizyta element in HistoriaChoroby)
            {
                Console.WriteLine(element.Rozpoznanie);
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

