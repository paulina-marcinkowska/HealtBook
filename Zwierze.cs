using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "animal")]
    public class Zwierze
    {
        [XmlElement(ElementName = "name")]
        public string Imie { get; set; }
        [XmlElement(ElementName = "dateOfBirth")]
        public DateTime DataUrodzenia { get; set; }
        [XmlElement(ElementName = "weight")]
        public int Waga { get; set; }
        [XmlElement(ElementName = "medicalHistory")]
        public List<Visit> HistoriaChoroby { get; set; }
        [XmlElement(ElementName = "clinic")]
        public Clinic Clinic { get; set; }
        [XmlElement(ElementName = "visit")]
        public DateTime Visit { get; set; }

        public Zwierze(string imie, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.DataUrodzenia = dataUrodzenia;
        }
        public Zwierze()
        {
        }

        public void AddVisit()
        {
            try
            {
                int orAdd = int.Parse(Console.ReadLine());
                if (orAdd == 1)
                {
                    DateTime nVisit = new DateTime();
                    nVisit = DateTime.Parse(Console.ReadLine());
                    Visit = nVisit;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

}
