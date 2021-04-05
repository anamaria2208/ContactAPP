using ContactAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAppUI.Caller
{
    public interface ICaller
    {
        IEnumerable<ContactResponse> GetContacts();
        void CreateContact(ContactResponse contact);
        void UpdateContact(int id, ContactResponse contact);
        void DeleteContact(int id);
    }
}
