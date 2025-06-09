using EmployeeManagementSystemFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystemFrontend.Helper
{
    public static class HttpJsonHelper
    {
        private static readonly HttpClient _client = new HttpClient();
        public static string BaseUrl { get; set; } = "https://localhost:44353/api/Employee/";
        public static string Token { get; private set; }


        // Login and store the token
        public static async Task<bool> LoginAsync(int employeeId, string password)
        {
            try
            {
                var loginData = new { employee_id = employeeId, password };
                var url = BaseUrl + "login";
                var request = new HttpRequestMessage(HttpMethod.Post, url);

                string json = JsonConvert.SerializeObject(loginData);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                // If unauthorized, show message and return false
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return false;
                }
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(res))
                {
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(res);

                    if (!string.IsNullOrWhiteSpace(loginResponse?.token))
                    {
                        Token = loginResponse.token;
                        LoggedInEmployee.employee_id = employeeId;
                        LoggedInEmployee.password = password;
                        return true;
                    }
                }
                return false;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Invalid response format: {ex.Message}");
                return false;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Data format error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
                return false;
            }
        }


        public static async void DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var deleteRequest = new { employee_id = employeeId };
                string response = await HttpJsonHelper.SendJsonAsync("deleteemployee", deleteRequest, HttpMethod.Delete);
                MessageBox.Show("Employee deleted successfully!");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message);
            }
        }


        public static async Task<Employee> GetCurrentEmployeeAsync(int employee_id)
        {
            var employees = await GetJsonAsync<List<Employee>>($"employeeslist?employee_id={employee_id}");
            var emp = employees.FirstOrDefault();
            return emp;
        }


        // Generic method to send JSON data (POST/PUT)
        public static async Task<string> SendJsonAsync<T>(string route, T data, HttpMethod method)
        {
            var url = BaseUrl + route.TrimStart('/');
            using (var request = new HttpRequestMessage(method, url))
            {
                // Add JWT token if available
                if (!string.IsNullOrEmpty(Token))
                {
                    request.Headers.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                }

                string json = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        // Generic method to fetch JSON data (GET)
        public static async Task<TResult> GetJsonAsync<TResult>(string route)
        {
            var url = BaseUrl + route.TrimStart('/');
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                // Add JWT token if available
                if (!string.IsNullOrEmpty(Token))
                {
                    request.Headers.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                }

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }

    }
}
