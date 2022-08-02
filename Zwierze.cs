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
    public class Animal
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }
        [XmlElement(ElementName = "medicalHistory")]
        public List<Visit> MedicalHistory { get; set; }
        [XmlElement(ElementName = "clinic")]
        public string ClinicName { get; set; }
        [XmlElement(ElementName = "visit")]
        public DateTime Visit { get; set; }

        public Animal(string name, DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
        public Animal()
        {
        }

        public void AddVisit()
        {
            try
            {
                    DateTime newVisit = new DateTime();
                    newVisit = DateTime.Parse(Console.ReadLine());
                    Visit = newVisit;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

}
