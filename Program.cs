using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Twilio.TwiML;
using Bond;
using NPOI.SS.Formula.Functions;

namespace KsiazeczkaZdrowia
{
    class Program
    {
        static Dog blacky, kaprys, lucciano;
        static Cat diesel;
        static Clinic animal, kaczor;
        static List<Dog> listOfDogs = new List<Dog>();
        static List<Cat> listOfCats = new List<Cat>();
        static List<Clinic> listOfClinics = new List<Clinic>();
        static List<Visit> medicalHistory = new List<Visit>();

        static void Main(string[] args)
        {

            listOfDogs = GetDogs();
            listOfCats = GetCats();
            listOfClinics = GetClinics();
            SaveData();

            HandlingOfMenu();
        }


        public static List<Dog> GetDogs()
        {
           
            Dog blacky = new Dog("BLACKY", new DateTime(2018, 05, 17), "Wyżeł Małopolski");
            blacky.Weight = 20;
            blacky.Vaccination = new DateTime(2021, 10, 01);
            blacky.Deworming = new DateTime(2021, 07, 28);
            blacky.MedicalHistory = new List<Visit> ();
            blacky.Clinic = animal;

            Dog lucciano = new Dog("LUCCIANO", new DateTime(2015, 12, 24), "Lhasa Apso");
            lucciano.Clinic = kaczor;

            Dog kaprys = new Dog("KAPRYS", new DateTime(2016, 02, 01), "Lhasa Apso");
            kaprys.Clinic = kaczor;

            List<Dog> listOfDogs = new List<Dog>();
            listOfDogs.Add(blacky);
            listOfDogs.Add(lucciano);
            listOfDogs.Add(kaprys);

            return listOfDogs;
        }

        public static List<Cat> GetCats()
        {
            Cat diesel = new Cat("DIESEL", new DateTime(2008, 01, 01), "Archangielska");
            diesel.Clinic = kaczor;

            List<Cat> listaKotow = new List<Cat>();
            listOfCats.Add(diesel);

            return listOfCats;
            
        }

        public static List<Clinic> GetClinics()
        {
            Clinic animal = new Clinic("ANIMAL", "aaa");
            Clinic kaczor = new Clinic("KACZOR", "kkk");

            List<Clinic> listOfClinic = new List<Clinic>();
            listOfClinic.Add(animal);
            listOfClinic.Add(kaczor);

            return listOfClinic;
        }

        public static void SaveData()
        {
            string pDog = @"listaPsow.txt";
            string pCat = @"listaKotow.txt";
            string pClinic = @"listaKlinik.txt";

            SaveXml.SaveDataXml(listOfClinics, pClinic);
            SaveXml.SaveDataXml(listOfCats, pCat);
            SaveXml.SaveDataXml(listOfDogs, pDog);
        }

        private static int ShowMenu()
        {
            Console.WriteLine($"Spis treści: { Environment.NewLine} 1.Pacjenci { Environment.NewLine} 2.Dodaj pacjenta { Environment.NewLine} 3.Najbliższe terminy { Environment.NewLine} 4.Kliniki {Environment.NewLine} 5.Zakończ ");
            try
            {
              int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                int bug = 0;
                HandlingOfMenu();
                return bug;
            }
        }
        private static void HandlingOfMenu()
    {
        try
        {
                int choice = ShowMenu();

                switch (choice)
            {
                case 1:
                    SelectPatient();
                    break;

                case 2:
                    Console.WriteLine("Jeżeli chcesz dodać psa wybierz '1', aby dodać kota - wybierz '2' ");
                    int selectAnimal = int.Parse(Console.ReadLine());
                    if (selectAnimal == 1)
                    {
                        AddDog();
                    }
                    else if (selectAnimal == 2)
                    {
                        AddCat();
                    }
                    else
                    {
                        HandlingOfMenu();
                    }
                    break;

                    case 3:
                        NextDates();
                        break;

                    case 4:
                        SelectClinic();
                    break;
                }
        }
        catch (Exception e)
        {
                Console.WriteLine(e.Message);
                ShowMenu();
            }
        }

        private static void SelectPatient() 
    {            
            Console.WriteLine($"Lista pacjentów: {Environment.NewLine} 1.Psy: {Environment.NewLine} 2.Koty: ");
            int selectAnimal = int.Parse(Console.ReadLine());

            if (selectAnimal == 1)
            {
                foreach (Dog element in listOfDogs)
                {
                    Console.WriteLine(element.Name);
                }
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else if (selectAnimal == 2)
            {
                foreach (Cat element in listOfCats)
                {
                    Console.WriteLine(element.Name);
                }
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else
            {
                HandlingOfMenu();
            }

            string name = Console.ReadLine();
            string patientsName = name.ToUpper();
            int choice;

                    switch (patientsName)
                    {
                        case "BLACKY":
                    blacky.WriteData();
                    do
                    {
                        Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            blacky.AddsVisit();
                        }
                        else if (choice == 2)
                        {
                            blacky.EditDog();
                        }
                        else if (choice == 0)
                        {
                            HandlingOfMenu();
                        }
                        else
                        {
                            Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                        }  
                    } while (choice != 0);

                                break; 

                        case "KAPRYS":
                    
                        kaprys.WriteData();
                        do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                choice = int.Parse(Console.ReadLine());
                                if (choice == 1)
                                {
                                    kaprys.AddVisit();
                                }
                                else if (choice == 2)
                                {
                                    kaprys.EditDog();
                                }
                                else if (choice == 0)
                                {
                                    HandlingOfMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                } 
                            } while (choice != 0);

                            break;

                        case "LUCCIANO":
                            
                            lucciano.WriteData();
                            do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                choice = int.Parse(Console.ReadLine());
                                if (choice == 1)
                                {
                                    lucciano.AddVisit();
                                }
                                else if (choice == 2)
                                {
                                    lucciano.EditDog();
                                }
                                else if (choice == 0)
                                {
                                    HandlingOfMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                } 
                            } while (choice != 0);

                                break;

                        case "DIESEL":
                            
                            diesel.WriteData();
                            do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                choice = int.Parse(Console.ReadLine());
                                if (choice == 1)
                                {
                                    diesel.AddVisit();
                                }
                                else if (choice == 2)
                                {
                                    diesel.EditCat();
                                }
                                else if (choice == 0)
                                {
                                    HandlingOfMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                }

                            } while (choice != 0);
                            break;

                        default:
                        SelectPatient();
                        break;

                    }
            }

        public static Dog AddDog()
    {
        Console.WriteLine("Podaj imię psa: ");
        string nName = Console.ReadLine();
        Console.WriteLine("Podaj rasę: ");
        string nBreed = Console.ReadLine();
        Console.WriteLine("Podaj datę urodzenia psa: ");
        DateTime nDateOfBirth = new DateTime();
        nDateOfBirth = DateTime.Parse(Console.ReadLine());

        Dog x = new Dog(nName, nDateOfBirth, nBreed);

        Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
        int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Podaj wagę: ");
                int nWeight = int.Parse(Console.ReadLine());
                x.Weight = nWeight;
                Console.WriteLine("Podaj nazwe kliniki: ");
                string nameOfClinic = Console.ReadLine();
                x.Clinic.Name = nameOfClinic;
                Console.WriteLine("Podaj adres kliniki: ");
                string nAddress = Console.ReadLine();
                x.Clinic.Address = nAddress;
                Console.WriteLine("Podaj datę ostatniego szczepienia (rok, miesiąc, dzień) : ");
                DateTime nVaccination = new DateTime();
                nVaccination = DateTime.Parse(Console.ReadLine());
                x.Vaccination = nVaccination;
                Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
                DateTime nDeworming = new DateTime();
                nDeworming = DateTime.Parse(Console.ReadLine());
                x.Deworming = nDeworming;
            }            
        else
        {
                        HandlingOfMenu();
        }
            SaveData();

            return x;
    }
        public static Cat AddCat()
        {
            Console.WriteLine("Podaj imię kota: ");
            string nName = Console.ReadLine();
            Console.WriteLine("Podaj rasę: ");
            string nBreed = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia kota: ");
            DateTime nDateOfBirth = new DateTime();
            nDateOfBirth = DateTime.Parse(Console.ReadLine());

            Cat y = new Cat(nName, nDateOfBirth, nBreed);
            listOfCats.Add(y);

            Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
            Console.WriteLine("Podaj wagę: ");
            int nWeigth = int.Parse(Console.ReadLine());
            y.Weight = nWeigth;
            Console.WriteLine("Podaj nazwe kliniki: ");
            string nameOfClinic = Console.ReadLine();
            y.Clinic.Name = nameOfClinic;
            Console.WriteLine("Podaj adres kliniki: ");
            string nAddress = Console.ReadLine();
            y.Clinic.Address = nAddress;
            Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
            DateTime nDeworming = new DateTime();
            nDeworming = DateTime.Parse(Console.ReadLine());
            y.Deworming = nDeworming;

            }
            else
            {
             HandlingOfMenu();
            }
            SaveData();

            return y;
        }
        private static void NextDates()
          {
            GetDogs();
            GetCats();

              Console.WriteLine("Najbliższe szczepienia: ");
              Console.WriteLine("BLACKY " + blacky.NextVaccination(blacky.Vaccination));
              Console.WriteLine("LUCCIANO " + lucciano.NextVaccination(lucciano.Vaccination));
              Console.WriteLine("KAPRYS" + kaprys.NextVaccination(kaprys.Vaccination));

              HandlingOfMenu();
          }
        
       private static void SelectClinic()
        {
            List<Clinic> listOfClinic = GetClinics();

            Console.WriteLine($"Aby zobaczyć profil kliniki podaj jej nazwę, jeżeli chcesz dodać nową klinikę wpisz 'nowa' {Environment.NewLine} Lista klinik: ");
            foreach (Clinic element in listOfClinic)
            {
                Console.WriteLine(element.Name);
            }
            try
            {
                string name = Console.ReadLine();
                string nameOfClinic = name.ToUpper();
                int choice;

                try
                {
                    switch (nameOfClinic)
                    {
                        case "ANIMAL":
                            animal.WriteOutData();
                            Console.WriteLine($"Co chcesz zrobic? {Environment.NewLine} 1. Edytuj dane kliniki {Environment.NewLine} 0.Powrót");
                            choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                                {
                                   animal.EditClinicData();
                                                            }
                                                         else if (choice == 0)
                                                   {
                                                        SelectClinic();
                                                 }
                                                else
                                             {
                                               HandlingOfMenu();
                                         }
                                        break;

                                    case "KACZOR":
                                        kaczor.WriteOutData();
                                     Console.WriteLine($"Co chcesz zrobic? {Environment.NewLine} 1. Edytuj dane kliniki {Environment.NewLine} 0. Powrót");
                                  choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                                {
                                                               kaczor.EditClinicData();
                                       }
                                                       else if (choice == 0)
                                                     {
                                                       SelectClinic();
                                             }
                                            else
                                           {
                                              HandlingOfMenu();
                                       }
                                break;

                                    case "NOWA":
                                    AddClinic();
                                    break;
                                }
                                                }
                                     catch (Exception e)
                                    {

                                    Console.WriteLine(e.Message);
                                    SelectClinic();
                                }
                            }
                                    catch (Exception e)
                                    {

                                    Console.WriteLine(e.Message);
                                    HandlingOfMenu();
                                }
                            }
       private static Clinic AddClinic()
                                    {
                                    Console.WriteLine("Podaj nazwę kliniki");
                                    string nName = Console.ReadLine();
                                    Console.WriteLine("Podaj adres: ");
                                    string nAddress = Console.ReadLine();
                                    Console.WriteLine("Podaj numer kontaktowy: ");
                                    string nContact = Console.ReadLine();
                                    Console.WriteLine("Podaj usługi weterynaryjne: ");
                                    string nService = Console.ReadLine();
                                    Console.WriteLine("Dodaj lekarza weterynarii");
                                    string nDoctor = Console.ReadLine();

                                    Clinic z = new Clinic(nName, nAddress);
                                    z.Contact.Add(nContact);
                                    z.Service.Add(nService);
                                    z.Doctors.Add(nDoctor);
            SaveData();


            return new Clinic(nName, nAddress);

        }


    }
}




