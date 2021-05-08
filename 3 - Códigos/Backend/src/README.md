# API Pedidos Para a Cozinha

O caso "real" será a aplicação "Pedidos Para a Cozinha".
O funcionamento básico se dará da seguinte forma:

Um restaurante deseja automatizar o fluxo de envio de pedidos para a cozinha. Para isso, se faz necessária a construção de uma aplicação que seja a interface de comunicação entre garçons e cozinheiros.

---
## Mapeamento das entidades

Como mapeamento das entidades do mundo real e propriedades dessas entidades, identifiquei algumas tais como:

**Cliente**
- Nome
- Numero da mesa
- Status

**Produto**
- Nome
- Descrição
- Preço

- Quantidade

**Cardapio**
- Lista de Produtos

**Pedido**
- Numero da Comanda ou Nome do Cliente
- Lista de Pedidos
- Status


¹ Caso alguma entidade não foi enxergada e você ache necessária, por favor, fique a vontade para compartilhar conosco :)

---
## O Projeto

O projeto será construido gradativamente e utilizará as tecnologias citadas no diretório anterior. O código se encontra disponível na pasta "src".


Foi utilizado na arquiterura do projeto o conceito de [Arquitetura Limpa](https://docs.microsoft.com/pt-br/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture), na qual, as divisões das responsabilidades podem variar de acordo com o tamanho/necessidade das aplicações. Fiz uma versão adaptada da original.


Se alguma extensão não tiver sido contemplada na parte teórica, podem mandar mensagens no grupo do [Telegram](http://t.me/helpstartbr).