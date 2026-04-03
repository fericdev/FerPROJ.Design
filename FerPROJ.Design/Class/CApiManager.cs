using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CApiManager {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<T> GetDataAsync<T>(string url) {
            try {
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);

            } catch (HttpRequestException e) {

                Console.WriteLine($"Request error: {e.Message}");

                return default;

            }
        }
    }
}
