using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TQL_CSharp2WebApi {
    class Program {

        async Task Run() {
            var http = new HttpClient();
            var jsonSerializerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var employee = new Employee() {
                Id = 0, Login = "jdoe", Password = "password", Firstname = "Jane", Lastname = "Doe", IsManager = true
            };
            var json = JsonSerializer.Serialize<Employee>(employee, jsonSerializerOptions);
            var httpContent2 = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpMessageResponse2 = await http.PostAsync("http://localhost:40046/api/employees", httpContent2);
            

            var httpMessageResponse = await http.GetAsync("http://localhost:40046/api/employees");
            var httpContent = await httpMessageResponse.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize(httpContent, typeof(Employee[]), jsonSerializerOptions);
        }
        static async Task Main(string[] args) {
            var pgm = new Program();
            await pgm.Run();
        }
    }
}
