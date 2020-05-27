using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4RecipienteDeContencao : RecipienteDeContencao, IPrepararCafe, IPollable
    {
        private ICoffeeMakerApi _api;

        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
        }

        protected internal override bool EstaPronto => _api.GetWarmerPlateStatus() != WarmerPlateStatus.WARMER_EMPTY;

        public override void Parar()
        {
            _api.SetWarmerState(WarmerState.OFF);
        }

        public override void Continuar()
        {
            _api.SetWarmerState(WarmerState.ON);
        }

        public void Poll()
        {
            if (EstaEsquentando)
                if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
                    Parar();
                else if (_api.GetBoilerStatus() == BoilerStatus.EMPTY && _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
                    Completar();
                else if (_api.GetBoilerStatus() == BoilerStatus.EMPTY && _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
                    CafePronto();
                else
                    Continuar();
        }
    }
}
