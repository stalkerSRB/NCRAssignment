using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TestApi.Models;

namespace TestApi.APITest
{
    [TestFixture]
    public class ReqresTests
    {
        private RestRequest _restRequest;

        public RestRequest CreateRequest(Method method, string jsonString)
        {
            _restRequest = new RestRequest(method);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public RestClient GetClient(string url) => new RestClient("https://reqres.in/" + url);

        [Test]
        public void GetResponseUsers()
        {
            var request = CreateRequest(Method.GET, "");
            var restClient = GetClient("api/users?page=2");
            var response = restClient.Execute(request);

            var content = response.Content;
            Users users = JsonConvert.DeserializeObject<Users>(content);

            Assert.AreEqual(2, users.page);
        }

        [Test]
        public void CreateUser()
        {
            string jsonString = @"{
                                    ""name"": ""Test"",
                                    ""job"": ""QA""
                                }";

            var request = CreateRequest(Method.POST, jsonString);
            var restClient = GetClient("api/users");
            var response = restClient.Execute(request);
            CreateUser content = JsonConvert.DeserializeObject<CreateUser>(response.Content);

            Assert.AreEqual(content.name, "Test");
            Assert.AreEqual(content.job, "QA");
        }

        [Test]
        public void UpdateUser()
        {
            string jsonString = @"{
                                    ""name"": ""New Name"",
                                    ""job"": ""QA""
                                }";

            var request = CreateRequest(Method.PUT, jsonString);
            var restClient = GetClient("api/users");
            var response = restClient.Execute(request);
            CreateUser content = JsonConvert.DeserializeObject<CreateUser>(response.Content);

            Assert.AreEqual(content.name, "New Name");
        }

        [Test]
        public void DeleteUser()
        {
            var request = CreateRequest(Method.DELETE, "");
            var restClient = GetClient("api/users/2");
            var response = restClient.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);
        }
    }
}
