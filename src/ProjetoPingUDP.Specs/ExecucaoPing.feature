#language: pt-br

Funcionalidade: Execução de Ping
	Para verificar o estado da minha rede
	Enquanto um administrador de redes
	Eu quero verificar o estado da rede entre o cliente e o servidor

Cenário: Execução de Ping com Sucesso
	Dado que informei 192.168.200.18 como IP do destino
	E que informei 8523 como porta do destino
	E que informei 4 como número de pacotes
    E que informei 8523 como porta do servidor
	E que o servidor de Ping está ativo
	Quando eu clicar em "Executar Ping"
	Então o pacote Ping deverá ser executado
	E deverei receber o resultado do Ping com as estatísticas da rede
	E o resultado deve conter pelo menos 1 pacote(s) respondido(s)

Cenário: Execução de Ping Sem Resposta
	Dado que informei 1.1.1.1 como IP do destino
	E que informei 8524 como porta do destino
	E que informei 4 como número de pacotes
	Quando eu clicar em "Executar Ping"
	Então o pacote Ping deverá ser executado
	E deverei receber o resultado do Ping com as estatísticas da rede
	E o resultado deve conter pelo menos 4 pacote(s) perdido(s)
	