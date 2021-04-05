using ContactAppUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAppUI.Caller
{
    public class RestSharpCaller : ICaller
    {

        private RestClient restClient;
        public RestSharpCaller(string url)
        {
            restClient = new RestClient(url);
        }


        //get list of contacts
        public IEnumerable<ContactResponse> GetContacts()
        {
            var request = new RestRequest("/api/contacts", Method.GET);
            var response = restClient.Execute<IEnumerable<ContactResponse>>(request);
            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    throw new Exception ("Can't connect to service");
            //}

            return response.Data;
        }

        //get contact by id
        public ContactResponse GetContact(int id)
        {
            var request = new RestRequest("/api/contacts/" + id, Method.GET);
            var response = restClient.Execute<ContactResponse>(request);
            return response.Data;
        }


        //post contact, send as request body
        public void CreateContact(ContactResponse contact)
        {
            var request = new RestRequest("/api/contacts", Method.POST);
            request.AddJsonBody(contact);
            restClient.Execute(request);
            
        }

        //delete

        public void DeleteContact(int id)
        {
            var request = new RestRequest("/api/contacts/" + id, Method.DELETE);
            restClient.Execute(request);
        }

        
        //put
        public void UpdateContact(int id, ContactResponse contact)
        {
            var request = new RestRequest("/api/contacts/" + id, Method.PUT);
            request.AddJsonBody(contact);
            restClient.Execute(request);
        }



    }
}
