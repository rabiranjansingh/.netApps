using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurdApps.Controllers
{
    public class HomeController : Controller
    {


        MyContext context = new MyContext();
        public ActionResult Index()
        {

            var students = (from s in context.Students
                            orderby s.FirstMidName
                            select s).ToList<Student>();

            System.Diagnostics.Debug.WriteLine("Retrieve all Students from the database:");
            foreach (var stdnt in students)
            {
                string name = stdnt.FirstMidName + " " + stdnt.LastName;
                Console.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
                System.Diagnostics.Debug.WriteLine("ID: {0}, Name: {1}", stdnt.ID, name);
            }

            System.Diagnostics.Debug.WriteLine("Press any key to exit...");
            return View();
        }
    }
}