using database.trading.DB_Models.SearchObjects;
using database.trading.DB_Models.Trading;
using database.trading.DB_Models.User.Wallet;
using modeli.trading.Trading;
using modeli.trading.Trading.Requests;
using servisi.trading.IRepos.Trading;
using servisi.trading.Repos.Base;
using servisi.trading.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.Repos.Trading
{
    public class NarudzbaServis : ReadWriteBaseServis<Narudzba, narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest>, INarudzbaServis
    {
        private readonly DatabaseContext context;

        public BaseState baseState { get; set; }
        public NarudzbaServis(IMapper _mapper, DatabaseContext context, IConfiguration _config, ILogger _logger, BaseState baseState) : base(_mapper, context, _config, _logger)
        {
            this.context = context;
            this.baseState = baseState;
        }

        public async Task<int> Kupi(NarudzbaUpsertRequest requestBody)
        {

            requestBody.kreirana = DateTime.Now;

            var walletNarucioca = context.walleti.FirstOrDefault(x => x.userId == requestBody.userId);

            var setImovinaNarucioca = context.wallet_imovine.Where(x => x.walletId == walletNarucioca.id).ToList();

            wallet_imovina wcashKupca = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == 15);

            wallet_imovina valutaKupovine = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == requestBody.valutaId);

            List<narudzba> narudzbe = context.narudzbe.ToList();

            if (wcashKupca.kolicina_valute < requestBody.cijena) //dali korisnik ima dovoljno da plati transakciju
                return 2;

            if (valutaKupovine == null) //spremanje valute koju korisnik želi da kupi
            {
                var valuta = context.valute.FirstOrDefault(x => x.valuta_id == requestBody.valutaId);

                valutaKupovine = new wallet_imovina()
                {
                    walletId = walletNarucioca.id,
                    kolicina_valute = 0,
                    naziv_valute = valuta.naziv,
                    valuta_id = requestBody.valutaId,
                };
                context.wallet_imovine.Add(valutaKupovine);

                await context.SaveChangesAsync();
            }


            foreach (var narudzba in narudzbe)
            {
                if (narudzba.state != "izvrsena" && narudzba.state != "odbijena")
                {
                    if (narudzba.valutaId == requestBody.valutaId && narudzba.kolicina == requestBody.kolicina)
                    {
                        //povecat kolicinu imovine novog vlasnika (kupca)

                        valutaKupovine.kolicina_valute += requestBody.kolicina;

                        //smanjit kolicinu imovine starog vlasnika (prodavca)

                        var prodavacWallet = context.walleti.FirstOrDefault(x => x.userId == narudzba.userId);

                        var prodavacImovina = context.wallet_imovine.First(x => x.valuta_id == requestBody.valutaId && x.walletId == prodavacWallet.id);

                        prodavacImovina.kolicina_valute -= requestBody.kolicina;

                        //smanjit wcash kupcu

                        wcashKupca.kolicina_valute -= requestBody.cijena;

                        //povecat wcash prdavcu

                        var prodavacWcash = context.wallet_imovine.First(x => x.valuta_id == 15 && x.walletId == prodavacWallet.id);

                        prodavacWcash.kolicina_valute += requestBody.cijena;

                        //terminiraj narudžbu prodaje

                        await terminiraj(narudzba.id);                        
                        
                        //spremi promjene

                        await context.SaveChangesAsync();

                        return 1;
                    }

                }
            }

            return 0;
        }



        public async Task<int> Prodaj(NarudzbaUpsertRequest requestBody)
        {

            requestBody.kreirana = DateTime.Now;

            var walletNarucioca = context.walleti.FirstOrDefault(x => x.userId == requestBody.userId);

            var setImovinaNarucioca = context.wallet_imovine.Where(x => x.walletId == walletNarucioca.id).ToList();

            wallet_imovina? wcashProdavca = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == 15);

            wallet_imovina? valutaProdaje = setImovinaNarucioca.FirstOrDefault(x => x.valuta_id == requestBody.valutaId);

            List<narudzba> narudzbe = context.narudzbe.ToList();

            if (valutaProdaje == null) //dali korisnik uopšte ima valutu koju žei prodati
                return 2;

            if (valutaProdaje.kolicina_valute < requestBody.kolicina) //dali korisnik ima dovoljno da proda valutu
                return 2;


            foreach (var narudzba in narudzbe)
            {
                if (narudzba.state != "izvrsena" && narudzba.state != "odbijena")
                {
                    if (narudzba.valutaId == requestBody.valutaId && narudzba.kolicina == requestBody.kolicina)
                    {
                        //smanjit kolicinu imovine starog vlasnika (prodavca)

                        var kupacWallet = context.walleti.FirstOrDefault(x => x.userId == narudzba.userId);
                        var kupacImovina = context.wallet_imovine.Where(x => x.walletId == kupacWallet.id).ToList();

                        if (kupacWallet?.id != walletNarucioca?.id)
                        {

                            var kupacValutaInteresa = kupacImovina.FirstOrDefault(x=>x.valuta_id == requestBody.valutaId);
                            var kupacWCash = kupacImovina.FirstOrDefault(x=>x.valuta_id == 15);

                            if (kupacValutaInteresa == null) {
                                kupacValutaInteresa = new wallet_imovina()
                                {
                                    kolicina_valute = 0,
                                    naziv_valute = valutaProdaje.naziv_valute,
                                    valuta_id = valutaProdaje.valuta_id,
                                    walletId = kupacWallet.id                                 
                                };

                                context.wallet_imovine.Add(kupacValutaInteresa);

                                await context.SaveChangesAsync();
                            }


                            if (kupacWCash?.kolicina_valute >= requestBody.cijena)
                            {


                                //povecat kolicinu imovine novog vlasnika (kupca)

                                kupacValutaInteresa.kolicina_valute += requestBody.kolicina;

                                //smanjit kolicinu imovine starog vlasnika (prodavca)

                                valutaProdaje.kolicina_valute -= requestBody.kolicina;


                                //povecat wcash prdavcu

                                wcashProdavca.kolicina_valute += requestBody.cijena;

                                //smanjit wcash kupcu

                                kupacWCash.kolicina_valute -= requestBody.cijena;

                                await context.SaveChangesAsync();

                                //terminiraj narudžbu prodaje

                                await terminiraj(narudzba.id);

                                //terminiraj narudžbu kupovine

                                return 1;
                            }
                        }
                    }

                }
            }

            return 0;
        }


        public override async Task<narudzba> Insert(NarudzbaUpsertRequest requestBody)
        {
            BaseState state = null;
            int success = 0;

            if (requestBody.tip==0)
                success = await Prodaj(requestBody);
            else
                success = await Kupi(requestBody);

            if (success == 2)
                return null;

            state = baseState.CreateState("kreirana");
            var result = await state.insert(requestBody);

            if (success==1)
            {
                await terminiraj(result.id);
                result.state = "izvrsena";
            }

            return result;
        }

        public async Task<bool> aktiviraj(int id)
        {
            var state = baseState.CreateState("aktivna");

            if(state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "aktivna";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> odbij(int id)
        {
            var state = baseState.CreateState("odbijena");

            if (state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "odbijena";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> terminiraj(int id)
        {
            var state = baseState.CreateState("izvrsena");

            //skinut WCash sa racuna i dodajem novu imovinu

            if (state != null)
            {
                var narudzba = context.narudzbe.FirstOrDefault(x => x.id == id);

                narudzba.state = "izvrsena";

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Narudzba>> GetAllForms(int id = 0)
        {
            var setNarudzbi = context.narudzbe;
            var setKorisnika = context.korisnici;
            var setValuta = context.valute;

            var result = new List<Narudzba>();

            foreach (var narudzba in setNarudzbi)
            {
                    var korisnik = await setKorisnika.FindAsync(narudzba.userId);
                    var valuta = await setValuta.FindAsync(narudzba.valutaId);

                if (id != 0 && narudzba.userId == id) { 
                    result.Add(new Narudzba() {
                        cijena = narudzba.cijena,
                        id = narudzba.id,
                        kolicina = narudzba.kolicina,
                        kreirana = narudzba.kreirana,
                        state = narudzba.state,
                        userId = narudzba.userId,
                        userIme = korisnik.ime_prezime,
                        valutaId = narudzba.valutaId,
                        valutaNaziv = valuta.naziv,
                        tip = narudzba.tip

                    });
                }else if(id == 0)
                {
                    result.Add(new Narudzba()
                    {
                        cijena = narudzba.cijena,
                        id = narudzba.id,
                        kolicina = narudzba.kolicina,
                        kreirana = narudzba.kreirana,
                        state = narudzba.state,
                        userId = narudzba.userId,
                        userIme = korisnik.ime_prezime,
                        valutaId = narudzba.valutaId,
                        valutaNaziv = valuta.naziv,
                        tip = narudzba.tip

                    });
                }
            }

            return result;
        }
    }
}
