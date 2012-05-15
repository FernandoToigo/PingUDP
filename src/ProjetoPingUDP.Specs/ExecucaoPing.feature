#language: pt-br

Funcionalidade: Execução de Ping
	Para verificar o estado da minha rede
	Enquanto um administrador de redes
	Eu quero verificar o estado da rede entre o cliente e o servidor

Cenário: Execução de Ping com Sucesso
	Dado que informei 127.0.0.1 como IP do destino
	E que informei 8523 como porta do destino
	Quando eu clicar em "Enviar Ping"
	Então o pacote Ping deverá ser enviado para o servidor destino
	E deverei receber um pacote Ping de resposta com as informações da rede

Cenário: Execução de Ping Sem Resposta
	Dado que informei 1.1.1.1 como IP do destino
	E que informei 8524 como porta do destino
	Quando eu clicar em "Enviar Ping"
	Então o pacote Ping deverá ser enviado para o servidor destino
	E não deverei receber um pacote Ping de resposta com as informações da rede