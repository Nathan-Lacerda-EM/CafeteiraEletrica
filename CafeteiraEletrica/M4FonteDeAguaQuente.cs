using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4FonteDeAguaQuente : FonteDeAguaQuente, IPrepararCafe, IPollable
    {
        private readonly ICoffeeMakerApi _api;

        public M4FonteDeAguaQuente(ICoffeeMakerApi api)
        {
            this._api = api;
        }

        protected internal override bool EstaPronto => _api.GetBoilerStatus() == BoilerStatus.NOT_EMPTY;

        public override void Preparar()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
            EstaFazendo = true;
        }

        public override void Parar()
        {
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
        }
        public override void Continuar()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }

        public void Poll()
        {
            if (EstaFazendo)
                if (!EstaPronto)
                {
                    Pronto();
                }
                else if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
                    Parar();
                else
                {
                    Continuar();
                }
        }

    }
}
