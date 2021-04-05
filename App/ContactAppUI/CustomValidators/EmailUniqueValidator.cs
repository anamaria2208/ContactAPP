using ContactAppUI.Caller;
using ContactAppUI.Controllers;
using ContactAppUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAppUI.CustomValidators
{
    public class EmailUniqueValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string email = (string)value;
            var candidates = new RestSharpCaller("https://localhost:44325/").GetContacts();
            var result = EmailExists(candidates, email);
            return !result;



        }

        public bool EmailExists(IEnumerable<ContactResponse> contacts, string email)
        {
            
           var result = contacts.Any(e => e.Email == email);
           return result;
        }
    }
}
