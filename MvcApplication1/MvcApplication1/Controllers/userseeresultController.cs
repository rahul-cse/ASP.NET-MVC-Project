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
    public class userseeresultController : Controller
    {
        //
        // GET: /userseeresult/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult class5result(string StudentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename= C:\Users\HP\Documents\Visual Studio 2013\Projects\MvcApplication1\MvcApplication1\App_Data\MvcDatabase1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand sc = new SqlCommand("select StudentsInfo.FirstName,StudentsInfo.LastName, StudentsInfo.Class, ResultDatabaseClass5.Bengali, ResultDatabaseClass5.English, ResultDatabaseClass5.Mathematics, ResultDatabaseClass5.Science, ResultDatabaseClass5.Religion, ResultDatabaseClass5.Bangladesh_and_Global_Studies,ResultDatabaseClass5.Gpa from ResultDatabaseClass5 inner join StudentsInfo on ResultDatabaseClass5.StudentId = StudentsInfo.StudentId where (ResultDatabaseClass5.StudentId='" + StudentId + "')", con);
            //sc.ExecuteNonQuery();
            SqlDataReader sd;
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
            //return View();
        }

        public ActionResult Createpdf(string FirstName, string LastName, string Class, string Bengali, string English, string Mathematics, string Science, string Religion, string Bangladesh_and_Global_Studies, string Gpa)
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
    }
}
