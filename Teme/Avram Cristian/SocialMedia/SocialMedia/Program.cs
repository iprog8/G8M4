using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    class Program
    {
         
        static void Main(string[] args)
        {
            Social_MediaEntities db = new Social_MediaEntities();
            ICollection<Utilizator> utilizatori = db.Utilizators.ToList();
            ICollection<Postare> postari = db.Postares.ToList();
            Console.ReadKey();
            Utilizator u = new Utilizator();
            u.Address = "Craiova";
        }
    }
}
