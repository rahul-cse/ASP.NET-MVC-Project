using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;



namespace MvcApplication1.Controllers
{
    public class ResultsDb6Controller : Controller
    {
        //
        // GET: /ResultsDb6/

        public double begin;
        public static double  total;
        public static long s;
        public static string gpa;
        public static int join,i,j;
        public static int[] mix = new int[3];
        public static int[] eix = new int[3];

        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult Insertresultdb6(Results_Information_viewmodel6 model, string subject, string marks)
        {
            ViewBag.sid = model.StudentId;
            s = model.StudentId;

            MvcDatabase1Entities2 db = new MvcDatabase1Entities2();
            ResultDatabaseClass6 rd6 = new ResultDatabaseClass6();
            List<ResultDatabaseClass6> l6 = new List<ResultDatabaseClass6>();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            int m = Convert.ToInt32(marks);
            //if(subject!="Bengali1st" && subject != "Bengali2nd")
            //{
            //    double b = Convert.ToDouble(m);
            //    begin = grading(b);
            //}
            //else
            //{
            //    if(mix[1]!=0)
            //    {
            //        double b = Convert.ToDouble(mix[0] + mix[1]);
            //        begin = grading(b);
            //    }
                                

            //}
            
            
            //double b = Convert.ToDouble(m);
            ViewBag.gpa_ = gpa;

            //begin = grading(b);  //For Calling grading function 

            if (subject == "Bengali1st")
            {

                rd6.Bengali1st = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Bengali1st = '" + rd6.Bengali1st + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
                double n = Convert.ToDouble(m);
                n = Math.Ceiling(n / 2);
                 m = Convert.ToInt32(n);
                join = B1andB2(m);
            }
            if (subject == "Bengali2nd")
            {

                rd6.Bengali2nd = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Bengali2nd = '" + rd6.Bengali2nd + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
                join = B1andB2(m);
            }
            if (subject == "English1st")
            {

                rd6.English1st = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set English1st = '" + rd6.English1st + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
                double n = Convert.ToDouble(m);
                n = Math.Ceiling(n / 2);
                m = Convert.ToInt32(n);
                eix[j] = m;
                j++;
            }
            if (subject == "English2nd")
            {

                rd6.English2nd = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set English2nd = '" + rd6.English2nd + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
                eix[j] = m;
                j++;
            }

            if (subject == "Mathematics")
            {

                rd6.Mathematics = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Mathematics = '" + rd6.Mathematics + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }

            if (subject == "ICT")
            {

                rd6.ICT = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set ICT = '" + rd6.ICT+ "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }
            if (subject == "Science")
            {

                rd6.Science = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Science = '" + rd6.Science + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }
            if (subject == "Religion")
            {

                rd6.Religion = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Religion = '" + rd6.Religion + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }
            if (subject == "Physical_Education")
            {

                rd6.Physical_Education = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Physical_Education = '" + rd6.Physical_Education + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }
            if (subject == "Drawing")
            {

                rd6.Drawing = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Drawing = '" + rd6.Drawing + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }
            if (subject == "Bangladesh_and_Global_Studies")
            {

                rd6.Bangladesh_and_Global_Studies = m;
                //l.Add(rd6);
                SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Bangladesh_and_Global_Studies = '" + rd6.Bangladesh_and_Global_Studies + "' where (StudentId = '" + model.StudentId + "')", con);
                cmd.ExecuteNonQuery();
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (subject != "Bengali1st" && subject != "Bengali2nd" && subject != "English1st" && subject != "English2nd")
            {
                double b = Convert.ToDouble(m);
                begin = grading(b);
            }
            else if (subject == "Bengali1st" || subject == "Bengali2nd")
            {
                if (mix[1] != 0)
                {
                    double b = Convert.ToDouble(mix[0] + mix[1]);
                    begin = grading(b);
                }


            }
            else
            {
                if (eix[1] != 0)
                {
                    double b = Convert.ToDouble(eix[0] + eix[1]);
                    begin = grading(b);
                }
            }
            total = total + begin;     //For Calculating total gpa;
            con.Close();
            return View();
        }

        public ActionResult Calculateresultdb6(Results_Information_viewmodel6 model)
        {
            double t;
            t = total / 9;


            MvcDatabase1Entities3 rd6 = new MvcDatabase1Entities3();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass6 set Gpa = '" + t + "' where (StudentId = '" + s + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("Insertresultdb6");
        }


        public double grading(double a)
        {
            if (a >= 40 && a <= 49)
            {
                a = 2.0;
                return (a);
            }
            if (a >= 50 && a <= 59)
            {
                a = 3.0;
                return (a);
            }
            if (a >= 60 && a <= 69)
            {
                a = 3.5;
                return (a);
            }
            if (a >= 70 && a <= 79)
            {
                a = 4.0;
                return (a);
            }
            if (a >= 80)
            {
                a = 5.0;
                return (a);
            }
            else
            {
                return 0;
            }

        }


        public int B1andB2(int A)
        {
            mix[i]= A;
            i++;
            return mix[i];
        }
    }
}
