using Newtonsoft.Json;
using Flurl.Http;
using winforms.trading.Properties;
using System.Text;
using winforms.trading.LocalStorage;

namespace winforms.trading.Servisi
{
    public class APIServis<T>
    {
        private string _resource = null;
        public string _endpoint = "";
        public APIServis(string resource)
        {
            _endpoint = Resources.ResourceManager.GetString("server");
            _resource = resource;
        }

        public async Task<T> Get<T>(object search = null)
        {

            var list = await $"{_endpoint}{_resource}".WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}{_resource}/{id}".WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}".WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Put<T>(object id, object request)
        {
            var result = await $"{_endpoint}{_resource}/{id}".WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
    }
}
