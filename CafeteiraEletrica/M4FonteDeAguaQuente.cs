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
        protected internal override bool EstaPronto => EhParaIniciar(_api);
        private ICoffeeMakerApi _api;

        public M4FonteDeAguaQuente(ICoffeeMakerApi api)
        {
            _api = api;
        }

        private bool EhParaIniciar(ICoffeeMakerApi api)
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
    }
}
