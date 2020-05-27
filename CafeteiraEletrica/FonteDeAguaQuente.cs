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
        protected internal bool EstaFazendo;
        protected internal abstract bool EstaPronto { get; }

        public FonteDeAguaQuente()
        {
            EstaFazendo = false;
        }

        public void Iniciar(InterfaceDoUsuario interfaceUsuario, RecipienteDeContencao recipienteDeContencao)
        {
            _interfaceDoUsuario = interfaceUsuario;
            _recipienteDeContencao = recipienteDeContencao;
        }

        public void Pronto()
        {
            EstaFazendo = false;
            Parar();
            _interfaceDoUsuario.Pronto();
        }

        public abstract void Preparar();
        public abstract void Parar();
        public abstract void Continuar();
    }
}
