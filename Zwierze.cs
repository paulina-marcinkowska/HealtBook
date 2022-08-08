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
            Console.WriteLine("Podaj date wizyty: ");
            DateTime newDateOfVisit = new DateTime();
            newDateOfVisit = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nazwe kliniki: ");
            string newClinic = Console.ReadLine();
            Console.WriteLine("Podaj adres kliniki: ");
            string newAddress = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko lekarza: ");
            string newDoctor = Console.ReadLine();
            Visit newVisit = new Visit(newClinic, newAddress, newDoctor, newDateOfVisit);
            MedicalHistory.Add(newVisit);
        }

    }

}
