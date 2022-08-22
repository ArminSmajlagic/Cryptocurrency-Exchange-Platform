using database.trading.DB_Models.Trading;
using modeli.trading.Trading.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.StateMachine
{
    public class KreiranaNarudzbaState : BaseState
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly DatabaseContext context;

        public KreiranaNarudzbaState(IServiceProvider serviceProvider, IMapper mapper, DatabaseContext context) : base(serviceProvider, mapper, context)
        {
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.context = context;
        }

        public override async Task<narudzba> insert(NarudzbaUpsertRequest insertRequest)
        {
            var set = context.narudzbe;

            var entity = mapper.Map<narudzba>(insertRequest);

            entity.state = "kreirana";

            await set.AddAsync(entity);

            await context.SaveChangesAsync();

            narudzbaEntity = entity;

            return entity;
        }
    }
}
