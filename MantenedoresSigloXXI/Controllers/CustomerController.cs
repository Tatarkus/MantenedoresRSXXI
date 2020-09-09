using MantenedoresSigloXXI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MantenedoresSigloXXI.Controllers
{
    static class CustomerController
    {
        static readonly string exampleJson =
                    "[{\"Id\": \"1\"," +
                    "\"Name\": \"nombre1\"," +
                    "\"LastName\": \"Apenombre1\"," +
                    "\"Email\": \"nombre1@mail1.com\"," +
                    "\"Username\": \"789456123\"," +
                    "\"Password\": \"213\"" +
                "}," +
                    "{\"Id\": \"2\"," +
                    "\"Name\": \"nombre2\"," +
                    "\"LastName\": \"Ape1222\"," +
                    "\"Email\": \"n2222@mail2.com\"," +
                    "\"Username\": \"usrname\"," +
                    "\"Password\": \"4555213\"" +
                "}]";

        public static List<Customer> DeserializeCustomers()
        {
            //_clients = JsonConvert.DeserializeObject<List<JsonResult>>(exampleJson);
            Debug.WriteLine(exampleJson);
            List<Customer> _customers = JsonConvert.DeserializeObject<List<Customer>>(exampleJson);
            return _customers;
        }
    }
}
