using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "dog")]
    public class Pies:Zwierze
    {
        [XmlElement(ElementName = "breed")]
        public string Rasa { get; set; }
        [XmlElement(ElementName = "vaccination")]
        public DateTime Szczepienie { get; set; }
        [XmlElement(ElementName = "deworming")]
        public DateTime Odrobaczanie { get; set; }

        public Pies(string imie, DateTime dataUrodzenia, string rasa):base(imie,dataUrodzenia)
        {
            this.Rasa = rasa;
        }
        public Pies() : base()
        {
        }

        public void WypiszDane ()
        {
            Console.WriteLine("imię: " + Imie);
            Console.WriteLine("rasa: " + Rasa);
            Console.WriteLine("data urodzenia: " + DataUrodzenia);
            Console.WriteLine("waga: " + Waga);
            Console.WriteLine("szczepienie: " + Szczepienie);
            Console.WriteLine("odrobaczanie: " + Odrobaczanie);
            Console.WriteLine("wizyta: " + Wizyta);
            Console.WriteLine("klinika: " + Klinika.Nazwa);
            Console.WriteLine("historia choroby: ");
           foreach(Wizyta element in HistoriaChoroby) 
           {
                Console.WriteLine(element.Rozpoznanie);
            }
        }
        public void EdytujDanePsa()
        {
            try
            {
                Console.WriteLine("Podaj wagę: ");
                Waga = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego szczepienia (rok, miesiąc, dzień) : ");
                Szczepienie = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego odrobaczania (rok, miesiąc, dzień : ");
                Odrobaczanie = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public TimeSpan ZaIleSzczepienie(DateTime Szczepienie)
        {
            DateTime dzis = new DateTime();
            dzis = DateTime.Now.Date;
            TimeSpan nastepneSzczepienie = dzis - Szczepienie;
            return nastepneSzczepienie;
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


