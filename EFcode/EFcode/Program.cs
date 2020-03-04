using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcode
{
    class Program
    {
        static void Main(string[] args)
        {


            var context = new DatabaseFirstDemoEntities();


            var post = new Post()
            {

                Body="hello rabiranjan ",
                DatePublished=  DateTime.Now,
                Title="ok hete ",
                PostID=1


            };


            context.Posts.Add(post);
            context.SaveChanges();
            Console.ReadKey();

        }
    }
}
