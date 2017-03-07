using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.Models;
using System.IO;
using System.Text;
using System.Xml;

namespace MVCTask.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Init
        //open file dialog
        //submit -> Show
        public ActionResult Init()
        {
            return View();
        }

        // GET: Customer/Show
        // check file correction and model stuff
        [HttpPost]
        public ActionResult Show(HttpPostedFileBase xmlFile)
        {
            if (xmlFile == null)
                return View("Init");

            if (!ValidateFile(xmlFile))
                return View("Error");

            ReadXml(xmlFile);
            //ViewBag.Content=ReadXml(xmlFile);

            return View();
        }     

        private void ReadXml(HttpPostedFileBase file)
        {
            string content = new StreamReader(file.InputStream).ReadToEnd();
            List<Customer> customers = new List<Customer>();

            using (XmlReader reader = XmlReader.Create(new StringReader(content)))
            {
                bool flag = true;
                while(flag)
                {
                    Customer tempCustomer = new Customer();
                    if (reader.ReadToFollowing("contact"))
                    {
                        reader.ReadToFollowing("name");
                        tempCustomer.Name = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("surname");
                        tempCustomer.Surname = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("number");
                        tempCustomer.Number = reader.ReadElementContentAsInt();
                        reader.ReadToFollowing("email");
                        tempCustomer.Email = reader.ReadElementContentAsString();
                        reader.ReadEndElement();
                        customers.Add(tempCustomer);
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            Console.WriteLine("finito");
            
        }

        private bool ValidateFile(HttpPostedFileBase fileToCheck)
        {
            if (!fileToCheck.ContentType.Equals("text/xml") || fileToCheck.ContentLength < 1)
                return false;

            return true;
        }
    }
}