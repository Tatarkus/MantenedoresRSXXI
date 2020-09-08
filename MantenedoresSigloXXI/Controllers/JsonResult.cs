using MantenedoresSigloXXI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Printing.IndexedProperties;
using System.Text;

namespace MantenedoresSigloXXI.Controllers
{
    public class JsonResult
    {
        string myJson;
        string exampleJson = 
                    "[{\"Id\": \"1\","+
                    "\"Name\": \"nombre1\","+
                    "\"Email\": \"nombre1 @mail1.com\","+
                    "\"Phone\": \"789456123\","+
                    "\"RegistryDate\": \"10/10/2020\","+
                    "\"Run\": \"213\""+
                "}, {"+
	                "\"Id\": \"2\","+
                    "\"Name\": \"Nombre2 \"," +
                    "\"Email\": \"nombre2@mail2.com\"," +
                    "\"Phone\": \"88888888\"," +
                    "\"RegistryDate\": \"12/12/2020\"," +
                    "\"Run\": \"2222\"" +
                "}]";
        public List<Client> DeserializeClients()
        {
            //_clients = JsonConvert.DeserializeObject<List<JsonResult>>(exampleJson);
            List<Client> _clients = JsonConvert.DeserializeObject<List<Client>>(exampleJson);
            Debug.WriteLine(exampleJson);
            return _clients;
        }

    }
}
