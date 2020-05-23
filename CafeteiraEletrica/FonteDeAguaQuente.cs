using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class FonteDeAguaQuente
    {
        protected internal abstract bool EstaPronto { get; }

        internal abstract void IniciaFluxo();

        internal abstract void FinalizaPreparo();

        internal abstract void InterrompaFonteDeAguaQuente();

        internal abstract void RetomeFonteDeAguaQuente();

    }
}
