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

        public int Update(Student student)
        {
            try
            {
                Student  = db.Students.Find(student.ID);
                Student.LastName = student.LastName;
                Student.FirstMidName = student.FirstMidName;
                Student.EnrollmentDate = student.EnrollmentDate;
                return db.SaveChanges();
            }
            catch (DataException de)
            {
                //log the exception.
                return -1;
            }
        }

        public int Delete()
        {
            try
            {
                var removedStudent = db.Students.Remove(Student);
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