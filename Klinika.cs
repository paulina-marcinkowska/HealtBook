using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "clinic")]
    public class Klinika
    {
        [XmlElement(ElementName = "title")]
        public string Nazwa { get; set; }
        [XmlElement(ElementName = "address")]
        public string Adres { get; set; }
        [XmlElement(ElementName = "contact")]
        public List<string> Kontakt { get; set; }
        [XmlElement(ElementName = "service")]
        public List<string> UslugiWeterynaryjne { get; set; }
        [XmlElement(ElementName = "doctors")]
        public List<string> Lekarze { get; set; }

        public Klinika(string nazwa, string adres)
        {
            this.Nazwa = nazwa;
            this.Adres = adres;
        }

        public Klinika() 
        { 
        }

        public void WypiszDane() 
        {
            Console.WriteLine("Nazwa: " + Nazwa);
            Console.WriteLine("Adres: " + Adres);
            foreach(string element in Kontakt) 
            {
                Console.WriteLine(element);
            }
            foreach(string element in UslugiWeterynaryjne) 
            {
                Console.WriteLine(element);
            }
            foreach(string element in Lekarze) 
            {
                Console.WriteLine(element);
            }
        }
        public void EdytujDaneKliniki()
        {
            try
            {
                Console.WriteLine("Podaj adres: ");
                Adres = Console.ReadLine();
                Console.WriteLine("Dodaj nowy kontakt: ");
                string nowyKontakt = Console.ReadLine();
                Kontakt.Add(nowyKontakt);
                Console.WriteLine("Dodaj nowe usługi: ");
                string noweUslugi = Console.ReadLine();
                UslugiWeterynaryjne.Add(noweUslugi);
                Console.WriteLine("Dodaj nowego lekarza: ");
                string nowyLekarz = Console.ReadLine();
                Lekarze.Add(nowyLekarz);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                EdytujDaneKliniki();
            }
        }
    }
}
