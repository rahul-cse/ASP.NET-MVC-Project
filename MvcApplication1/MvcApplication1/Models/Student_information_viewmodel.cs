using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Student_information_viewmodel
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Class { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Group { get; set; }
        public string Gender { get; set; }
        public string PresentAddress { get; set; }
    }
}