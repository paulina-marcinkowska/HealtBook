﻿using System;
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
        [XmlElement(ElementName = "vaccination")]
        public DateTime Vaccination { get; set; }

        public Cat(string name, DateTime dateOfBirth, string breed) : base(name, dateOfBirth)
        {
            this.Breed = breed;
        }

        public Cat() : base()
        {
        }

        public override string ToString()
        {
            string currentData = "Imię: " + Name + "   " + "Rasa: " + Breed + "   " + "Data urodzenia: " + DateOfBirth + "   " + "Waga: " + Weight + "   " + "Odrobaczanie: " + Deworming + "   " + "Szczepienie: " + Vaccination + "   " + "Klinika: " + ClinicName + "   " + "Historia choroby: ";
            foreach (Visit element in MedicalHistory)
            {
                currentData += string.Format("{0}   ", element.Diagnosis);
            }
            return currentData;

        }
        public void WriteData()
        {
            Console.WriteLine("imię: " + Name);
            Console.WriteLine("rasa: " + Breed);
            Console.WriteLine("data urodzenia: " + DateOfBirth);
            Console.WriteLine("waga: " + Weight);
            Console.WriteLine("odrobaczanie: " + Deworming);
            Console.WriteLine("wizyta: " + Visit);
            Console.WriteLine("klinika: " + ClinicName);
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
        public void LastDates()
        {
            Console.WriteLine("Ostatnie szczepienie: " + Vaccination);
            Console.WriteLine("Ostatnie odrobaczanie: " + Deworming);
        }
        public TimeSpan NextVaccination()
        {
            DateTime today = new DateTime();
            today = DateTime.Now.Date;
            TimeSpan nVaccination = today - Vaccination;
            return nVaccination;
        }
    }
}

