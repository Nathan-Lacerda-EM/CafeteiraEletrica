using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class RecipienteDeContencao
    {
        protected internal abstract bool EstaPronto { get; }

        internal abstract void IniciaFluxo();

        internal abstract void RetomeRecipienteDeContencao();

        internal abstract void InterrompaRecipienteDeContencao();
    }
}
