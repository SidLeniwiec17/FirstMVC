using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer//Init
        public ActionResult Init()
        {
            //guzik
            //open file dialog
            //odpal inna akcje
            return View();
        }
        // GET: Customer//Show
        public ActionResult Show()
        {
            //wczytuje xmla
            //tworze liste zgodnie z modelem
            //zwracam do view
            return View();
        }
    }
}