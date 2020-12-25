using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace Teodorov_labs
{
    public class FileUpload
    {
        IRestResponse response;

        [SetUp]
        public void Upload()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Dropbox-API-Arg", "{\"path\":\"/Teodorov.txt\",\"mode\":\"add\",\"autorename\":true,\"mute\":false,\"strict_conflict\":false}");
            request.AddHeader("Authorization", "Bearer CW3iwcUQaHkAAAAAAAAAAbtEAbVXnQByv_3YGOjAnITMVwJv14S9RamOy2g_NZ9K");
            request.AddParameter("application/octet-stream", "IASA-KA-81 Development and Testing", ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [TestCase(200)]
        public void Test1(int StatusCode)
        {
            Assert.AreEqual(StatusCode, (int)response.StatusCode); //status
        }

        [TestCase("\"content_hash\": \"f75a22600fd574a5204e0f3a785b10e438d80d11fd5bb313170b30524a1be47b\"")] //content_hash)
        public void Test2(string StringContains)
        {
            string content = response.Content.ToString();
            bool iscontains = content.Contains(StringContains);
            Assert.AreEqual(true, iscontains); 
        }
    }
}