using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4FonteDeAguaQuente : FonteDeAguaQuente, IPrepararCafe
    {
        private readonly ICoffeeMakerApi _api;

        public M4FonteDeAguaQuente(ICoffeeMakerApi api)
        {
            this._api = api;
        }

        protected internal override bool EstaPronto
        {
            get => _api.GetBoilerStatus() == BoilerStatus.NOT_EMPTY;
        }
        public override void Preparar()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}
