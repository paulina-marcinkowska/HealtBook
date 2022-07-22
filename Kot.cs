using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "cat")]
    public class Cat : Animal
    {
        [XmlElement(ElementName = "breed")]
        public string Breed{ get; set; }
        [XmlElement(ElementName = "deworming")]
        public DateTime Deworming { get; set; }

        public Cat(string name, DateTime dateOfBirth, string breed) : base(name, dateOfBirth)
        {
            this.Breed = breed;
        }

        public Cat() : base()
        {
        }

        public void WriteData()
        {
            Console.WriteLine("imię: " + Name);
            Console.WriteLine("rasa: " + Breed);
            Console.WriteLine("data urodzenia: " + DateOfBirth);
            Console.WriteLine("waga: " + Weight);
            Console.WriteLine("odrobaczanie: " + Deworming);
            Console.WriteLine("wizyta: " + Visit);
            Console.WriteLine("klinika: " + Clinic.Name);
            foreach (Visit element in MedicalHistory)
            {
                Console.WriteLine(element.Diagnosis);
            }
        }
        public void EditCat()
        {
            try
            {
                Console.WriteLine("Podaj wagę: ");
                Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj datę ostatniego odrobaczania (rok, miesiąc, dzień : ");
                Deworming = DateTime.Parse(Console.ReadLine());
            }
           
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
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

