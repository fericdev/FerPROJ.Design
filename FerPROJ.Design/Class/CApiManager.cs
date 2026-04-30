using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public static class CApiManager {
        private static readonly HttpClient client;

        static CApiManager() {
            client = new HttpClient {
                Timeout = TimeSpan.FromSeconds(30)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string BaseUrl { get; private set; } = "http://localhost:8000/api/";

        public static void Initialize(string baseUrl) {
            BaseUrl = baseUrl.TrimEnd('/') + "/";
        }

        private static string BuildUrl(string url) {
            return url.StartsWith("http")
                ? url
                : $"{BaseUrl}{url}";
        }
        public static async Task ExecuteAsync(string url) {
            // 🔹 Check if any network is available
            if (!NetworkInterface.GetIsNetworkAvailable()) {
                CDialogManager.Warning("No network connection available.");
                return;
            }
            try {
                var response = await client.GetAsync(BuildUrl(url));
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
        // 🔹 GENERIC REQUEST HANDLER
        private static async Task<string> SendAsync(HttpRequestMessage request) {
            if (!NetworkInterface.GetIsNetworkAvailable())
                throw new Exception("No network connection.");

            try {
                var response = await client.SendAsync(request);

                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) {
                    throw new Exception(
                        $"HTTP {(int)response.StatusCode}: {content}");
                }

                return content;
            }
            catch (TaskCanceledException) {
                throw new Exception("Request timeout.");
            }
            catch (HttpRequestException ex) {
                throw new Exception($"HTTP error: {ex.Message}");
            }
        }

        // 🔹 GET
        public static async Task<T> GetAsync<T>(string url) {
            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(url));

            var content = await SendAsync(request);

            return Deserialize<T>(content);
        }

        // 🔹 POST
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data) {
            var json = JsonConvert.SerializeObject(data);

            var request = new HttpRequestMessage(HttpMethod.Post, BuildUrl(url)) {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var content = await SendAsync(request);

            return Deserialize<TResponse>(content);
        }

        // 🔹 PUT
        public static async Task<bool> PutAsync<T>(string url, T data) {
            var json = JsonConvert.SerializeObject(data);

            var request = new HttpRequestMessage(HttpMethod.Put, BuildUrl(url)) {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            await SendAsync(request);

            return true;
        }

        // 🔹 DELETE
        public static async Task<bool> DeleteAsync(string url) {
            var request = new HttpRequestMessage(HttpMethod.Delete, BuildUrl(url));

            await SendAsync(request);

            return true;
        }

        // 🔹 SAFE DESERIALIZATION
        private static T Deserialize<T>(string json) {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            try {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch {
                throw new Exception("Invalid JSON response: " + json);
            }
        }
    }
}
