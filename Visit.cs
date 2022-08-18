using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace ClassLibrary
{
    [XmlRoot(ElementName = "visit")]
    public class Visit:Clinic
    {
        [XmlRoot(ElementName = "visit")]

            [XmlElement(ElementName = "dateOfVisit")]
            public DateTime DateOfVisit { get; set; }
            [XmlElement(ElementName = "doctor")]
            public string Doctor { get; set; }
            [XmlElement(ElementName = "diagnosis")]
            public string Diagnosis { get; set; }
            [XmlElement(ElementName = "recommendation")]
            public string Recommendation { get; set; }

            public Visit(string name, string address, string doctor, DateTime dateOfVisit) : base(name, address)
            {
                this.Doctor = doctor;
                this.DateOfVisit = dateOfVisit;
            }

            public Visit() : base()
            {
            }
        }
}
