using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using glps.DAL;
using glps.Models;
using LinqToExcel;
using Newtonsoft.Json;

namespace glps.Controllers
{


    public class HomeController : Controller
    {

        glpsContext db = new glpsContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {

            return View();
        }

        //POST: Student/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(String EmailID, string Password)
        {

            {
                if (ModelState.IsValid)

                {
                    var data = db.users.Where(s => s.EmailID.Equals(EmailID) && s.Password.Equals(Password)).ToList();
                    if (data != null)
                    {
                        Session["User_ID"] = data.FirstOrDefault().ID;
                        Session["EmailID"] = data.FirstOrDefault().EmailID;
                        //Session["UserId"] = data.FirstOrDefault().ID;
                        //SessionIDManager manager = new SessionIDManager();
                        //string newSessionId = manager.CreateSessionID(HttpContext);
                        TempData["UserId"] = data.FirstOrDefault().ID;
                        TempData.Keep("UserId");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Error = "Login Fail Please Register Yourself First";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("UserLogin", "Home");
        }

     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UploadData()
        {
            var riskanalysis = db.bchn_Datas.ToList();


            return View(riskanalysis);
        }

        [HttpPost]
        public JsonResult UploadExcel(bchn_data bchn_Data, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    string sheetName = "Sheet1";
                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<bchn_data>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.Fore_Nane != "" && a.Family_Name != "" && a.Gender != ""
                                && a.DOB != "" && a.Nationality != "" && a.Passport_number != ""
                                && a.Terrorism != "" && a.Narcotics != "" && a.Smuggling != ""
                                && a.Illegal_Immigration!= ""  && a.Revenue != "")
                            {
                                bchn_data TU = new bchn_data();
                                TU.Fore_Nane = a.Fore_Nane;
                                TU.Family_Name = a.Family_Name;
                                TU.Gender = a.Gender;
                                TU.DOB = a.DOB;
                                TU.Nationality = a.Nationality;
                                TU.Passport_number = a.Passport_number;
                                TU.Terrorism = a.Terrorism;
                                TU.Narcotics = a.Narcotics;
                                TU.Smuggling = a.Smuggling;
                                TU.Illegal_Immigration = a.Illegal_Immigration;                              
                                TU.Revenue = a.Revenue;

                                db.bchn_Datas.Add(TU);
                                db.SaveChanges();
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.Fore_Nane == "" || a.Fore_Nane == null) data.Add("<li> name is required</li>");
                                if (a.Family_Name == "" || a.Family_Name == null) data.Add("<li> Address is required</li>");
                                if (a.Gender == "" || a.Gender == null) data.Add("<li>ContactNo is required</li>");
                                if (a.DOB == "" || a.DOB == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Nationality == "" || a.Nationality == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Passport_number == "" || a.Passport_number == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Terrorism == "" || a.Terrorism == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Narcotics == "" || a.Narcotics == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Smuggling == "" || a.Smuggling == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Illegal_Immigration == "" || a.Illegal_Immigration == null) data.Add("<li>ContactNo is required</li>");
                                if (a.Revenue == "" || a.Revenue == null) data.Add("<li>ContactNo is required</li>");
                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                    //deleting excel file from folder
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ReportData()
            {

            try
            {
                //ViewBag.DataPoints = JsonConvert.SerializeObject( Point.ToList(), _jsonSetting);

                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public ActionResult Chart()
        {
         var chart = db.bchn_Datas.ToList();
          var population = new Chart(width: 600, height: 600, theme: ChartTheme.Blue)
        .AddTitle("State wise Population")
        .AddSeries(
        chartType: "bar",
        xValue: chart, xField: "StateName",
        yValues: chart, yFields: "TotalPopulation"
        ).Write();
            return null;
        }

}
}