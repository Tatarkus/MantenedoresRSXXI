using MantenedoresSigloXXI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace MantenedoresSigloXXI.Controllers
{
    public static class ProductController
    {
        private static readonly string ProductsURL = "http://54.207.113.65:3001/api/v1/admin/products/";
        public static string ProductsJSON = "";

        public class ProductJson
        {
            [JsonProperty("Products")]
            public List<Product> Products { get; set; }
        }

        public static string GetProductsJSON()
        {
            WebRequest request = WebRequest.Create(ProductsURL);
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            var encod = ASCIIEncoding.ASCII;
            using var readProducts = new System.IO.StreamReader(response.GetResponseStream(), encod);
            ProductsJSON = readProducts.ReadToEnd();
            return (ProductsJSON);

        }
        public static List<Product> GetProductsList()
        {   
            ProductJson cs =JsonConvert.DeserializeObject<ProductJson>(ProductsJSON);
            return cs.Products;

        }

        public static int DeleteProduct(Product Product)
        {
            WebRequest request = WebRequest.Create(ProductsURL+Product.Id);
            request.Method = "DELETE";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Debug.WriteLine("RESPONSE STATUS CODE: " + response.StatusCode);
            return (int)response.StatusCode;

        }

        public static int EditProduct(Product product)
        {
            WebRequest request = WebRequest.Create(ProductsURL + product.Id);
            request.Method = "PUT";
            request.ContentType = "application/json";

            Dictionary<string, string> newData = new Dictionary<string, string>
                {
                    /*{ "newName", Product.Name},
                    { "newEmail", Product.Email},
                    { "newLastName", Product.LastName}*/
                };

            string jsonPayload = JsonConvert.SerializeObject(newData, Formatting.Indented);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {              
                streamWriter.Write(jsonPayload);
            }
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Debug.WriteLine("RESPONSE STATUS CODE: " + response.StatusCode);
            return (int)response.StatusCode;

        }
    }
}
