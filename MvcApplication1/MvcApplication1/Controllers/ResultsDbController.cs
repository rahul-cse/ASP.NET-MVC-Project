using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MvcApplication1.Controllers
{
    public class ResultsDbController : Controller
    {
        //
        // GET: /ResultsDb/
        public  static double begin ,total ;
        public static long s;
        public  static string gpa;
        public static int MARKS;



        public ActionResult Index()
        {
            return View();
        }

  
        public ActionResult Seeresultdb(string StudentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand sc = new SqlCommand("select StudentsInfo.FirstName,StudentsInfo.LastName, StudentsInfo.Class, ResultDatabaseClass5.Bengali, ResultDatabaseClass5.English, ResultDatabaseClass5.Mathematics, ResultDatabaseClass5.Science, ResultDatabaseClass5.Religion, ResultDatabaseClass5.Bangladesh_and_Global_Studies,ResultDatabaseClass5.Gpa from ResultDatabaseClass5 inner join StudentsInfo on ResultDatabaseClass5.StudentId = StudentsInfo.StudentId where (ResultDatabaseClass5.StudentId='" + StudentId + "')", con);
            //sc.ExecuteNonQuery();
            SqlDataReader sd ;
            sd = sc.ExecuteReader();
            List<SearchResult> lsee = new List<SearchResult>();
            var v = new SearchResult();
            while (sd.Read())
            {
                //var v = new SearchResult();
                v.FirstName = sd["FirstName"].ToString();
                v.LastName = sd["LastName"].ToString();
                v.Class = Convert.ToInt16(sd["Class"]);
                v.Bengali = Convert.ToInt32(sd["Bengali"]);
                v.English = Convert.ToInt32(sd["English"]);
                v.Mathematics = Convert.ToInt32(sd["Mathematics"]);
                v.Science = Convert.ToInt32(sd["Science"]);
                v.Religion = Convert.ToInt32(sd["Religion"]);
                v.Bangladesh_and_Global_Studies = Convert.ToInt32(sd["Bangladesh_and_Global_Studies"]);
                v.Gpa = Convert.ToDouble(sd["Gpa"]);
                lsee.Add(v);
                
            }
            return View(lsee);
        }
        public ActionResult InsertId(Results_Information_viewmodel model, string classname)
        {
 
            if(classname == "5")
            {
                MvcDatabase1Entities2 rd5 = new MvcDatabase1Entities2();
                ResultDatabaseClass5 stdresult = new ResultDatabaseClass5();
                stdresult.StudentId = model.StudentId;
                stdresult.Term = model.Term;
                rd5.ResultDatabaseClass5.Add(stdresult);
                
                try 
                {
                    rd5.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
               // ViewData.sid = new List<int>();
                
                    
            
                    return RedirectToAction("Insertresultdb", model);
            }
            else if(classname == "6")
            {

                MvcDatabase1Entities3 rd6 = new MvcDatabase1Entities3();
                ResultDatabaseClass6 std6 = new ResultDatabaseClass6();
                std6.StudentId = model.StudentId;
                std6.Term = model.Term;
                rd6.ResultDatabaseClass6.Add(std6);
                rd6.SaveChanges();
                    //stdresult.StudentId = model.StudentId;
                    //stdresult.Term = model.Term;
                    //rd5.ResultDatabaseClass5.Add(stdresult);

                    //try
                    //{
                    //    rd5.SaveChanges();
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}
                    //// ViewData.sid = new List<int>();



                return RedirectToAction("Insertresultdb6", "ResultsDb6", model);
                
            }
                
            else return View();
        }



        public ActionResult Insertresultdb(Results_Information_viewmodel model, string subject, string marks )
        {
              //double begin ,total=0 ;

                
                s= model.StudentId;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
                con.Open();

                
                MvcDatabase1Entities2 db = new MvcDatabase1Entities2();
                ResultDatabaseClass5 rd5 = new ResultDatabaseClass5();
                int m = Convert.ToInt32(marks);
                double b = Convert.ToDouble(m);

                ViewBag.Subject = subject + " " + marks;
                ViewBag.x = MARKS;
                MARKS++;
                ViewBag.gpa_ = gpa;
                ViewBag.sid = model.StudentId;
                List<ResultDatabaseClass5> l = new List<ResultDatabaseClass5>();
                begin = grading(b);
                if (subject == "Bengali")
                {
                    
                    model.Bengali=m;
                    rd5.Bengali = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Bengali = '" + rd5.Bengali + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();

                }

                if (subject == "English")
                {
                    //  int m = Convert.ToInt32(marks);
                    model.English = m;
                    rd5.English = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set English = '" + rd5.English + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();
                }

                if (subject == "Mathematics")
                {

                    model.Mathematics = m;
                    rd5.Mathematics = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Mathematics = '" + rd5.Mathematics + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();

                }
                if (subject == "Science")
                {

                    model.Science = m;
                    rd5.Science = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Science = '" + rd5.Science + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();

                }
                if (subject == "Religion")
                {

                    model.Religion = m;
                    rd5.Religion = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Religion = '" + rd5.Religion + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();

                }
                if (subject == "Bangladesh_and_Global_Studies")
                {

                    model.Bangladesh_and_Global_Studies = m;
                    rd5.Bangladesh_and_Global_Studies = m;
                    l.Add(rd5);
                    SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Bangladesh_and_Global_Studies = '" + rd5.Bangladesh_and_Global_Studies + "' where (StudentId = '" + model.StudentId + "')", con);
                    cmd.ExecuteNonQuery();
                }
                //begin = b;
                total = total + begin;
                //string connectionstring = ConfigurationManager.ConnectionStrings["MvcDatabase1Entities2"].ConnectionString;


                //cmd.ExecuteNonQuery();
                con.Close();


                //db.Entry(rd5).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    //throw ex;
                }

                // db.ResultDatabaseClass5.ToList<l
                return View(model);
            



        }

        public ActionResult Calculateresultdb(Results_Information_viewmodel model)
        {
            double t;
            t = total / 6;
            string text1 = "The student with ID ";
            string text2 = "has got Gpa ";
            gpa = text1 + s + text2 + t;
            
            MvcDatabase1Entities2 rd5 = new MvcDatabase1Entities2();
            //ResultDatabaseClass5 std_calculate_result = new ResultDatabaseClass5();
           // std_calculate_result.Gpa = t;
            //rd5.ResultDatabaseClass5.Add(std_calculate_result);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE ResultDatabaseClass5 set Gpa = '" + t + "' where (StudentId = '" + s + "')", con) ;
            cmd.ExecuteNonQuery();
            con.Close();
                
                return RedirectToAction("Insertresultdb");


        }




        public ActionResult Createpdf(string FirstName,string LastName, string Class, string Bengali, string English, string Mathematics,string Science, string Religion, string Bangladesh_and_Global_Studies,  string Gpa)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            try
            {
               // PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\HP\\Documents\\Visual Studio 2013\\Projects\\MvcApplication1\\MvcApplication1\\obj\\Debug\\Result.pdf",FileMode.Create));
                PdfWriter wri = PdfWriter.GetInstance(doc, Response.OutputStream);
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
            doc.Open();             //open pdf document to start writing
            Paragraph pa1 = new Paragraph("Result Card\n----------------------------");
            pa1.Alignment = 1;

            Paragraph pa2 = new Paragraph("Students Name: " + FirstName + " "+ LastName+ "\n "+ "Class: "+ Class+ "\n ");
            pa2.Alignment = 1;
            doc.Add(pa1);
            doc.Add(pa2);
            //List lpdf = new List(List.UNORDERED);

            //string[] s = new string[20];
            //{
            //s[0] = "Students Name: " + FirstName + LastName;

            
            //s[1] = "Bengali: " + Bengali;
            //s[2] = "Total Gpa: " + Gpa;
            PdfPTable ptable = new PdfPTable(2);
            ptable.AddCell("Subject");
            ptable.AddCell("Marks");
            ptable.AddCell("Bengali");
            ptable.AddCell(Bengali);
            ptable.AddCell("English");
            ptable.AddCell(English);
            ptable.AddCell("Mathematics");
            ptable.AddCell(Mathematics);
            ptable.AddCell("Science");
            ptable.AddCell(Science);
            ptable.AddCell("Religion");
            ptable.AddCell(Religion);
            ptable.AddCell("Bangladesh and Global Studies");
            ptable.AddCell(Bangladesh_and_Global_Studies);
            PdfPCell pcell = new PdfPCell(new Phrase("Total Gpa :  " + Gpa));     //This is for distinctive table row.
            pcell.Colspan = 2;
            pcell.HorizontalAlignment = 1;
            //ptable.AddCell("Total Gpa");
            //ptable.AddCell(Gpa);
            //lpdf.Add(s[1]);
            //lpdf.Add(s[2]);
            //}
            ptable.AddCell(pcell);
                doc.Add(ptable);
                
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=result.pdf");
            Response.Write(doc);
            Response.Flush();
            Response.End();
            return View();
        }

         public double grading(double a)
        {
            if (a >= 40 && a<= 49)
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


         
    }
}
