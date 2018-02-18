using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students_Record_Web.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string RegistrationId { get; set; }
        public string Roll { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

         public string Department { get; set; }
        [Display(Name="Upload Photo")]
        public string ImagePath { get; set; }
    }
}