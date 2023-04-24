using System.Net.Http.Json;
using System.Text.Json;

namespace BeatleBug.Client.Web.Services.Contracts
{
    public abstract class ClientApi
    {
        protected readonly HttpClient _http;
        private readonly string _baseRoute;

        protected ClientApi(string baseRoute, HttpClient http)
        {
            _baseRoute = baseRoute;
            _http = http;
        }

        protected async Task<TReturn?> GetAsync<TReturn>(string relativeUri)
        {
            var route = $"{_http.BaseAddress}{_baseRoute}/{relativeUri}";
            HttpResponseMessage res = await _http.GetAsync(route);
            if (res.IsSuccessStatusCode)
            {
                try
                {
                    var result = await res.Content.ReadFromJsonAsync<TReturn>();
                    return (result != null) ? result : default;
                }
                catch (NotSupportedException) 
                {
                    Console.WriteLine("ClientApi: Content type is not supported");
                    throw;
                }
                catch (JsonException)
                {
                    Console.WriteLine("ClientApi: InvalidJson");
                    throw;
                }
            }
            else
            {
                string msg = await res.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }

        protected async Task<TReturn?> PostAsync<TReturn, TRequest>(string relativeUri, TRequest request)
        {
            HttpResponseMessage res = await _http.PostAsJsonAsync<TRequest>($"{_baseRoute}/{relativeUri}", request);
            if (res.IsSuccessStatusCode)
            {
                TReturn? response = await res.Content.ReadFromJsonAsync<TReturn>();
                return response; 
            }
            else
            {
                string msg = await res.Content.ReadAsStringAsync();
                Console.WriteLine(msg);
                throw new Exception(msg);
            }
        }
    }
}
