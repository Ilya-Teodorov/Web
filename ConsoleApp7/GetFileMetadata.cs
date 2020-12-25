using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace Teodorov_labs
{
    public class GetFileMetadata
    {
        IRestResponse response;

        [SetUp]
        public void GetFileMetadataTest()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer CW3iwcUQaHkAAAAAAAAAAbtEAbVXnQByv_3YGOjAnITMVwJv14S9RamOy2g_NZ9K");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"file\": \"id:qBTTwJ_mh7AAAAAAAAAANA\",\"actions\": []}", ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [TestCase(200)]
        public void Test3(int StatusCode)
        {
            Assert.AreEqual(StatusCode, (int)response.StatusCode); //status
        }

        [TestCase("/Teo_meta_data.txt")] //size
        public void Test4(string StringContains)
        {
            string content = response.Content.ToString();
            bool iscontains = content.Contains(StringContains);
            Assert.AreEqual(true, iscontains);
        }
    }
}