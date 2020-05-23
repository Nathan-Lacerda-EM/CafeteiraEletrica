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
        private ICoffeeMakerApi _api;

        protected internal override bool EstaPronto => VerificaInicio(_api);

        public M4FonteDeAguaQuente(ICoffeeMakerApi api)
        {
            _api = api;
        }

        private bool VerificaInicio(ICoffeeMakerApi api)
        {
            if(api.GetBoilerStatus().Equals(BoilerStatus.NOT_EMPTY))
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
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}
