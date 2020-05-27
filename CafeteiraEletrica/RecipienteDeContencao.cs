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
        protected internal bool EstaEsquentando;
        protected internal bool CicloCompletoEPotVazio;
        protected internal abstract bool EstaPronto { get; }

        public RecipienteDeContencao()
        {
            EstaEsquentando = false;
            CicloCompletoEPotVazio = true;
        }

        public void Iniciar(InterfaceDoUsuario interfaceDoUsuario, FonteDeAguaQuente fonteDeAguaQuente)
        {
            _interfaceDoUsuario = interfaceDoUsuario;
            _fonteDeAguaQuente = fonteDeAguaQuente;
        }

        public void Completar()
        {
            _interfaceDoUsuario.FinalizarCiclo();
            CicloCompletoEPotVazio = true;
        }

        public void CafePronto()
        {
            _interfaceDoUsuario.Pronto();
            Continuar();
        }

        public void Preparar()
        {
            EstaEsquentando = true;
        }

        public abstract void Parar();
        public abstract void Continuar();
    }
}
