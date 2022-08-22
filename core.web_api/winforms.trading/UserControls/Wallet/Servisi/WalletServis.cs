using modeli.trading.User.Wallet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using winforms.trading.LocalStorage;
using winforms.trading.Properties;

namespace winforms.trading.UserControls.Wallet.Servisi
{

    public class WalletServis
    {
        private readonly HttpClient _httpClient;
        string serverUrl = "";

        public List<WalletTransakcija> walletTransactions { get; set; }
        public modeli.trading.User.Wallet.Wallet wallet { get; set; }
        public List<WalletImovina> assets { get; set; }

        public WalletServis()
        {
            serverUrl = Resources.ResourceManager.GetString("server")+ "Wallet/";
            _httpClient = new HttpClient();
        }

        public async Task<bool> getTransactionData()
        {
            var url = serverUrl + wallet.id + "/getTransactionData";

            var response = await url.WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).GetJsonAsync<List<WalletTransakcija>>();

            walletTransactions = response;

            return true;

        }

        public async Task<bool> getWalletData(int user_id)
        {
            var url = serverUrl + user_id + "/getWalletData";

            if (user_id < 1)
            {
                Console.WriteLine("Request is null!");

                return false;
            }
            

            var response = await url.WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).GetJsonAsync<modeli.trading.User.Wallet.Wallet>();


            wallet = response;

            var assets_result = await GetCryptoAssets(wallet.id);

            return assets_result;

        }

        public async Task<bool> GetCryptoAssets(int wallet_id)
        {
            var url = serverUrl + wallet_id + "/GetCryptoAssets";

            if (wallet_id < 1)
            {
                Console.WriteLine("Request is null!");

                return false;
            }


            assets = await url.WithHeaders(new { Authorization = "Bearer " + DataStorage.token, Client = "desktop", Role = "Admin" }).GetJsonAsync<List<WalletImovina>>();

            return true;
        }

        public async Task<bool> Depozit(WalletTransakcija transakcija)
        {

            transakcija.walletId = wallet.id;

            var endpoint = serverUrl+ "DodajWalletTransakciju";


            var json = JsonConvert.SerializeObject(transakcija);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                return true;
            }
            else
            {
                Console.WriteLine("The wallet_id might not be valid.");

                return false;
            }
        }

        public async Task<bool> Withdraw(WalletTransakcija transakcija)
        {
            transakcija.walletId = wallet.id;

            var endpoint = serverUrl + "DodajWalletTransakciju";


            var json = JsonConvert.SerializeObject(transakcija);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                return true;

            }
            else
            {
                Console.WriteLine("The wallet_id might not be valid.");
                return false;

            }
        }
    }
}
