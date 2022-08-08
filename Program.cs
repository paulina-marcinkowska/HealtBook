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
using System.Linq;

namespace KsiazeczkaZdrowia
{
    class Program
    {
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
        public static List<Clinic> GetClinics()
        {
            Clinic animal = new Clinic("ANIMAL", "aaa");
            Clinic kaczor = new Clinic("KACZOR", "kkk");
            
            listOfClinics.Add(animal);
            listOfClinics.Add(kaczor);

            return listOfClinics;
        }

        public static List<Dog> GetDogs()
        {
            Dog blacky = new Dog("BLACKY", new DateTime(2018, 05, 17), "Wyżeł Małopolski");
            blacky.Weight = 20;
            blacky.Vaccination = new DateTime(2021, 10, 01);
            blacky.Deworming = new DateTime(2021, 07, 28);
            blacky.MedicalHistory = new List<Visit> ();
            blacky.ClinicName = "Animal";

            Dog lucciano = new Dog("LUCCIANO", new DateTime(2015, 12, 24), "Lhasa Apso");
            lucciano.ClinicName = "Kaczor";

            Dog kaprys = new Dog("KAPRYS", new DateTime(2016, 02, 01), "Lhasa Apso");
            kaprys.ClinicName = "Kaczor";

            listOfDogs.Add(blacky);
            listOfDogs.Add(lucciano);
            listOfDogs.Add(kaprys);

            return listOfDogs;
        }

        public static List<Cat> GetCats()
        {
            Cat diesel = new Cat("DIESEL", new DateTime(2008, 01, 01), "Archangielska");
            diesel.ClinicName = "Kaczor";

            listOfCats.Add(diesel);

            return listOfCats;   
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
                int choiced = int.Parse(Console.ReadLine());
                return choiced;
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
                int choiced = ShowMenu();

                switch (choiced)
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
        private static int SelectAnimal()
        {
            Console.WriteLine($"Lista pacjentów: {Environment.NewLine} 1.Psy: {Environment.NewLine} 2.Koty: ");
            int selectedAnimal = int.Parse(Console.ReadLine());

            if (selectedAnimal == 1)
            {
                ShowListOfDogs();
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else if (selectedAnimal == 2)
            {
                ShowListOfCats();
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else
            {
                HandlingOfMenu();
            }

            return selectedAnimal;
        }

        private static void ShowListOfDogs() 
        {
            foreach (Dog element in listOfDogs)
            {
                Console.WriteLine(element.Name);
            }
        }

        private static void ShowListOfCats() 
        {
            foreach (Cat element in listOfCats)
            {
                Console.WriteLine(element.Name);
            }
        }

        private static void SelectPatient()
        {
            int selectedAnimal = SelectAnimal();

            string name = Console.ReadLine();
            string patientsName = name.ToUpper();

            switch (patientsName)
            {
                case "BLACKY":

                    Console.WriteLine(listOfDogs[0].ToString());
                    DogsMenu();

                    break;

                case "KAPRYS":

                    Console.WriteLine(listOfDogs[2].ToString());
                    DogsMenu();

                    break;

                case "LUCCIANO":

                    Console.WriteLine(listOfDogs[1].ToString());
                    DogsMenu();

                    break;

                case "DIESEL":

                    Console.WriteLine(listOfCats[0].ToString());
                    CatsMenu();

                    break;

                default:
                    SelectPatient();
                    break;
            }
        }

        private static void DogsMenu() 
        {
            int choiced;

            do
            {
                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                choiced = int.Parse(Console.ReadLine());

                if (choiced == 1)
                {
                    listOfDogs[0].AddsVisit();
                }
                else if (choiced == 2)
                {
                    listOfDogs[0].EditDog();
                }
                else if (choiced == 0)
                {
                    HandlingOfMenu();
                }
                else
                {
                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                }

            } while (choiced != 0);
        }

        private static void CatsMenu() 
        {
            int choiced;

            do
            {
                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                choiced = int.Parse(Console.ReadLine());

                if (choiced == 1)
                {
                    listOfCats[0].AddVisit();
                }
                else if (choiced == 2)
                {
                    listOfCats[0].EditCat();
                }
                else if (choiced == 0)
                {
                    HandlingOfMenu();
                }
                else
                {
                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                }

            } while (choiced != 0);
        }
        
        public static Dog AddDog()
        {
            Console.WriteLine("Podaj imię psa: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Podaj rasę: ");
            string newBreed = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia psa: ");
            DateTime newDateOfBirth = new DateTime();
            newDateOfBirth = DateTime.Parse(Console.ReadLine());

            Dog x = new Dog(newName, newDateOfBirth, newBreed);

            Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
            int choiced = int.Parse(Console.ReadLine());
            
            if (choiced == 1)
            {
                Console.WriteLine("Podaj wagę: ");
                int newWeight = int.Parse(Console.ReadLine());
                x.Weight = newWeight;
                Console.WriteLine("Podaj nazwe kliniki: ");
                string nameOfClinic = Console.ReadLine();
                x.ClinicName = nameOfClinic;
                Console.WriteLine("Podaj datę ostatniego szczepienia (rok, miesiąc, dzień) : ");
                DateTime newVaccination = new DateTime();
                newVaccination = DateTime.Parse(Console.ReadLine());
                x.Vaccination = newVaccination;
                Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
                DateTime newDeworming = new DateTime();
                newDeworming = DateTime.Parse(Console.ReadLine());
                x.Deworming = newDeworming;
            }
            else
            {
                HandlingOfMenu();
            }

            return x;
        }

        public static Cat AddCat()
        {
            Console.WriteLine("Podaj imię kota: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Podaj rasę: ");
            string newBreed = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia kota: ");
            DateTime newDateOfBirth = new DateTime();
            newDateOfBirth = DateTime.Parse(Console.ReadLine());

            Cat y = new Cat(newName, newDateOfBirth, newBreed);
            listOfCats.Add(y);

            Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
            int choiced = int.Parse(Console.ReadLine());
            
            if (choiced == 1)
            {
                Console.WriteLine("Podaj wagę: ");
                int newWeigth = int.Parse(Console.ReadLine());
                y.Weight = newWeigth;
                Console.WriteLine("Podaj nazwe kliniki: ");
                string nameOfClinic = Console.ReadLine();
                y.ClinicName = nameOfClinic;
                Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
                DateTime newDeworming = new DateTime();
                newDeworming = DateTime.Parse(Console.ReadLine());
                y.Deworming = newDeworming;
            }
            else
            {
             HandlingOfMenu();
            }

            return y;
        }
        
        private static void NextDates()
        { 
            Console.WriteLine("Najbliższe szczepienia: ");
            Console.WriteLine("BLACKY " + listOfDogs[0].NextVaccination());
            Console.WriteLine("LUCCIANO " + listOfDogs[1].NextVaccination());
            Console.WriteLine("KAPRYS" + listOfDogs[2].NextVaccination());
            Console.WriteLine("DIESEL" + listOfCats[0].NextVaccination());

            HandlingOfMenu();
        }

        private static void SelectClinic()
        {
            ShowListOfClinics();
            Console.WriteLine($"Aby zobaczyć profil kliniki podaj jej nazwę, jeżeli chcesz dodać nową klinikę wpisz 'nowa' {Environment.NewLine} Lista klinik: ");
            
            try
            {
                string name = Console.ReadLine();
                string nameOfClinic = name.ToUpper();

                try
                {
                    switch (nameOfClinic)
                    {
                        case "ANIMAL":

                            Console.WriteLine(listOfClinics[0].ToString());
                            ClinicsMenu();
                            break;

                        case "KACZOR":

                            Console.WriteLine(listOfClinics[1].ToString());
                            ClinicsMenu();
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

        private static void ShowListOfClinics() 
        {
            foreach (Clinic element in listOfClinics)
            {
                Console.WriteLine(element.Name);
            }
        }

        private static void ClinicsMenu() 
        {
            int choiced;
            do
            {
                Console.WriteLine($"Co chcesz zrobic? {Environment.NewLine} 1. Edytuj dane kliniki {Environment.NewLine} 0.Powrót");
                choiced = int.Parse(Console.ReadLine());

                if (choiced == 1)
                {
                    listOfClinics[0].EditClinicData();
                }
                else if (choiced == 0)
                {
                    SelectClinic();
                }
                else
                {
                    HandlingOfMenu();
                }
            } while (choiced != 0);
        }
       private static Clinic AddClinic()
        {
            Console.WriteLine("Podaj nazwę kliniki");
            string newName = Console.ReadLine();
            Console.WriteLine("Podaj adres: ");
            string newAddress = Console.ReadLine();
            Console.WriteLine("Podaj numer kontaktowy: ");
            string newContact = Console.ReadLine();
            Console.WriteLine("Podaj usługi weterynaryjne: ");
            string newService = Console.ReadLine();
            Console.WriteLine("Dodaj lekarza weterynarii");
            string newDoctor = Console.ReadLine();

            Clinic z = new Clinic(newName, newAddress);
            z.Contact.Add(newContact);
            z.Service.Add(newService);
            z.Doctors.Add(newDoctor);

            return new Clinic(newName, newAddress);

        }


    }
}




