using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcFirstApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}