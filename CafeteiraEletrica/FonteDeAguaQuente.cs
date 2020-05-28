using CoffeeMakerApi;
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
        protected internal bool EstaPreparando;
        protected internal abstract bool EstaPronto { get; }

        public FonteDeAguaQuente()
        {
            EstaPreparando = false;
        }

        public void Iniciar(InterfaceDoUsuario interfaceUsuario, RecipienteDeContencao recipienteDeContencao)
        {
            _interfaceDoUsuario = interfaceUsuario;
            _recipienteDeContencao = recipienteDeContencao;
        }

        public void IniciarPreparo()
        {
            EstaPreparando = true;
            Continuar();
        }

        public void Pronto()
        {
            _recipienteDeContencao.CafePronto();
            _interfaceDoUsuario.Pronto();
            EstaPreparando = false;
        }

        public abstract void Parar();
        public abstract void Continuar();
    }
}
