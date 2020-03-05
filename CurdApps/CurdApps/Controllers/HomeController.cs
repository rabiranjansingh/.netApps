using CurdApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Reflection;

namespace CurdApps.Controllers
{
    public class HomeController : Controller
    {


        MyContext context = new MyContext();
        public ActionResult Index()
        {

            WriteLog("======================================================= ");

            WriteLog(context.Students.Count().ToString());

            var students = (from s in context.Students
                            orderby s.FirstMidName
                            select s).ToList<Student>();

            WriteLog("Retrieve all Students from the database:");
            foreach (var stdnt in students)
            {
                string name = stdnt.FirstMidName + " " + stdnt.LastName;        
                WriteLog("ID: "+ stdnt.ID+" "+"  name   "+  name);          
            }



            int noOfRowUpdated = context.Database.ExecuteSqlCommand("SELECT TABLE_NAME FROM DatabaseFirstDemo.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'");
     

            return View(students);


        }


        public ActionResult  register()
        {


        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int AutoId { get; set; }

        //[Required]//using System.ComponentModel.DataAnnotations;
        //[Display(Name = "User name")]
        //public string UserName { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage =
        //"The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage =
        //"The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        //[Required]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Required]
        //[Display(Name = "Phone")]
        //public string PhoneNumber { get; set; }


            //if(userdata==null)
            //{
            //    WriteLog("post data is null ");
            //}
            //else
            //{
            //    WriteLog("post data is not null  ");
            //}

            //WriteLog("AutoId " + userdata.AutoId + " UserName" +userdata.UserName+ "  Password  " + userdata.Password);
            //context.RegisterViewModels.Add(userdata);
            //context.SaveChanges();
            return View();
        }



        public ActionResult create(RegisterViewModel userdata)
        {

            WriteLog("CREATE METHOD CALLED ");
            WriteLog("AutoId " + userdata.AutoId + " UserName" + userdata.UserName + "  Password  " + userdata.Password);

            return View(userdata);
        }



        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = @"E:\.net\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();

            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }

            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }

    }
}