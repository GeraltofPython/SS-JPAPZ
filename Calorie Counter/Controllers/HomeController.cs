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
        public ActionResult Index(string sex, double weight, double height, double age, double activity)
        {
            // Check to see if values are coming in
            Debug.WriteLine("Sex Input:" + sex);
            Debug.WriteLine("Weight Input:" + weight);
            Debug.WriteLine("Height Input:" + height);
            Debug.WriteLine("Age Input:" + age);
            Debug.WriteLine("Activity Input:" + activity);

            // Do something with data
            double cal = 0; 

            sex = sex.ToLower();
            Debug.WriteLine("new sex input change: " + sex);


            if(sex == "male" && activity == 0)
            {
                cal = (4.536 * weight) + (15.88 * height) - (5 * age) + 5;
            }
            else if(sex == "male" && activity > 0)
            {
                cal = ((4.536 * weight) + (15.88 * height) - (5 * age) + 5) * activity;
            }
            if(sex == "female" && activity == 0)
            {
                cal = (4.536 * weight) + (15.88 * height) - (5 * age) - 161;
            }
            else if (sex == "female" && activity > 0)
            {
                cal = ((4.536 * weight) + (15.88 * height) - (5 * age) - 161) * activity;
            }


            double gain = cal + (cal * 0.20);
            double loss = cal - (cal * 0.20);


            Debug.WriteLine("Cal Value Input:" + System.Math.Round(cal));

            //Return the data to the view
            /*
             * ViewBags
             * Models
             */

            //string tempa = z.ToString();
            //tempa = tempa.Substring(0, 4);
            //string tempb = q.ToString();
            //tempb = tempb.Substring(0, 4);

            ViewBag.Cal = System.Math.Round(cal);
            ViewBag.Gain = System.Math.Round(gain);
            ViewBag.Loss = System.Math.Round(loss);

            return View();
        }
    }
}