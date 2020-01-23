using System;
using System.Net.Http;

namespace TokenExWebDemo
{
    public class TokenExAPIProvider
    {
        private HttpResponseMessage MakeAPICall<T>(object dto, string url)
        {
            HttpResponseMessage result;

            using (var client = new HttpClient())
            {
                result = client.PostAsJsonAsync<T>(url, (T)dto).Result;
            }
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Oops! Encountered error: {result.StatusCode.ToString()}");
            }

            return result;
        }
    }
}