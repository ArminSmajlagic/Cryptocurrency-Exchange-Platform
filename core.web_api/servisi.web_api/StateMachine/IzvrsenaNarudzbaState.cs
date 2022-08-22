using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.StateMachine
{
    public class IzvrsenaNarudzbaState : BaseState
    {
        public IzvrsenaNarudzbaState(IServiceProvider serviceProvider, IMapper mapper, DatabaseContext context) : base(serviceProvider, mapper, context)
        {
        }

        public override void izvrši()
        {
            narudzbaEntity.state = "Izvršena";
        }
    }
}
