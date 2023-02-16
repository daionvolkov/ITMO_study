using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsDairyMVC.Models
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}