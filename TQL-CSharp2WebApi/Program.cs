using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TQL_CSharp2WebApi {

    class Program {

        public static int Id { get; set; }

        async Task Run() {
            var http = new HttpClient();
            var jsonSerializerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var url = "http://localhost:40046/api/employees";

            var newEmpl = new Employee() {
                Id = 0, Firstname = "Noah", Lastname = "Phence", Login = "nphence", Password = "password", IsManager = true
            };
            var json = JsonSerializer.Serialize<Employee>(newEmpl, jsonSerializerOptions);
            var httpContent2 = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpMessageResponse2 = await http.PostAsync(url, httpContent2);

            var httpMessageResponse = await http.GetAsync(url);
            var httpContent = await httpMessageResponse.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<Employee[]>(httpContent, jsonSerializerOptions);

            foreach(var e in employees) {
                Console.WriteLine($"{e.Id} | {e.Lastname}");
            }
        }

        async static Task Main(string[] args) {
            var pgm = new Program();
            await pgm.Run();
        }
    }
}
