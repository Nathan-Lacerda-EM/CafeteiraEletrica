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
        protected internal override bool EstaPronto { get; }
        public void Preparando()
        {
            throw new NotImplementedException();
        }
    }
}
