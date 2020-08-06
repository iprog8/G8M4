using CrmManager.Managers;
using CrmManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager
{
    class Program
    {
/*        Cand porneste aplicatia sa avem urmatoarele optiuni: 
            afiseaza clienti,
            adauga client, 
            modifica client,
            sterge client,
            afiseaza furnizori,
            adauga furnizor,
            modifica furnizor,
            sterge furnizor.
            Implementati fieccare functionalitate.*/
        static void Main(string[] args)
        {
            CustomersManager customersManager = new CustomersManager();
            SupplierManager supplierManager = new SupplierManager();
            //Create the managers for the customers and suppliers

            //Display the options for the user to choose
            Console.WriteLine("Bun venit la aplicatia noastra CRM, \nCe actiune vreti sa faceti?\n");
            Console.WriteLine("1.Afiseaza Clienti, \n2.Adauga Client, \n3.Modifica Client, \n4.Sterge Client,");
            Console.WriteLine("5.Afiseaza Furnizori, \n6.Adauga Furnizor, \n7.Modifica Furnizori, \n8.Sterge Furnizor.");
            //Store the information from the keyboard
            ConsoleKeyInfo tastaApasata = Console.ReadKey();

            switch (tastaApasata.Key)
            {
                case ConsoleKey.D1:
                    customersManager.DisplayCustomers();
                    break;
                case ConsoleKey.D2:
                    Customer customer = new Customer();
                    Console.WriteLine($"\nIntroduceti numele noului client:");
                    customer.FirstName = Console.ReadLine();
                    Console.WriteLine($"\nIntroduceti prenumele noului client");
                    customer.LastName = Console.ReadLine();
                    Console.WriteLine($"\nIntroduceti tara noului client");
                    customer.Country = Console.ReadLine();
                    Console.WriteLine($"\nIntroduceti orasul noului client");
                    customer.City = Console.ReadLine();
                    customersManager.AddCustomer(customer);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("\nIntroduceti id-ul clientului pe care vreti sa il modificati");
                    string id = Console.ReadLine();
                    if(int.TryParse(id, out int newId))
                    {
                        Customer tempCustomer = customersManager.GetCustomerById(newId);
                        if(tempCustomer != null)
                        {
                            Console.WriteLine($"Prenumele: {tempCustomer.FirstName} \nNumele: {tempCustomer.LastName} \nTara: {tempCustomer.Country} \nOrasul: {tempCustomer.City} \nTelefonul: {tempCustomer.Phone}");
                            Console.WriteLine("Introduceti noul dvs prenume");
                            string prenume = Console.ReadLine();
                            Console.WriteLine("Introduceti noul dvs nume:");
                            string nume = Console.ReadLine();
                            Console.WriteLine("Introduceti noul dvs oras");
                            string oras = Console.ReadLine();
                            Console.WriteLine("Introduceti noua dvs tara");
                            string tara = Console.ReadLine();
                            customersManager.ModifyCustomer(newId, nume, prenume, tara,oras);
                        }
                    }
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("\nIntroduceti id-ul clientului pe care vreti sa il stergeti");
                    string id2 = Console.ReadLine();
                    if(int.TryParse(id2, out int newId2))
                    {
                        if (customersManager.DeleteCustomer(newId2))
                            Console.WriteLine("Clientul a fost sters cu succes");
                        else
                            Console.WriteLine("Id-ul este invalid");
                    }
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
                    Console.WriteLine($"Numele companiei: {tempSupp.CompanyName} \nNumele de contact: {tempSupp.ContactName} \nTitlul de contact: {tempSupp.ContactTitle} \nOrasul: {tempSupp.City} \nTara: {tempSupp.Country} \nTelefon: {tempSupp.Phone}");
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
                    break;
            }
            Console.ReadKey();
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
                Console.WriteLine("Id-ul pe care l-ati introdus este inval id, mai incercati...");
                return Geopt(supplierManager);
            }
            return int.Parse(id);
        }
    }
}
