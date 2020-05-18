using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerApi
{
    public enum WarmerPlateStatus
    {
        WARMER_EMPTY,
        POT_EMPTY,
        POT_NOT_EMPTY
    }

    public enum BoilerStatus
    {
        EMPTY,
        NOT_EMPTY
    }

    public enum BrewButtonStatus
    {
        PUSHED,
        NOT_PUSHED
    }

    public enum BoilerState
    {
        ON,
        OFF
    };
    public enum WarmerState
    {
        ON,
        OFF
    };
    public enum IndicatorState
    {
        ON,
        OFF
    };
    public enum ReliefValveState
    {
        OPEN,
        CLOSED
    };

    public interface ICoffeeMakerApi
    {
        /*  
        *  Esta função retorna o status do sensor da chapa de aquecimento.  
        *  Esse sensor detecta a presença da jarra  * e se ela contém café.
        */
        WarmerPlateStatus GetWarmerPlateStatus();

        /*
         *  Esta função retorna o status do interruptor do boiler.
         *  Trata-se de um sensor por flutuação que detecta se
         *  há mais de 1/2 xícara de água no boiler.
         */
        BoilerStatus GetBoilerStatus();

        /*
         *  Esta função retorna o status do botão de preparo.
         *  O botão de preparo é um interruptor momentâneo que recorda
         *  seu estado. Cada chamada para essa função retorna o
         *  estado recordado e, então, redefine esse estado como
         *  NOT_PUSHED (não pressionado).
         *  Assim, mesmo que essa função seja sondada em uma velocidade
         *  muito lenta, ela ainda detectará quando o botão de preparo
         *  está pressionado.
         */
        BrewButtonStatus GetBrewButtonStatus();

        /*  Esta função liga ou desliga a resistência de aquecimento no boiler.*/
        void SetBoilerState(BoilerState s);

        /*  Esta função liga ou desliga a resistência na  * chapa de aquecimento.*/
        void SetWarmerState(WarmerState warmerState);

        /*
         *  Esta função liga ou desliga a luz do indicador.
         *  A luz do indicador deve ser ligada no final
         *  do ciclo de preparação. Ela deve ser desligada quando
         *  o usuário pressionar o botão de preparo.
         */
        void SetIndicatorState(IndicatorState indicatorState);

        /*
         *  Esta função abre e fecha a válvula de alívio de pressão.
         *  Quando essa válvula for fechada, a pressão do vapor no
         *  boiler forçará a água quente a borrifar sobre
         *  o filtro de café. Quando a válvula for aberta, o vapor
         *  no boiler escapará para o ambiente e a água
         *  do boiler não será borrifada no filtro.
         */
        void SetReliefValveState(ReliefValveState reliefValveState);
    }
}
