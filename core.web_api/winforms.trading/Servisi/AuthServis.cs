using modeli.trading.Security;
using modeli.trading.Security.Request;
using modeli.trading.Security.Requests;
using Newtonsoft.Json;
using System.Text;
using winforms.trading.LocalStorage;
using winforms.trading.Properties;

namespace winforms.trading.Servisi
{
    public class AuthServis
    {
        private readonly HttpClient _httpClient;
        string serverUrl = "";

        public AuthServis()
        {
            serverUrl = Resources.ResourceManager.GetString("server")+ "auth_api/Auth";
            _httpClient = new HttpClient();
        }

        public async Task<bool> Login(LoginRequest req) {

            if (req == null)
            {
                Console.WriteLine("Request is null!");
                return false;
            }

            var json = JsonConvert.SerializeObject(req);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(serverUrl + "/Login", data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<Token>(result);
                if (token?.error == "x" && token.allowed_scopes.Contains("trading_api.admin"))
                {
                    Console.WriteLine("User has successfuly loged in!");
                    Console.WriteLine("Token is ok!");
                    DataStorage.token = token.value;
                    DataStorage.user_id = token.user_id;
                    Console.WriteLine("Token: " + DataStorage.token + "\n User id :" + DataStorage.user_id);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                Console.WriteLine("The credentials seem to be flawed.");
                return false;
            }

            return false;
        }

        public async Task<bool> Registracija(RegisterRequest req)
        {
            if (req == null)
            {
                Console.WriteLine("Request is null!");
                return false;
            }

            var json = JsonConvert.SerializeObject(req);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(serverUrl+"/Register", data);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<Token>(result);
                if (token?.error == "x")
                {
                    Console.WriteLine("User has successfuly registered!");
                    Console.WriteLine("Token is ok!");
                    DataStorage.token = token.value;
                    DataStorage.user_id = token.user_id;
                    Console.WriteLine("Token: "+ DataStorage.token+"\nUser id :"+ DataStorage.user_id);
                    return true;
                }
                else
                {
                    Console.WriteLine("The credentials seem to be flawed.");
                    return false;
                }
            }
            else
                Console.WriteLine("Server has responded with status code: " + response.StatusCode);

            return false;

        }

        public async Task<bool> Verifikacija(ConfirmationRequest req)
        {
            if (req == null)
            {
                Console.WriteLine("Request is null!");
                return false;
            }

            var json = JsonConvert.SerializeObject(req);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(serverUrl + "/Verify/Email", data);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);

                return true;
            }
            else
                Console.WriteLine("Server has responded with status code: " + response.StatusCode);

            return false;

        }

        public async Task<bool> Logout()
        {
            var json = JsonConvert.SerializeObject(new { });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(serverUrl + "/Logout/"+DataStorage.user_id,data);

            Console.WriteLine(response);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DataStorage.token = "";
                DataStorage.user_id = -1;

                return true;
            }

            return false;
        }
    }
}
