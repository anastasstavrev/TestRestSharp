using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TestRestSharp.Model;

namespace TestRestSharp
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];

            Assert.That(result, Is.EqualTo("Kathik KK"), "Author is not correct");  
        }
        [Test]
        [Obsolete]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = "Raj" }); 

            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["name"];

            Assert.That(result, Is.EqualTo("Raj"), "Author is not correct");
        }

        [Test]
        [Obsolete]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts() { Id = "15", Author = "Execute Automation", Titel = "RestSharp demo course" });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["Author"];

            Assert.That(result, Is.EqualTo("Execute Automation"), "Author is not correct");
        }
    }
}
