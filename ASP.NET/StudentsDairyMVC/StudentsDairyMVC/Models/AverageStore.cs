using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsDairyMVC.Models
{
    public class AverageStore
    {
        private List<Student> scoreAvg = new List<Student>();
        public int NumberOfPerson

        {
            get { return scoreAvg.Count(); }

        }
    }
}