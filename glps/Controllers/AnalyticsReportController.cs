using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using glps.DAL;
using glps.Models;
using LinqToExcel;
using Newtonsoft.Json;

namespace glps.Controllers
{
    public class AnalyticsReportController : Controller
    {
		glpsContext db = new glpsContext();
		// GET: AnalyticsReport
		public ActionResult Index()
        {

			List<DataPoint> dataPoints = new List<DataPoint>{
				//new DataPoint(10, 22),
				//new DataPoint(20, 36),
				//new DataPoint(30, 42),
				//new DataPoint(40, 51),
				//new DataPoint(50, 46),
			};

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		public ActionResult passenger()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("Terrorism", 25));
			dataPoints.Add(new DataPoint("Narcotis", 13));
			dataPoints.Add(new DataPoint("Smuggling", 8));
			dataPoints.Add(new DataPoint("Illegal_Immigration", 7));
			dataPoints.Add(new DataPoint("Revenue", 6.8));
			

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		public ActionResult Airport()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("USA", 10));
			dataPoints.Add(new DataPoint("Great Britain", 67));
			dataPoints.Add(new DataPoint("China", 10));
			dataPoints.Add(new DataPoint("Russia", 56));
			dataPoints.Add(new DataPoint("Germany", 42));
			dataPoints.Add(new DataPoint("Japan", 41));
			dataPoints.Add(new DataPoint("France", 25));
			dataPoints.Add(new DataPoint("South Korea", 21));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		public ActionResult Terminal()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("Kent International", 1));
			dataPoints.Add(new DataPoint("Manchester", 2));
			dataPoints.Add(new DataPoint("Heathrow", 4));
			dataPoints.Add(new DataPoint("Eglinton (City Of Londonderry)", 4));
			dataPoints.Add(new DataPoint("Ronaldsway", 9));
			dataPoints.Add(new DataPoint("Broadford", 11));
			dataPoints.Add(new DataPoint("St Marys", 13));
			dataPoints.Add(new DataPoint("Tresco", 23));
			dataPoints.Add(new DataPoint("Leeds/Bradford", 18));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		public ActionResult Flight()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("Ryanair UK Ltd", 10));
			dataPoints.Add(new DataPoint("British Airways p.l.c.", 22));
			dataPoints.Add(new DataPoint("TUI Airways Limited dba TUI", 9));
			dataPoints.Add(new DataPoint("Virgin Atlantic Airways Limited", 7));
			dataPoints.Add(new DataPoint("Easyjet Airline Company Limited", 5));
			dataPoints.Add(new DataPoint("Jet2.com Limited", 6));
			


			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
	}
}