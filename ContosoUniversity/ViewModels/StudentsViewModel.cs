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
        public string NameSortOrder { get; set; }
        public string DateSortOrder { get; set; }

        public StudentsViewModel(){
        }

        public StudentsViewModel(string sortOrder)
        {
            Student = new Student();
            Students = db.Students.ToList();

            switch (sortOrder)
            {
                case "name_desc":
                    NameSortOrder = sortOrder;
                    Students = Students.OrderByDescending(s => s.LastName).ToList();
                    break;
                case "Date":
                    DateSortOrder = sortOrder;
                    Students = Students.OrderBy(s => s.EnrollmentDate).ToList();
                    break;
                case "date_desc":
                    Students = Students.OrderByDescending(s => s.EnrollmentDate).ToList();
                    break;
                default:
                    Students = Students.OrderBy(s => s.LastName).ToList();
                    break;
            }
        }
    }
}