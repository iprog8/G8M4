using CrmManager.Managers;
using CrmManager.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager
{
    class Program
    {
        private static string IdInvalid = "Id-ul pe care l-ati introdus este invalid, mai incercati...";
        private static string TastaGresita = "Ai apasat tasta gresita... Mai incearca...";
        /*        Cand porneste aplicatia sa avem urmatoarele optiuni: 
                    afiseaza clienti,
                    adauga client, 
                    modifica client,
                    sterge client,
                    afiseaza furnizori,
                    adauga furnizor,
                    modifica furnizor,
                    sterge furnizor.
                    Implementati fiecare functionalitate.*/
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            SupplierManager supplierManager = new SupplierManager();
            Console.WriteLine("Bun venit la aplicatia noastra CRM, \nCe actiune vreti sa faceti?");
            ChooseOption(customerManager, supplierManager);
        }
        private static void ChooseOption(CustomerManager customersManager, SupplierManager supplierManager)
        {
            Console.WriteLine("\n1.Afiseaza Clienti, \n2.Adauga Client, \n3.Modifica Client, \n4.Sterge Client,");
            Console.WriteLine("5.Afiseaza Furnizori, \n6.Adauga Furnizor, \n7.Modifica Furnizori, \n8.Sterge Furnizor.");
            ConsoleKeyInfo tastaApasata = Console.ReadKey();
            switch (tastaApasata.Key)
            {
                case ConsoleKey.D1:
                    customersManager.Display();
                    break;
                case ConsoleKey.D2:
                    Customer customer = new Customer();
                    Console.WriteLine($"\nIntroduceti numele noului client:");
                    customer.FirstName = ProcessText("Numele noului client");
                    Console.WriteLine($"\nIntroduceti prenumele noului client");
                    customer.LastName = ProcessText("Prenumele noului client");
                    Console.WriteLine($"\nIntroduceti tara noului client");
                    customer.Country = ProcessText("Tara noului client");
                    Console.WriteLine($"\nIntroduceti orasul noului client");
                    customer.City = ProcessText("Orasul noului client");
                    customersManager.Add(customer);
                    Console.WriteLine("Client-ul a fost creat cu succes");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("\nIntroduceti id-ul clientului pe care vreti sa il modificati");
                    int id = GeoptV2(customersManager);
                    Customer tempCustomer = customersManager.GetCustomerById(id);
                    Console.WriteLine($"Prenumele: {tempCustomer.FirstName} \nNumele: {tempCustomer.LastName} \nTara: {tempCustomer.Country} \nOrasul: {tempCustomer.City} \nTelefonul: {tempCustomer.Phone}");
                    Console.WriteLine("Introduceti noul dvs prenume");
                    string prenume = ProcessText("Noul dvs prenume");
                    Console.WriteLine("Introduceti noul dvs nume:");
                    string nume = ProcessText("Noul dvs nume");
                    Console.WriteLine("Introduceti noul dvs oras");
                    string oras = ProcessText("Noul dvs oras");
                    Console.WriteLine("Introduceti noua dvs tara");
                    string tara = ProcessText("Noua dvs tara");
                    customersManager.Modify(id, nume, prenume, tara, oras);
                    Console.WriteLine("Clientul a fost modificat cu succes");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("\nIntroduceti id-ul clientului pe care vreti sa il stergeti");
                    customersManager.Delete(GeoptV2(customersManager));
                    Console.WriteLine("Client-ul a fost sters");
                    break;
                case ConsoleKey.D5:
                    supplierManager.Display();
                    break;
                case ConsoleKey.D6:
                    Supplier tempSupplier = new Supplier();
                    Console.WriteLine($"Introduceti numele companiei!");
                    tempSupplier.CompanyName = ProcessText("Numele companiei");
                    Console.WriteLine("Introduceti numele de contact");
                    tempSupplier.ContactName = ProcessText("Numele de contact");
                    Console.WriteLine("Introduceti titlul de contact");
                    tempSupplier.ContactTitle = ProcessText("Titlul de contact");
                    Console.WriteLine("Introduceti orasul dvs");
                    tempSupplier.City = ProcessText("Introduceti orasul");
                    Console.WriteLine("Introduceti tara dvs");
                    tempSupplier.Country = ProcessText("Introduceti tara");
                    Console.WriteLine("Introduceti numarul de telefon!");
                    tempSupplier.Phone = ProcessNumber("Numar de telefon");
                    supplierManager.Add(tempSupplier);
                    Console.WriteLine("Furnizorul a fost adaugat!");
                    break;
                case ConsoleKey.D7:
                    Console.WriteLine("Introduceti id-ul pe care vreti sa il modificati");
                    int suppId = Geopt(supplierManager);
                    Supplier tempSupp = new CRMEntities().Suppliers.Find(suppId);
                    Console.WriteLine($"\nNumele companiei: {tempSupp.CompanyName} \nNumele de contact: {tempSupp.ContactName} \nTitlul de contact: {tempSupp.ContactTitle} \nOrasul: {tempSupp.City} \nTara: {tempSupp.Country} \nTelefon: {tempSupp.Phone}");
                    Console.WriteLine("Introduceti noul nume al companiei:");
                    string CompanyName = ProcessText("Numele companiei");
                    Console.WriteLine("Introduceti noul nume de contact:");
                    string ContactName = ProcessText("Numele de contact");
                    Console.WriteLine("Introduceti noul nume noul titlu de contact:");
                    string ContactTitle = ProcessText("Titlul de contact");
                    Console.WriteLine("Introduceti noul oras:");
                    string City = ProcessText("Oras");
                    Console.WriteLine("Introduceti noua tara:");
                    string Country = ProcessText("Tara");
                    Console.WriteLine("Introduceti noul telefon:");
                    string Phone = ProcessNumber("Telefon");
                    supplierManager.Modify(suppId, CompanyName, ContactName, ContactTitle, City, Country, Phone);
                    Console.WriteLine("Furnizorul a fost modificat cu succes!");
                    break;
                case ConsoleKey.D8:
                    Console.WriteLine("Introduceti id-ul pe care vreti sa il stergeti!");
                    supplierManager.Delete(Geopt(supplierManager));
                    Console.WriteLine("Furnizorul a fost sters!");
                    break;
                default:
                    Console.WriteLine(TastaGresita);
                    ChooseOption(customersManager, supplierManager);
                    break;
            }
            CanContinue(customersManager, supplierManager);
        }
        private static void CanContinue(CustomerManager customersManager, SupplierManager supplierManager)
        {
            Console.WriteLine("\nDoriti sa faceti alta operatiune?");
            Option(customersManager, supplierManager);
        }
        private static void Option(CustomerManager customersManager, SupplierManager supplierManager)
        {
            Console.WriteLine("1.Da \n2.Nu");
            ConsoleKeyInfo tasta = Console.ReadKey();
            switch (tasta.Key)
            {
                case ConsoleKey.D1:
                    ChooseOption(customersManager, supplierManager);
                    break;
                case ConsoleKey.D2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(TastaGresita);
                    Option(customersManager, supplierManager);
                    break;
            }
        }
        private static string ProcessText(string nameOfValue)
        {
            string value = Console.ReadLine();
            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c)) continue;
                else if (!char.IsLetter(c))
                {
                    Console.WriteLine($"{nameOfValue} nu contine doar litere, mai incearca...");
                    return ProcessText(nameOfValue);
                }
            }
            if (!char.IsUpper(value.FirstOrDefault()))
            {
                Console.WriteLine($"{nameOfValue} nu incepe cu o litera mare, mai incearca...");
                return ProcessText(nameOfValue);
            }
            return value;
        }
        private static string ProcessNumber(string nameOfValue)
        {
            string value = Console.ReadLine();
            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c)) continue;
                else if (!char.IsDigit(c))
                {
                    Console.WriteLine($"{nameOfValue} nu contine doar numere, mai incearca...");
                    return ProcessNumber(nameOfValue);
                }
            }
           return value;
        }
        public static int Geopt(SupplierManager supplierManager)
        {
            string id = Console.ReadLine();
            if (!supplierManager.VerifyId(id))
            {
                Console.WriteLine(IdInvalid);
                return Geopt(supplierManager);
            }
            return int.Parse(id);
        }
        public static int GeoptV2(CustomerManager customersManager)
        {
            
            string id = Console.ReadLine();
            if (!customersManager.VerifyId(id))
            {
                Console.WriteLine(IdInvalid);
                return GeoptV2(customersManager);
            }
            return int.Parse(id);
        }
    }
}
