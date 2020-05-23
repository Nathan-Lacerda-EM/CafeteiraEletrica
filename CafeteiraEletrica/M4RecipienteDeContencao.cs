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

        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
        }

        protected internal override bool EstaPronto
        {
            get
            {
                return _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY;
            }
        }
        public void Preparando()
        {
            throw new NotImplementedException();
        }
    }
}
