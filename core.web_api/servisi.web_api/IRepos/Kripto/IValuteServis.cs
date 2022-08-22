using database.trading.DB_Models.Kripto;
using modeli.trading.Kripto;
using modeli.trading.Kripto.Reporting;
using servisi.trading.IRepos.Base;

namespace servisi.trading.IRepos.Kripto;
public interface IValuteServis: IReadServis<modeli.trading.Kripto.Valuta,valuta,object>
{
    public List<historijskiPodaci> GetHistorijskiPodaci(int id, string interval = "1D");
    public KriptoReport GetKriptoReport(int id);
    public List<Valuta> GetCBFValute(int id);
}

