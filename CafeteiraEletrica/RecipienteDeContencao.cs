using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;

        public void Iniciar(InterfaceDoUsuario interfaceDoUsuario, FonteDeAguaQuente fonteDeAguaQuente)
        {
            _interfaceDoUsuario = interfaceDoUsuario;
            _fonteDeAguaQuente = fonteDeAguaQuente;
        }

        protected internal abstract bool EstaPronto { get; }

        public abstract void Preparar();
    }
}
