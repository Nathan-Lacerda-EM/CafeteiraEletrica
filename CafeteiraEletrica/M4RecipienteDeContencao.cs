using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4RecipienteDeContencao : RecipienteDeContencao, IPrepararCafe
    {
        private ICoffeeMakerApi _api;

        protected internal override bool EstaPronto => VerificaInicio(_api);

        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
        }

        private bool VerificaInicio(ICoffeeMakerApi api)
        {
            if(api.GetWarmerPlateStatus().Equals(WarmerPlateStatus.POT_EMPTY))
            {
                return true;
            }

            return false;
        }

        public void Preparando()
        {
            throw new NotImplementedException();
        }

        internal override void IniciaFluxo()
        {
            
        }

        internal override void RetomeRecipienteDeContencao()
        {
            _api.SetWarmerState(WarmerState.ON);
        }

        internal override void InterrompaRecipienteDeContencao()
        {
            _api.SetWarmerState(WarmerState.OFF);
        }
    }
}
