using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class FonteDeAguaQuente
    {
        private RecipienteDeContencao _recipienteDeContencao;
        private InterfaceDoUsuario _interfaceDoUsuario;

        public void Iniciar(InterfaceDoUsuario interfaceUsuario, RecipienteDeContencao recipienteDeContencao)
        {
            _interfaceDoUsuario = interfaceUsuario;
            _recipienteDeContencao = recipienteDeContencao;
        }

        protected internal abstract bool EstaPronto { get; }

        protected abstract void Preparar();
    }
}
