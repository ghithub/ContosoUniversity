using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class CreateViewModel
    {
        private SchoolContext db = new SchoolContext();
        public Student Student { get; set; }
        public string Title = "Create";

        public CreateViewModel()
        {
            Student = new Student();
        }

        public CreateViewModel(string lastName, string firstName, DateTime enrollmentDate)
        {
            Student = new Student { LastName = lastName, FirstMidName = firstName, EnrollmentDate = enrollmentDate };
        }

        public int SaveStudent()
        {
            try
            {
                db.Students.Add(Student);
                return db.SaveChanges();
            }
            catch (DataException de)
            {
                //log the exception.
                return -1;
            }
        }
    }
}