using Microsoft.AspNetCore.Mvc;
using MVC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class ExportController : Controller
    {
        private ApplicationDbContext _db;
        public ExportController( ApplicationDbContext db)
        {
            _db = db;
        }

    public IActionResult Index()
        {
            List<Student> stulist = (from e in _db.Students select e).ToList();
            return View(stulist);
        }
        

        [HttpPost]
        public IActionResult Export()
        {
            List<object> students = (from s in _db.Students.Take(10).ToList()
                                     select new
                                     {
                                         s.StudentId,
                                         s.Name,
                                         s.Class,
                                         s.Roll_No
                                     }).ToList<object>();

            students.Insert(0, new string[4] { "Student ID", "Name", "Class", "Roll_No" });

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < students.Count; i++)
            {
                string[] customer = (string[])students[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    sb.Append(customer[j] + ',');
                }
                sb.Append("\r\n");
            }
            return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }

    }
}
