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
                int orAdd = int.Parse(Console.ReadLine());

                if (orAdd == 1)
                {
                    Console.WriteLine("Podaj date wizyty: ");
                    DateTime nDateOfVisit = new DateTime();
                    nDateOfVisit = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwe kliniki: ");
                    string nClinic = Console.ReadLine();
                    Console.WriteLine("Podaj adres kliniki: ");
                    string nAddress = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko lekarza: ");
                    string nDoctor = Console.ReadLine();
                    Visit nVisit = new Visit(nClinic, nAddress, nDoctor, nDateOfVisit);
                    MedicalHistory.Add(nVisit);
                }
            }
            
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
