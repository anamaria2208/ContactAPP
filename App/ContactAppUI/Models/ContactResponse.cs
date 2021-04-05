using ContactAppUI.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAppUI.Models
{
    public class ContactResponse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezan podatak")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Prezime je obavezan podatak")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Email je obavezan podatak")]
        [EmailAddress(ErrorMessage = "Email mora biti u ispravnom formatu, npr. ime.prezime@gmail.com")]
        [EmailUniqueValidator(ErrorMessage = "Email vec postoji u bazi")]
        public string Email { get; set; }

        [Display(Name = "Broj mobitela")]
        public string MobilePhone { get; set; }

        [Display(Name = "Adresa")]
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;

        [Display(Name = "Vrijeme kreiranja")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Vrijeme zadnje promjene")]
        public DateTime? DateModified { get; set; }
    }
}
