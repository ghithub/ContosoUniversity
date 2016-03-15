using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class StudentsViewModel
    {
        private SchoolContext db = new SchoolContext();
        public Student Student { get; set; }
        public IList<Student> Students { get; set; }

        public StudentsViewModel()
        {
            Student = new Student();
            Students = db.Students.ToList();
        }
    }
}