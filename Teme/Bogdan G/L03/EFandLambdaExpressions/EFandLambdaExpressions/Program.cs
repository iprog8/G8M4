using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFandLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            /*client.Insert("Mioveni", "Romania", "Geagu", "Bogdan", "0770648465");
            client.Insert("RosioriDeVede", "Romania", "Pirvan", "Cristiana", "0720444584");*/
            client.Update(5, "Ion", "Ion");
            Comenzi comenzi = new Comenzi();
            comenzi.GetAll();
            comenzi.GetById(14);
            client.SelectByCity("Paris");
            Console.ReadKey();
        }
    }
}
