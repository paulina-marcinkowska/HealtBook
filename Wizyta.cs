using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "visit")]
    public class Wizyta:Klinika
    {
        [XmlElement(ElementName = "dateOfVisit")]
        public DateTime DataWizyty { get; set; }
        [XmlElement(ElementName = "doctor")]
        public string Lekarz { get; set; }
        [XmlElement(ElementName = "diagnosis")]
        public string Rozpoznanie { get; set; }
        [XmlElement(ElementName = "recommendation")]
        public string Zalecenia { get; set; }

        public Wizyta(string nazwa, string adres, string lekarz, DateTime dataWizyty) : base(nazwa, adres)
        {
            this.Lekarz = lekarz;
            this.DataWizyty = dataWizyty;
        } 
        public Wizyta():base()
        {
        }

    }


}
