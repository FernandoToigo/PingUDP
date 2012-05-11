#language: pt-br

Funcionalidade: Finalização do Servidor de Ping UDP
	Para liberar a porta de comunicação
	Enquanto um administrador de redes
	Eu quero finalizar o servidor de Ping UDP

Cenário: Finalizar o Servidor de Ping UDP
	Dado que informei 2469 como porta do servidor
	E que o servidor de Ping está ativo
	Quando eu clicar em "Parar Servidor"
	Então o servidor Ping deverá estar desativado
