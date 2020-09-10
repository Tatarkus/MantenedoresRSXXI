using MantenedoresSigloXXI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace MantenedoresSigloXXI.Controllers
{
    public class CustomerController
    {
        private readonly string CustomersURL = "http://54.207.113.65:3001/api/v1/admin/customers/";
        private WebRequest request;
        private HttpWebResponse response;
        private string customersJson;

        public CustomerController()
        {
            request = WebRequest.Create(CustomersURL);
            request.Method = "GET";  
        }
        public class CustomerJson
        {
            [JsonProperty("customers")]
            public List<Customer> Customers { get; set; }
        }
        public List<Customer> GetCustomers()
        {
            response = request.GetResponse() as HttpWebResponse;
            var encod = ASCIIEncoding.ASCII;
            using var readCustomers = new System.IO.StreamReader(response.GetResponseStream(), encod);
            customersJson = readCustomers.ReadToEnd();
            CustomerJson cs =JsonConvert.DeserializeObject<CustomerJson>(customersJson);
            /*foreach (CustomerJson item in customers)
            {
                _customers.Add(item.Customer);
            }*/
            return cs.Customers;

        }
    }
}
