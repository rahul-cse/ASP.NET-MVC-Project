using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MvcApplication1.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace MvcApplication1.Controllers
{
    public class userseeresult6Controller : Controller
    {
        //
        // GET: /userseeresult6/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult class6result(string StudentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand sc = new SqlCommand("select StudentsInfo.FirstName,StudentsInfo.LastName, StudentsInfo.Class, ResultDatabaseClass6.Bengali1st,ResultDatabaseClass6.Bengali2nd, ResultDatabaseClass6.English1st,ResultDatabaseClass6.English2nd, ResultDatabaseClass6.Mathematics, ResultDatabaseClass6.Science,ResultDatabaseClass6.Drawing,ResultDatabaseClass6.Physical_Education,ResultDatabaseClass6.ICT, ResultDatabaseClass6.Religion, ResultDatabaseClass6.Bangladesh_and_Global_Studies,ResultDatabaseClass6.Gpa from ResultDatabaseClass6 inner join StudentsInfo on ResultDatabaseClass6.StudentId = StudentsInfo.StudentId where (ResultDatabaseClass6.StudentId='" + StudentId + "')", con);
            //sc.ExecuteNonQuery();
            SqlDataReader sd;
            sd = sc.ExecuteReader();
            List<SearchResult6> lsee = new List<SearchResult6>();
            var v = new SearchResult6();
            while (sd.Read())
            {
                //var v = new SearchResult();
                v.FirstName = sd["FirstName"].ToString();
                v.LastName = sd["LastName"].ToString();
                v.Class = Convert.ToInt16(sd["Class"]);
                v.Bengali1st = Convert.ToInt32(sd["Bengali1st"]);
                v.English1st = Convert.ToInt32(sd["English1st"]);
                v.Bengali2nd = Convert.ToInt32(sd["Bengali2nd"]);
                v.English2nd = Convert.ToInt32(sd["English2nd"]);
                v.Mathematics = Convert.ToInt32(sd["Mathematics"]);
                v.Science = Convert.ToInt32(sd["Science"]);
                v.Physical_Education = Convert.ToInt32(sd["Physical_Education"]);
                v.Religion = Convert.ToInt32(sd["Religion"]);
                v.Bangladesh_and_Global_Studies = Convert.ToInt32(sd["Bangladesh_and_Global_Studies"]);
                v.Drawing= Convert.ToInt32(sd["Drawing"]);
                v.ICT = Convert.ToInt32(sd["ICT"]);
                v.Gpa = Convert.ToDouble(sd["Gpa"]);
                lsee.Add(v);

            }
            return View(lsee);
        }




        public ActionResult Createpdf(string FirstName, string LastName, string Class, string Bengali1st, string Bengali2nd,string English1st,string English2nd, string Mathematics, string Science, string Religion, string Bangladesh_and_Global_Studies,string Physical_Education,string Drawing, string ICT, string Gpa)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            try
            {
                // PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\HP\\Documents\\Visual Studio 2013\\Projects\\MvcApplication1\\MvcApplication1\\obj\\Debug\\Result.pdf",FileMode.Create));
                PdfWriter wri = PdfWriter.GetInstance(doc, Response.OutputStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            doc.Open();             //open pdf document to start writing
            Paragraph pa1 = new Paragraph("Result Card\n----------------------------");
            pa1.Alignment = 1;

            Paragraph pa2 = new Paragraph("Students Name: " + FirstName + " " + LastName + "\n " + "Class: " + Class + "\n ");
            pa2.Alignment = 1;
            doc.Add(pa1);
            doc.Add(pa2);
            //List lpdf = new List(List.UNORDERED);

            //string[] s = new string[20];
            //{
            //s[0] = "Students Name: " + FirstName + LastName;



            PdfPTable ptable = new PdfPTable(2);
            ptable.AddCell("Subject");
            ptable.AddCell("Marks");
            ptable.AddCell("Bengali1st");
            ptable.AddCell(Bengali1st);
            ptable.AddCell("Bengali2nd");
            ptable.AddCell(Bengali2nd);
            ptable.AddCell("English1st");
            ptable.AddCell(English1st);
            ptable.AddCell("English2nd");
            ptable.AddCell(English2nd);
            ptable.AddCell("Mathematics");
            ptable.AddCell(Mathematics);
            ptable.AddCell("Science");
            ptable.AddCell(Science);
            ptable.AddCell("Religion");
            ptable.AddCell(Religion);
            ptable.AddCell("Bangladesh and Global Studies");
            ptable.AddCell(Bangladesh_and_Global_Studies);
            ptable.AddCell("Physical Education");
            ptable.AddCell(Physical_Education);
            ptable.AddCell("Drawing");
            ptable.AddCell(Drawing);
            ptable.AddCell("Information and Communication Technology");
            ptable.AddCell(ICT);
            
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

    }
}
