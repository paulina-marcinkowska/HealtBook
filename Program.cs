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
        static Pies blacky, kaprys, lucciano;
        static Kot diesel;
        static Clinic animal, kaczor;
        static List<Pies> listaPsow = new List<Pies>();
        static List<Kot> listaKotow = new List<Kot>();
        static List<Clinic> listOfClinic = new List<Clinic>();
        static List<Visit> historiaChoroby = new List<Visit>();

        static void Main(string[] args)
        {

            listaPsow = PobierzPsy();
            listaKotow = PobierzKoty();
            listOfClinic = DownloadClinics();
            SaveData();

            ObslugaMenu();
        }


        public static List<Pies> PobierzPsy()
        {
           
            Pies blacky = new Pies("BLACKY", new DateTime(2018, 05, 17), "Wyżeł Małopolski");
            blacky.Waga = 20;
            blacky.Szczepienie = new DateTime(2021, 10, 01);
            blacky.Odrobaczanie = new DateTime(2021, 07, 28);
            blacky.HistoriaChoroby = new List<Visit> ();
            blacky.Clinic = animal;

            Pies lucciano = new Pies("LUCCIANO", new DateTime(2015, 12, 24), "Lhasa Apso");
            lucciano.Clinic = kaczor;

            Pies kaprys = new Pies("KAPRYS", new DateTime(2016, 02, 01), "Lhasa Apso");
            kaprys.Clinic = kaczor;
            List<Pies> listaPsow = new List<Pies>();
            listaPsow.Add(blacky);
            listaPsow.Add(lucciano);
            listaPsow.Add(kaprys);

            return listaPsow;
        }

        public static List<Kot> PobierzKoty()
        {
            Kot diesel = new Kot("DIESEL", new DateTime(2008, 01, 01), "Archangielska");
            diesel.Clinic = kaczor;

            List<Kot> listaKotow = new List<Kot>();
            listaKotow.Add(diesel);

            return listaKotow;
            
        }

        public static List<Clinic> DownloadClinics()
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
            SaveXml.SaveDataXml(listaPsow);
            SaveXml.SaveDataXml(listaKotow);
            SaveXml.SaveDataXml(listOfClinic);
        }

        private static int PokazMenu()
        {
            Console.WriteLine($"Spis treści: { Environment.NewLine} 1.Pacjenci { Environment.NewLine} 2.Dodaj pacjenta { Environment.NewLine} 3.Najbliższe terminy { Environment.NewLine} 4.Kliniki {Environment.NewLine} 5.Zakończ ");
            try
            {
              int wybor = int.Parse(Console.ReadLine());
                return wybor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                int blad = 0;
                PokazMenu();
                return blad;
            }
        }
        private static void ObslugaMenu()
    {
        try
        {
                int wybor = PokazMenu();

                switch (wybor)
            {
                case 1:
                    WybierzPacjenta();
                    break;

                case 2:
                    Console.WriteLine("Jeżeli chcesz dodać psa wybierz '1', aby dodać kota - wybierz '2' ");
                    int piesKot = int.Parse(Console.ReadLine());
                    if (piesKot == 1)
                    {
                        DodajPsa();
                    }
                    else if (piesKot == 2)
                    {
                        DodajKota();
                    }
                    else
                    {
                        ObslugaMenu();
                    }
                    break;

                    case 3:
                        najblizszeTerminy();
                        break;

                    case 4:
                        SelectClinic();
                    break;
                }
        }
        catch (Exception e)
        {
                Console.WriteLine(e.Message);
                PokazMenu();
            }
        }

        private static void WybierzPacjenta() 
    {


            Console.WriteLine($"Lista pacjentów: {Environment.NewLine} 1.Psy: {Environment.NewLine} 2.Koty: ");
            int piesKot = int.Parse(Console.ReadLine());

            if (piesKot == 1)
            {
                foreach (Pies element in listaPsow)
                {
                    Console.WriteLine(element.Imie);
                }
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else if (piesKot == 2)
            {
                foreach (Kot element in listaKotow)
                {
                    Console.WriteLine(element.Imie);
                }
                Console.WriteLine($"Aby zobaczyć profil pacjenta wpisz jego imię{Environment.NewLine} 0.Powrót");
            }
            else
            {
                ObslugaMenu();
            }

            string imie = Console.ReadLine();
            string imiePacjenta = imie.ToUpper();
            int wybor;

                    switch (imiePacjenta)
                    {
                        case "BLACKY":
                    blacky.WypiszDane();
                    do
                    {
                        Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                        wybor = int.Parse(Console.ReadLine());
                        if (wybor == 1)
                        {
                            blacky.AddsVisit();
                        }
                        else if (wybor == 2)
                        {
                            blacky.EdytujDanePsa();
                        }
                        else if (wybor == 0)
                        {
                            ObslugaMenu();
                        }
                        else
                        {
                            Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                        }  
                    } while (wybor != 0);

                                break; 

                        case "KAPRYS":
                    kaprys.WypiszDane();

                            do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                wybor = int.Parse(Console.ReadLine());
                                if (wybor == 1)
                                {
                                    kaprys.AddVisit();
                                }
                                else if (wybor == 2)
                                {
                                    kaprys.EdytujDanePsa();
                                }
                                else if (wybor == 0)
                                {
                                    ObslugaMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                } 
                            } while (wybor != 0);

                            break;

                        case "LUCCIANO":
                    lucciano.WypiszDane();
                            do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                wybor = int.Parse(Console.ReadLine());
                                if (wybor == 1)
                                {
                                    lucciano.AddVisit();
                                }
                                else if (wybor == 2)
                                {
                                    lucciano.EdytujDanePsa();
                                }
                                else if (wybor == 0)
                                {
                                    ObslugaMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                } 
                            } while (wybor != 0);

                                break;

                        case "DIESEL":
                            foreach (Kot element in listaKotow)
                            {
                                element.WypiszDane(diesel);
                            }
                            do
                            {
                                Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                wybor = int.Parse(Console.ReadLine());
                                if (wybor == 1)
                                {
                                    diesel.AddVisit();
                                }
                                else if (wybor == 2)
                                {
                                    diesel.EdytujDaneKota();
                                }
                                else if (wybor == 0)
                                {
                                    ObslugaMenu();
                                }
                                else
                                {
                                    Console.WriteLine($"1. Dodaj wpis do historii choroby {Environment.NewLine} 2.Aktualizuj dane {Environment.NewLine} 0.Powrót");
                                }

                            } while (wybor != 0);
                            break;

                        default:
                        WybierzPacjenta();
                        break;

                    }
            }

        public static Pies DodajPsa()
    {
        Console.WriteLine("Podaj imię psa: ");
        string noweImie = Console.ReadLine();
        Console.WriteLine("Podaj rasę: ");
        string nowaRasa = Console.ReadLine();
        Console.WriteLine("Podaj datę urodzenia psa: ");
        DateTime nowaDataUrodzenia = new DateTime();
        nowaDataUrodzenia = DateTime.Parse(Console.ReadLine());

        Pies x = new Pies(noweImie, nowaDataUrodzenia, nowaRasa);

        Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
        int wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                Console.WriteLine("Podaj wagę: ");
                int nowaWaga = int.Parse(Console.ReadLine());
                x.Waga = nowaWaga;
                Console.WriteLine("Podaj nazwe kliniki: ");
                string nName = Console.ReadLine();
                x.Clinic.Name = nName;
                Console.WriteLine("Podaj adres kliniki: ");
                string nAddress = Console.ReadLine();
                x.Clinic.Address = nAddress;
                Console.WriteLine("Podaj datę ostatniego szczepienia (rok, miesiąc, dzień) : ");
                DateTime noweSzczepienie = new DateTime();
                noweSzczepienie = DateTime.Parse(Console.ReadLine());
                x.Szczepienie = noweSzczepienie;
                Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
                DateTime noweOdrobaczanie = new DateTime();
                noweOdrobaczanie = DateTime.Parse(Console.ReadLine());
                x.Odrobaczanie = noweOdrobaczanie;
            }            
        else
        {
                        ObslugaMenu();
        }
            SaveData();

            return x;
    }
        public static Kot DodajKota()
        {
            Console.WriteLine("Podaj imię kota: ");
            string noweImie = Console.ReadLine();
            Console.WriteLine("Podaj rasę: ");
            string nowaRasa = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia kota: ");
            DateTime nowaDataUrodzenia = new DateTime();
            nowaDataUrodzenia = DateTime.Parse(Console.ReadLine());

            Kot y = new Kot(noweImie, nowaDataUrodzenia, nowaRasa);
            listaKotow.Add(y);

            Console.WriteLine("Jeżeli chcesz uzupełnić dodatkowe dane pacjenta (np. waga, szczepienie) wybierz '1', aby powrócić do spisu treści wybierz '0'  ");
            int wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
            Console.WriteLine("Podaj wagę: ");
            int nowaWaga = int.Parse(Console.ReadLine());
            y.Waga = nowaWaga;
            Console.WriteLine("Podaj nazwe kliniki: ");
            string nName = Console.ReadLine();
            y.Clinic.Name = nName;
            Console.WriteLine("Podaj adres kliniki: ");
            string nAddress = Console.ReadLine();
            y.Clinic.Address = nAddress;
            Console.WriteLine("Podaj datę ostatniego odrobaczania : ");
            DateTime noweOdrobaczanie = new DateTime();
            noweOdrobaczanie = DateTime.Parse(Console.ReadLine());
            y.Odrobaczanie = noweOdrobaczanie;

            }
            else
            {
             ObslugaMenu();
            }
            SaveData();

            return y;
        }
        private static void najblizszeTerminy()
          {
              PobierzPsy();

              Console.WriteLine("Najbliższe szczepienia: ");
              Console.WriteLine("BLACKY " + blacky.ZaIleSzczepienie(blacky.Szczepienie));
              Console.WriteLine("LUCCIANO " + lucciano.ZaIleSzczepienie(lucciano.Szczepienie));
              Console.WriteLine("KAPRYS" + kaprys.ZaIleSzczepienie(kaprys.Szczepienie));

              ObslugaMenu();
          }
        
       private static void SelectClinic()
        {
            List<Clinic> listOfClinic = DownloadClinics();

            Console.WriteLine($"Aby zobaczyć profil kliniki podaj jej nazwę, jeżeli chcesz dodać nową klinikę wpisz 'nowa' {Environment.NewLine} Lista klinik: ");
            foreach (Clinic element in listOfClinic)
            {
                Console.WriteLine(element.Name);
            }
            try
            {
                string nazwa = Console.ReadLine();
                string nazwaKliniki = nazwa.ToUpper();
                int wybor;

                try
                {
                    switch (nazwaKliniki)
                    {
                        case "ANIMAL":
                            animal.WriteOutData();
                            Console.WriteLine($"Co chcesz zrobic? {Environment.NewLine} 1. Edytuj dane kliniki {Environment.NewLine} 0.Powrót");
                            wybor = int.Parse(Console.ReadLine());
                            if (wybor == 1)
                                {
                                   animal.EditClinicData();
                                                            }
                                                         else if (wybor == 0)
                                                   {
                                                        SelectClinic();
                                                 }
                                                else
                                             {
                                               ObslugaMenu();
                                         }
                                        break;

                                    case "KACZOR":
                                        kaczor.WriteOutData();
                                     Console.WriteLine($"Co chcesz zrobic? {Environment.NewLine} 1. Edytuj dane kliniki {Environment.NewLine} 0. Powrót");
                                  wybor = int.Parse(Console.ReadLine());
                            if (wybor == 1)
                                {
                                                               kaczor.EditClinicData();
                                       }
                                                       else if (wybor == 0)
                                                     {
                                                       SelectClinic();
                                             }
                                            else
                                           {
                                              ObslugaMenu();
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
                                    ObslugaMenu();
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




