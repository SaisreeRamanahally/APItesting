using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;

namespace SampathAPI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        BillingOrderAPI billingOrder = new BillingOrderAPI();

        private readonly string baseUrl = "http://localhost:8080";

        [Test]
        public void Test1()
        {
            var client = new RestSharp.RestClient("http://localhost:8080/BillingOrder/1");
            client.Timeout = -1;
            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            RestSharp.IRestResponse response = client.Execute(request);
            TestContext.WriteLine(response.Content);
        }


        [Test]
        public void GetOrderById()
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/11");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            TestContext.WriteLine(response.Content);
        }
        [Test]
        public void GetOrderAll()
        {
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/");
            var request = new RestRequest(Method.GET);
            //Execute task
            IRestResponse response = client.Execute(request);
            TestContext.WriteLine(response.Content);
        }
        [Test]
        public void PostOrder()
        {
            for (int i = 0; i < 10; i++)
            {
                string body = $"{{\"addressLine1\": \"21A\",\"addressLine2\": \"Karori\", \"city\": \"Wellington\", \"comment\": \"None\",\"email\": \"dsfg@gmail.com\",\"firstName\": \"Sai\",\"itemNumber\":1234,\"lastName\": \"sree\",\"phone\": \"1234567890\",\"state\": \"AL\",\"zipCode\": \"123456\"}}";
                //setting task
                var client = new RestClient($"{baseUrl}/BillingOrder");
                var request = new RestRequest(Method.POST);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                //Execute task
                IRestResponse response = client.Execute(request);
                TestContext.WriteLine(response.Content);

            }
        }

        [Test]
        public void UpdateOrder()
        {
            string body = $"{{\"addressLine1\": \"50B\",\"addressLine2\": \"Karori\", \"city\": \"Auckland\", \"comment\": \"Ring me\",\"email\": \"sai@gmail.com\",\"firstName\": \"SaiRoopa\",\"itemNumber\":1234,\"lastName\": \"Sreesai\",\"phone\": \"1234567890\",\"state\": \"AL\",\"zipCode\": \"789123\"}}";

            {
                //setting task
                var client = new RestClient($"{baseUrl}/BillingOrder/7");
                var request = new RestRequest(Method.PUT);
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                //Execute task
                IRestResponse response = client.Execute(request);
                TestContext.WriteLine(response.Content);
            }
        }

        [Test]
        public void DeleteOrder()
        {
            IRestResponse createResponse = CreateOrder();

            TestContext.WriteLine(" before responsecontent");
            string responsecontent = createResponse.Content;

            TestContext.WriteLine(" before jObject");
            var jObject = JObject.Parse(createResponse.Content);
            TestContext.WriteLine("jObject" + jObject);
            TestContext.WriteLine(" before id");
            string id = jObject.GetValue("id").ToString();

            TestContext.WriteLine(" previous id create" + id);

            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);

                        //Execute task
            IRestResponse response = client.Execute(request);
            TestContext.WriteLine(response.Content);
        }

        public IRestResponse CreateOrder()
        {
            string body = $"{{\"addressLine1\": \"21A\",\"addressLine2\": \"Karori\", \"city\": \"Wellington\", \"comment\": \"None\",\"email\": \"dsfg@gmail.com\",\"firstName\": \"Sai\",\"itemNumber\":1234,\"lastName\": \"sree\",\"phone\": \"1234567890\",\"state\": \"AL\",\"zipCode\": \"123456\"}}";
            //setting task
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Execute task
            IRestResponse response = client.Execute(request);

            TestContext.WriteLine(" previous id create record" + response);

            return response;
        }
    }


}  
    
    