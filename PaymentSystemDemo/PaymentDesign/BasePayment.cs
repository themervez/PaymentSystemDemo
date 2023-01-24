using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PaymentSystemDemo.PaymentDesign
{
    public abstract class BasePayment : IPayment
    {
        //ApiUrl and ApiKey are used to authenticate the request
        protected readonly string _apiUrl;
        protected readonly string _apiKey;

        //Constructor that accepts ApiUrl and ApiKey as parameter
        public BasePayment(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }
        // Abstract method that needs to be implemented in derived classes
        public abstract bool ProcessPayment(decimal amount, string cardNumber);

        protected bool SendPaymentRequest(object payment)
        {
            //Creating an instance of HttpClient
            using (var client = new HttpClient())
            {  
                client.BaseAddress = new Uri(_apiUrl);// setting BaseAddress to the ApiUrl
                client.DefaultRequestHeaders.Accept.Clear();//Clear any previously set Accept headers
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _apiKey);//Adding Authorization header with the apiKey

                // Sending the post request with json 
                var response = client.PostAsJsonAsync("/charge", payment).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var json = JsonConvert.DeserializeObject<dynamic>(responseContent);// deserialize the json response

                    if ((bool)json.success)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error: " + json.error);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.ReasonPhrase);
                    return false;
                }
            }
        }
    }
}
