using System;
using ISWeb.Extensions;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System.Net;
using System.Threading.Tasks;

namespace ISWeb
{
    public class ApiProvider
    {
        
        public static async Task<T> PostAsync<T>(string APIHost, string url, object filter = null)
        {
            RestClient _client = new RestClient(APIHost);
            var jsonDeserializer = new JsonDeserializer();
            _client.AddHandler("application/json", jsonDeserializer);
            var request = new RestRequest(url) { Method = Method.POST };
            request.AddHeader("cache-control", "no-cache");

            //search object
            if (null != filter)
            {
                request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(filter), ParameterType.RequestBody);
            }

            //Parse data response
            T returnObject;
            // execute the request

            try
            {
                _client.Timeout = 600000;
                _client.ReadWriteTimeout = 600000;
                IRestResponse response = await _client.ExecuteAsync(request);

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
                {
                    //error
                }

                returnObject = JsonConvert.DeserializeObject<T>(response.Content);

            }
            catch (Exception ex)
            {
                returnObject = default(T);
            }
            return returnObject;
        }
    }
}
