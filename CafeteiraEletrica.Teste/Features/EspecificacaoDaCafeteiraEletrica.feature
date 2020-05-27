# language: pt-BR

Funcionalidade: Especificação da cafeteira eletrica

Cenário: O preparo de café e iniciado com falha
	Dado uma fonte de água quente
	E que a fonte não contém água
	Dado um recipiente de contenção
	E que o recipiente não esteja acoplado
	Dada uma interface de usuário
	E pressionado o botão de início
	Quando iniciado o preparo do café
	Então o preparo do café não é iniciado

Cenário: O preparo do café é iniciado
	Dada uma fonte de água quente
	E que a fonte contém água
	Dado um recipiente de contenção
	E que o recipiente esteja acoplado
	Dada uma interface de usuário
	E pressionado o botão de início
	Quando iniciado o preparo do café
	Então o preparo do café é iniciado

Cenário: Extração do recipiente de contenção
	Dado que o preparo do café foi iniciado
	Quando o recipiente de contenção é extraído
	Então o preparo do café é interrompido

Cenário: Devolução do recipiente de contenção
	Dado o preparo do café é interrompido
	Quando o recipiente de contenção é devolvido
	Então o preparo do café é retomado

Cenário: Preparado e pronto para consumo
	Dado que o preparo do café foi iniciado
	Quando concluído o preparo do café
	Então o café está pronto para o consumo
	E mantido aquecido até ser consumido por completo

Cenário: O café é consumido por completo
	Dado o café pronto para consumo
	Quando identificado o consumo completo
	Então o ciclo de preparo é finalizado

Cenário: Enquanto não consumido por completo
	Dado o café pronto para consumo
	Quando identificado que ainda não foi consumido por completo
	Então mantido aquecido até ser consumido por completo