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
    public class EditViewModel
    {
        private SchoolContext db = new SchoolContext();
        public Student Student { get; set; }
        public string Title = "Edit";

        public EditViewModel()
        {
            Student = new Student();
        }

        public EditViewModel(int? id)
        {
            Student = db.Students.Find(id);
        }

        public int UpdateStudent(Student student)
        {
            try
            {
                Student old = db.Students.Find(student.ID);
                old.LastName = student.LastName;
                old.FirstMidName = student.FirstMidName;
                old.EnrollmentDate = student.EnrollmentDate;
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