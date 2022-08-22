using database.trading.DB_Models.SearchObjects;
using database.trading.DB_Models.Trading;
using modeli.trading.Trading;
using modeli.trading.Trading.Requests;
using servisi.trading.IRepos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.IRepos.Trading
{
    public interface INarudzbaServis : IReadWriteServis<Narudzba, narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest>
    {
        Task<bool> aktiviraj(int id); // aktivna za trading
        Task<bool> odbij(int id); // odbijena / canceled
        Task<bool> terminiraj(int id); // izvršena
        Task<List<Narudzba>> GetAllForms(int id); // izvršena
    }
}
