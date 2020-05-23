using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4RecipienteDeContencao : RecipienteDeContencao, IPrepararCafe
    {
        private ICoffeeMakerApi _api;
        private bool EstaPreparando = false;

        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
        }

        protected internal override bool EstaPronto => _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY;

        public override void Preparar()
        {
            EstaPreparando = true;
            _api.SetWarmerState(WarmerState.ON);
        }

        public void RecipienteRemovido()
        {
            if(!EstaPreparando)
            {
                _api.SetWarmerState(WarmerState.OFF);
                InterromperFluxo();
            }
        }
    }
}
