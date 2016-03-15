using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class DetailsViewModel
    {
        private SchoolContext db = new SchoolContext();
        public Student Student { get; set; }
        public string Title = "Details";

        public DetailsViewModel(int? id)
        {
            Student = db.Students.Find(id);
        }
    }
}