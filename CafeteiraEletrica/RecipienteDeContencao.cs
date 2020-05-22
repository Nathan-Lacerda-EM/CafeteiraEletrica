using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;

        protected internal abstract bool EstaPronto { get; }
    }
}
