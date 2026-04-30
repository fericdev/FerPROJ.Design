using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CApiManager {
        private static readonly HttpClient client = new HttpClient();   
        public static string BaseUrl { get; set; } = "http://localhost:8000/api/"; 

        public static void Initialize(string baseUrl) {
            BaseUrl = baseUrl;
        }
        public static async Task ExecuteAsync(string url) {
            try {
                // 🔹 Check if any network is available
                if (!NetworkInterface.GetIsNetworkAvailable()) {
                    Console.WriteLine("No network connection available.");
                    return;
                }
                var response = await client.GetAsync(GetUrl(url));
                var content = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (TaskCanceledException) {
                // 🔹 Usually timeout or no internet response
                CDialogManager.Warning("Request timed out. Possible no internet or slow connection.");
            }
            catch (HttpRequestException e) {
                // 🔹 Covers DNS failure, refused connection, no internet, etc.
                CDialogManager.Warning($"HTTP Request error: {e.Message}");
            }
            catch (Exception e) {
                // 🔹 Fallback for unexpected errors
                CDialogManager.Warning($"Unexpected error: {e.Message}");
            }
        }
        public static async Task<T> GetDataAsync<T>(string url) {
            try {
                // 🔹 Check if any network is available
                if (!NetworkInterface.GetIsNetworkAvailable()) {
                    Console.WriteLine("No network connection available.");
                    return default;
                }

                var response = await client.GetAsync(GetUrl(url));

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (TaskCanceledException) {
                // 🔹 Usually timeout or no internet response
                Console.WriteLine("Request timed out. Possible no internet or slow connection.");
                return default;
            }
            catch (HttpRequestException e) {
                // 🔹 Covers DNS failure, refused connection, no internet, etc.
                Console.WriteLine($"HTTP Request error: {e.Message}");
                return default;
            }
            catch (Exception e) {
                // 🔹 Fallback for unexpected errors
                Console.WriteLine($"Unexpected error: {e.Message}");
                return default;
            }
        }
        public static async Task<bool> PostDataAsync<T>(string url, T data) {
            try {
                // 🔹 Check if any network is available
                if (!NetworkInterface.GetIsNetworkAvailable()) {
                    Console.WriteLine("No network connection available.");
                    return false;
                }

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(GetUrl(url), content);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (TaskCanceledException) {
                // 🔹 Usually timeout or no internet response
                Console.WriteLine("Request timed out. Possible no internet or slow connection.");
                return false;
            }
            catch (HttpRequestException e) {
                // 🔹 Covers DNS failure, refused connection, no internet, etc.
                Console.WriteLine($"HTTP Request error: {e.Message}");
                return false;
            }
            catch (Exception e) {
                // 🔹 Fallback for unexpected errors
                Console.WriteLine($"Unexpected error: {e.Message}");
                return false;
            }
        }
        private static string GetUrl(string url) {
            return url.StartsWith("http") ? url : $"{BaseUrl}{url}";
        }
    }
}
