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
            //Create the managers for the customers and suppliers
            CustomersManager customersManager = new CustomersManager();

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
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
