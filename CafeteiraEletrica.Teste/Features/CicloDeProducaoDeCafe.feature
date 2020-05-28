# language: pt-BR

Funcionalidade: Ciclo de producão de café

Cenário: Ciclo de preparação do café
	Dado uma cafeteira elétrica em perfeito funcionamento
	E abastecido com água o respectivo receptáculo
	E uma jarra vazia acoplada para coleta do café
	Quando pressionada a opção preparar
	Então o café está pronto e mantido aquecido

Cenário: Ciclo de preparação do café finalizado
	Dado o café pronto para o consumo
	Quando identificado que foi servido por completo
	Então o ciclo de preparação do café e finalizado