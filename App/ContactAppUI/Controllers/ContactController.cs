using ContactAppUI.Caller;
using ContactAppUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContactAppUI.Controllers
{
    public class ContactController : Controller
    {
       //api url
       RestSharpCaller caller = new RestSharpCaller("https://localhost:44325");


        // list of active contacts in db
        public IActionResult Contacts()
        {
            var contacts = caller.GetContacts().Where(x => x.IsActive == true);
            return View(contacts);
        }


        //modal  with selected contact id (date created and date modified)
        public IActionResult DetailsContact(int id)
        {
           var contact =  caller.GetContact(id);
            return PartialView("_DetailsPartial", contact);
        }


        //create -> new form with validations (required: firstName, lastName, email; unique: email)
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View(new ContactResponse());

        }

        [HttpPost]
        public IActionResult CreateContact(ContactResponse contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            caller.CreateContact(contact);
            return RedirectToAction("Contacts");
        }


        //action method for deleting contact with modal confirmation view
        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            caller.DeleteContact(id);
            return PartialView("_DeletePartial");
        }


        //update contact - email cannot be changed on purpose

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var contatctToUpdate = caller.GetContact(id);
            return View(contatctToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateContact(int id, ContactResponse contactUpdated)
        {
            caller.UpdateContact(id, contactUpdated);
            return RedirectToAction("Contacts");
        }

    }
}
