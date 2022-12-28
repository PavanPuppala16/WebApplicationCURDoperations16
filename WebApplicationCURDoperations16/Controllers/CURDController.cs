using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WebApplicationCURDoperations16.Models;
using Microsoft.AspNetCore.Mvc;

using WebApplicationCURDoperations16;
using System.Data;
using WebApplicationCURDoperations16.Businesslogic_bl;
using WebApplicationCURDoperations16.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace WebApplicationCURDoperations16.Controllers
{
    public class CURDController : Controller
    {
        [HttpGet]
        public IActionResult REGISTER()
        {
            return View();
        }
    
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult REGISTER(INVOICE_MODEL OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = curd.Insertdata(OBJ);
                if (res == true)
                {

                    return View("GETALLDATA");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }

        [HttpGet]
        public IActionResult GETALLDATA()
        {
            return View(curd.GetALlData());
        }

        public IActionResult UPDATE()
        {
            return View();
        }




        //public IActionResult UPDATE(INVOICE_MODEL OBJ)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool res = curd.updata(OBJ);
        //        if (res == true)
        //        {
        //            return RedirectToAction("GETALLDATA", "CURD");
        //        }
        //        else
        //        {
        //            return View(OBJ);
        //        }
        //    }
        //    else
        //    {
        //        return View(OBJ);
        //    }
        //}
            public IActionResult DELETED(int? dates)
        {
            bool res = curd.DELETEDATA((int)dates);
            if (res == true)
            {
                return RedirectToAction("register", "CURD");
            }
            else
            {
                return View();
            }

            return View();
        }
    }
}
    
