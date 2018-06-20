using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace MvcApplication1.Models
{
    public class Results_Information_viewmodel6
    {

        [Required(ErrorMessage = "Please provide a Student ID", AllowEmptyStrings = false)]
        public long StudentId { get; set; }
        public string Term { get; set; }
        public Nullable<int> Bengali1st { get; set; }
        public Nullable<int> English1st { get; set; }
        public Nullable<int> Mathematics { get; set; }
        public Nullable<int> Science { get; set; }
        public Nullable<int> Bangladesh_and_Global_Studies { get; set; }
        public Nullable<int> Religion { get; set; }
        public Nullable<int> Drawing { get; set; }
        public Nullable<int> Physical_Education { get; set; }
        public Nullable<int> ICT { get; set; }
        public Nullable<int> Bengali2nd { get; set; }
        public Nullable<int> English2nd { get; set; }
        public Nullable<int> TotalMarks { get; set; }
        public Nullable<double> Gpa { get; set; }
        public Nullable<int> TotalSubject { get; set; }
    


    }
}