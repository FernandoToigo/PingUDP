#language: pt-br

Funcionalidade: Iniciação do Servidor de Ping UDP
	Para auxiliar na verificação do estado da minha rede
	Enquanto um administrador de redes
	Eu quero iniciar o servidor de Ping UDP para recepção de pacotes de requisição de Ping

Cenário: Iniciar o Servidor de Ping UDP
	Dado que informei 2468 como porta do servidor
	Quando eu clicar em "Iniciar Servidor"
	Então o servidor de Ping deverá estar ativo
