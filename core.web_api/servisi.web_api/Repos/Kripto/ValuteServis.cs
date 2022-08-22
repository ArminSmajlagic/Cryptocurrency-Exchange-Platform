using database.trading.DB_Models.Kripto;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using modeli.trading.Kripto;
using modeli.trading.Kripto.Reporting;
using servisi.trading.IRepos.Kripto;
using servisi.trading.Repos.Base;
using System.Net.Http;

namespace servisi.trading.Repos.Kripto;
public class ValuteServis : ReadServis<Valuta,valuta,object>,IValuteServis
{
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger logger;
    private readonly DatabaseContext Context;
    //private readonly HttpClient client;
    public ValuteServis(IMapper _mapper,DatabaseContext context, IConfiguration _config, ILogger _logger):base(_mapper,context,_config,_logger)
    {
        //client = new HttpClient();
        Context = context;
        config = _config;
        logger = _logger;
        mapper = _mapper;
    }

    //public async Task<List<Valuta>> GetValuteFromAPI(string interval)
    //{
    //    List<Valuta> list = new List<Valuta>();
    //    string url = "";

    //    var result = await client.GetAsync(url);

    //    if (result.StatusCode == System.Net.HttpStatusCode.OK)
    //    {

    //    }
    //    else
    //        Console.WriteLine("Status code: "+ result.StatusCode);
        

    //    return list;
    //}

    public List<historijskiPodaci> GetHistorijskiPodaci(int id,string interval = "1D")
    {
        //id valute

        var set = Context.histPodaci;

        var list = set.Where(x => x.valutaId == id).OrderByDescending(x=>x.id).ToList();

        return list;
    }

    public KriptoReport GetKriptoReport(int id)
    {
        var report = new KriptoReport();

        var set = Context.histPodaci;

        var list = set.Where(x => x.valutaId == id).ToList();
        var valuta = Context.valute.First(x=>x.valuta_id==id);

        if(list.Count == 0)
        {
            report.openAvg = 0;
            report.closeAvg = 0;
            report.lowAvg = 0;
            report.highAvg = 0;
            report.rank = valuta.rank;
            report.cap = 0;
            report.volume = 0;
        }
        else
        {
            report.openAvg = list.Average(x => x.open);
            report.closeAvg = list.Average(x => x.close);
            report.lowAvg = list.Average(x => x.low);
            report.highAvg = list.Average(x => x.high);
            report.rank = valuta.rank;
            report.cap = list.Average(x => x.market_cap);
            report.volume = list.Average(x => x.volume);
        }


        return report;
    }

    //content based filtering algoritam
    public List<Valuta> GetCBFValute(int id) //po id korisnika 
    {
        var result = new List<Valuta>();

        var narudzbe = Context.narudzbe.Include("valuta").Where(x=>x.userId == id).ToList();

        var valute = Context.valute.ToList();

        var dataRows = new List<DataRow>();
        var valuteDistance = new List<ValutaDistanca>();

        if (narudzbe.Count > 1)
        {
            foreach (var narudzba in narudzbe)
            {
                dataRows.Add(new DataRow() {
                    valuta_id = narudzba.valuta.valuta_id,
                    ponuda_id = narudzba.valuta.ponudaId,
                    cijena = narudzba.valuta.vrijednost,
                    rank = narudzba.valuta.rank
                });

            }
        }
        else
        {
            result = mapper.Map<List<Valuta>>(Context.valute.Where(x=>x.ponudaId==0).ToList()); //ako korisnik ne posjeduje narudžbe, daje mu se hot lista valuta

            return result;
        }

        for (int i = 0; i < valute.Count(); i++) //pronalazim euklidsku distancu valuta sa obzirom na valute iz narudžbi
        {
            valuteDistance.Add(new ValutaDistanca()
            {
                distanca = 9999999,
                valuta = valute[i]
            });

            for (int j = 0; j < dataRows.Count; j++)
            {

                //double x = Convert.ToDouble(dataRows[j].cijena) - Convert.ToDouble(valute[i].vrijednost);
                double x = dataRows[j].ponuda_id - valute[i].ponudaId;
                double y = dataRows[j].rank - valute[i].rank;

                x = x * x;
                y = y * y;
                //y = z * z;

                var euclidanDistance = Math.Sqrt(x + y);

                if(valuteDistance[i].distanca > euclidanDistance)
                    valuteDistance[i].distanca = euclidanDistance;
            }
        }

        //vracam listu valuta sortirani uzlazno po euklidskoj distanci (tako su valute pri vrhu liste one najslicnije valutama iz predhodne kupovine)
        result = mapper.Map<List<Valuta>>(valuteDistance.OrderBy(x=>x.distanca).Select(x=>x.valuta).ToList());

        return result;

    }   

    class DataRow //iz narudžbi korisnika
    {
        public int valuta_id { get; set; }
        public int ponuda_id { get; set; }
        public int rank { get; set; }
        public decimal cijena { get; set; }
    }

    class ValutaDistanca
    {
        public valuta valuta { get; set; }
        public double distanca { get; set; }
    }

}

