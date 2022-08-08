using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace KsiazeczkaZdrowia
{
    [XmlRoot(ElementName = "clinic")]
    public class Clinic
    {
        [XmlElement(ElementName = "title")]
        public string Name { get; set; }
        [XmlElement(ElementName = "address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "contact")]
        public List<string> Contact { get; set; }
        [XmlElement(ElementName = "service")]
        public List<string> Service { get; set; }
        [XmlElement(ElementName = "doctors")]
        public List<string> Doctors { get; set; }

        public Clinic(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public Clinic() 
        { 
        }
        public override string ToString()
        {
            string currentData = "Nazwa: " + Name + "   " + "Nazwa: " + Address + "   " + "Kontakt: ";
            foreach(string contact in Contact) 
            {
                currentData += string.Format("{0}   ", contact);
            }
            return currentData;
        }

        public void WriteData() 
        {
            Console.WriteLine("Nazwa: " + Name);
            Console.WriteLine("Adres: " + Address);
            foreach(string element in Contact) 
            {
                Console.WriteLine(element);
            }
            foreach(string element in Service) 
            {
                Console.WriteLine(element);
            }
            foreach(string element in Doctors) 
            {
                Console.WriteLine(element);
            }
        }
        public void EditClinicData()
        {
            try
            {    
                Console.WriteLine("Podaj adres: ");
                Address = Console.ReadLine();
                Console.WriteLine("Dodaj nowy kontakt: ");
                string newContact = Console.ReadLine();
                Contact.Add(newContact);
                Console.WriteLine("Dodaj nowe usługi: ");
                string newService = Console.ReadLine();
                Service.Add(newService);
                Console.WriteLine("Dodaj nowego lekarza: ");
                string newDoctor = Console.ReadLine();
                Doctors.Add(newDoctor);
            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                EditClinicData();
            }
        }
    }
}
