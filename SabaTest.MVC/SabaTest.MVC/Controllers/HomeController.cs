using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SabaTest.Bus;
using SabaTest.Data.Model;

namespace SabaTest.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            // write the object model in json format
            var filePath = GetFilePath();
            var result = CustomerManager.WriteToJsonFile(customer, filePath);
            // clear model after writing the data
            ModelState.Clear();
            ViewBag.Result = result + " \n" + filePath;
            return View();
        }

        #region GetFilePath
        private string GetFilePath()
        {
            // get base directory
            var baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            var folderPath = $"{baseUrl}JsonData";

            // get timestamp to write file as a new file each time
            var unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var fileName = $"CustomerInfo-{unixTimestamp}.json";
            var fullFileName = $@"{folderPath}\{fileName}";
            return fullFileName;
        }
        #endregion
    }
}