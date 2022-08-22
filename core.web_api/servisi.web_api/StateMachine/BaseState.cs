using database.trading.DB_Models.Trading;
using Microsoft.Extensions.DependencyInjection;
using modeli.trading.Trading.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.StateMachine
{
    public class BaseState
    {
        public narudzba narudzbaEntity { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public IMapper mapper { get; set; }
        public DatabaseContext Context { get; set; }

        public BaseState(IServiceProvider serviceProvider, IMapper mapper, DatabaseContext context)
        {
            Context = context;
            ServiceProvider = serviceProvider;
            this.mapper = mapper;
        }

        public virtual async Task<narudzba> insert (NarudzbaUpsertRequest insertRequest) // kreirana
        {
            throw new Exception("This is update method from abstract BaseState class.");

        }

        public virtual Task<narudzba> update(NarudzbaUpsertRequest updateRequest)
        {
            throw new Exception("This is update method from abstract BaseState class.");
        }

        public virtual void aktiviraj() // aktivna
        {
            throw new Exception("This is aktiviraj method from abstract BaseState class.");
        }

        public virtual void odbij() // odbij
        {
            throw new Exception("This is odbij method from abstract BaseState class.");
        }


        public virtual void izvrši() // izvršena/finished
        {
            throw new Exception("This is izvrši method from abstract BaseState class.");
        }

        public BaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "kreirana":
                    return ServiceProvider.GetService<KreiranaNarudzbaState>();
                    break;
                case "aktivna":
                    return ServiceProvider.GetService<AktivnaNarudzbaState>();
                case "odbijena":
                    return ServiceProvider.GetService<OdbijenaNarudzbaState>();
                case "izvrsena":
                    return ServiceProvider.GetService<IzvrsenaNarudzbaState>();
                default:
                    throw new Exception("State name not known!");
            }
        }
    }

}
