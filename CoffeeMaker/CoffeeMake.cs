using CafeteiraEletrica;
using CoffeeMakerApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMake
    {
        public void Main(ICoffeeMakerApi api)
        {
            M4FonteDeAguaQuente fonteDeAguaQuente = new M4FonteDeAguaQuente(api);
            M4RecipienteDeContencao recipienteDeContencao = new M4RecipienteDeContencao(api);
            M4InterfaceDoUsuario interfaceDoUsuario = new M4InterfaceDoUsuario(api);
            fonteDeAguaQuente.Iniciar(interfaceDoUsuario, recipienteDeContencao);
            recipienteDeContencao.Iniciar(interfaceDoUsuario, fonteDeAguaQuente);
            interfaceDoUsuario.Iniciar(fonteDeAguaQuente, recipienteDeContencao);

            while (true)
            {
                interfaceDoUsuario.Preparar();
                recipienteDeContencao.Preparar();
                fonteDeAguaQuente.Preparar();
            }
        }
    }
}
