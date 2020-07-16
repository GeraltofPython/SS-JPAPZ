using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Math.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(double a, double b, double c)
        {
            // Check to see if values are coming in
            Debug.WriteLine("A Value Input:" + a);
            Debug.WriteLine("B Value Input:" + b);
            Debug.WriteLine("C Value Input:" + c);

            // Do something with data

            double z = ((b * -1) - System.Math.Sqrt((double)(b * b) - (double)(4 * a * c))) / (2 * a);
            double q = ((b * -1) + System.Math.Sqrt((double)(b * b) - (double)(4 * a * c))) / (2 * a);

            Debug.WriteLine("Z Value Input:" + System.Math.Round(z));
            Debug.WriteLine("Q Value Input:" + System.Math.Round(q));

            //Return the data to the view
            /*
             * ViewBags
             * Models
             */

            //string tempa = z.ToString();
            //tempa = tempa.Substring(0, 4);
            //string tempb = q.ToString();
            //tempb = tempb.Substring(0, 4);

            ViewBag.ZVal = System.Math.Round(z);
            ViewBag.QVal = System.Math.Round(q);

            return View();
        }
    }
}