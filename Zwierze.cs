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
        public List<Wizyta> HistoriaChoroby { get; set; }
        [XmlElement(ElementName = "clinic")]
        public Klinika Klinika { get; set; }
        [XmlElement(ElementName = "visit")]
        public DateTime Wizyta { get; set; }

        public Zwierze(string imie, DateTime dataUrodzenia)
        {
            this.Imie = imie;
            this.DataUrodzenia = dataUrodzenia;
        }
        public Zwierze()
        {
        }

        public void DodajWizyte()
        {
            try
            {
                int czyDodac = int.Parse(Console.ReadLine());
                if (czyDodac == 1)
                {
                    DateTime nowaWizyta = new DateTime();
                    nowaWizyta = DateTime.Parse(Console.ReadLine());
                    Wizyta = nowaWizyta;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

}
