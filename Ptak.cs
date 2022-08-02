using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "bird")]
    public class Bird : Animal
    {
        [XmlElement(ElementName = "species")]
        public string Species { get; set; }

        [XmlElement(ElementName = "breed")]
        public string Breed { get; set; }

        public Bird(string name, DateTime dateOfBirth, string species, string breed) : base(name, dateOfBirth)
        {
            this.Species = species;
            this.Breed = breed;
        }

        public Bird() : base()
        {
        }

        public void AddVisit()
        {
            try
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
            
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
