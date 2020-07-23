using L2_SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_SM
{
    class Program
    {
        static void Main(string[] args)
        {
            MVCEntities db = new MVCEntities();
            List<User> users = db.Users.ToList();
            List<UserPost> userPost = db.UserPosts.Where(o => o.UserID == 1 ).ToList();
            List<Picture> picture = db.Pictures.ToList();
            Console.WriteLine($"{userPost.Count}");
            Console.ReadKey();
        }
    }
}
