using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "dog")]
    public class Dog : Animal
    {
        [XmlElement(ElementName = "breed")]
        public string Breed { get; set; }
        [XmlElement(ElementName = "vaccination")]
        public DateTime Vaccination { get; set; }
        [XmlElement(ElementName = "deworming")]
        public DateTime Deworming { get; set; }

        public Dog(string name, DateTime dateOfBirth, string breed):base(name,dateOfBirth)
        {
            this.Breed = breed;
        }

        public Dog() : base()
        {
        }

        public override string ToString()
        {
            string currentData = "Imię: " + Name + "   " + "Rasa: " + Breed + "   " + "Data urodzenia: " + DateOfBirth + "   " + "Waga: " + Weight + "   " + "Szczepienie: " + Vaccination + "   " + "Odrobaczanie: " + Deworming + "   " + "Klinika: " + ClinicName + "   " + "Historia choroby: ";
            foreach (Visit element in MedicalHistory)
            {
                currentData += string.Format("{0}   ", element.Diagnosis);
            }
            return currentData;

        }
        public void WriteData ()
        {
            Console.WriteLine("imię: " + Name);
            Console.WriteLine("rasa: " + Breed);
            Console.WriteLine("data urodzenia: " + DateOfBirth);
            Console.WriteLine("waga: " + Weight);
            Console.WriteLine("szczepienie: " + Vaccination);
            Console.WriteLine("odrobaczanie: " + Deworming);
            Console.WriteLine("wizyta: " + Visit);
            Console.WriteLine("klinika: " + ClinicName);
            Console.WriteLine("historia choroby: ");
            
            foreach (Visit element in MedicalHistory)
            {
                Console.WriteLine(element.Diagnosis);
            }
        }

        public void EditDog()
        {
            try
            {
                Console.WriteLine("Podaj wagę: ");
                Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego szczepienia (rok, miesiąc, dzień) : ");
                Vaccination = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego odrobaczania (rok, miesiąc, dzień : ");
                Deworming = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public TimeSpan NextVaccination()
        {
            DateTime today = new DateTime();
            today = DateTime.Now.Date;
            TimeSpan newVaccination = today - Vaccination;
            return newVaccination;
        }
        public void AddsVisit()
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


