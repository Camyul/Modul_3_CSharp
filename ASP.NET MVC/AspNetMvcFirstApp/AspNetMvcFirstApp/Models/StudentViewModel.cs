using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvcFirstApp.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]  //Server-Side Validation
        [StringLength(50)] // Max lenght
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is Need")] // Custom error message
        public string LastName { get; set; }

        [Required]
        [Range(0, 150)] //Range validation
        public int Age { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}