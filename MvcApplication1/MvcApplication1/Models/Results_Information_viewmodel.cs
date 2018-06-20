using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MvcApplication1.Models
{
    public class Results_Information_viewmodel
    {
        [Required(ErrorMessage = "Please provide a Student ID", AllowEmptyStrings = false)]
        public long StudentId { get; set; }
        public Nullable<int> Bengali { get; set; }
        public Nullable<int> English { get; set; }
        public Nullable<int> Mathematics { get; set; }
        public Nullable<int> Bangladesh_and_Global_Studies { get; set; }
        public Nullable<int> Science { get; set; }
        public Nullable<int> Religion { get; set; }
        public int TotalSubject { get; set; }
        public int TotalMarks { get; set; }
        public double Gpa { get; set; }
        public string Term { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Class { get; set; }
    }



   

}