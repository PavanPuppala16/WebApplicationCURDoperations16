using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApplicationCURDoperations16.Businesslogic_bl;
using WebApplicationCURDoperations16.Models;

namespace WebApplicationCURDoperations16.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult BookInsert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookInsert(Book OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = Book_bl.Insertdata(OBJ);
                if (res == true)
                {
                    return RedirectToAction("GETALLDATA", "Book");
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
            return View(Book_bl.GetData());
        }

        [HttpGet]
        public IActionResult Update(int? BID)
        {
            return View(Book_bl.DataByID((int)BID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Book obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Book_bl.UpdateData(obj);

                if (res == true)
                {
                    return RedirectToAction("GETALLDATA", "Book");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }

        public IActionResult Delete(int BID)
        {
            bool res = Book_bl.DeleteData(BID);
            if (res == true)
            {
                return RedirectToAction("GETALLDATA", "Book");
            }
            else
            {
                return View();
            }
        }

        
        [HttpGet]
        public IActionResult Details(int? BID)
        {
            return View(Book_bl.DataByID((int)BID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Book obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Book_bl.Details(obj);

                if (res == true)
                {
                    return RedirectToAction("GETALLDATA", "Book");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
    }
}
