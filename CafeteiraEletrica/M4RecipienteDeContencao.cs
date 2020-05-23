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

        protected internal override bool EstaPronto => EhParaIniciar(_api);


        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
        }

        private bool EhParaIniciar(ICoffeeMakerApi api)
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
    }
}
