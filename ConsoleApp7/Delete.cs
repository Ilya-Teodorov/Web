using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace Teodorov_labs
{
    public class ZFileDelete
    {
        IRestResponse response;

        [SetUp]
        public void Delete()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer CW3iwcUQaHkAAAAAAAAAAbtEAbVXnQByv_3YGOjAnITMVwJv14S9RamOy2g_NZ9K");
            request.AddParameter("application/json", "{\r\n    \"path\": \"/Teodorov.txt\"\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [TestCase(200)]
        public void Test5(int StatusCode)
        {
            Assert.AreEqual(StatusCode, (int)response.StatusCode); //status
        }
    }
}
