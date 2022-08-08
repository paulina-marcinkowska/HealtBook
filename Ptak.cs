using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
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

        public override string ToString()
        {
            string currentData = "Imię: " + Name + "   " + "Rasa: " + Breed + "   " + "Data urodzenia: " + DateOfBirth + "   " + "Waga: " + Weight + "   " + "Klinika: " + ClinicName + "   " + "Historia choroby: ";
            foreach (Visit element in MedicalHistory)
            {
                currentData += string.Format("{0}   ", element.Diagnosis);
            }
            return currentData;
        }

    }
}
