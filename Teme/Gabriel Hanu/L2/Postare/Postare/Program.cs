using FirstDbModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstDbModel
{
    class Program
    {
        static void Main(string[] args)
        {
            MVCEntities db = new MVCEntities();
            Random rnd = new Random();
            List<Utilizator> utilizatori = db.Utilizators.ToList();
            List<Postare> postari = db.Postares.ToList();
            List<Poza> poze = db.Pozas.ToList();
            //Codul de jos nu are nici o logica, dar am vrut sa testez putin proprietatile + random
            Console.WriteLine($"Utilizatorul tau random este {utilizatori[rnd.Next(0, utilizatori.Count)].Nume}");
            Console.WriteLine($"Postarea ta random este {postari[rnd.Next(0, postari.Count)].Titlu}");
            Console.WriteLine("Poza ta random se va deschide imediat...");
            Thread.Sleep(3000);
            Process.Start(poze[rnd.Next(0,poze.Count)].DrumSprePoza);
            Console.ReadKey();
        }
    }
}
