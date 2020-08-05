# FinancialControl

[![CodeFactor](https://www.codefactor.io/repository/github/maiconfi/financialcontrol/badge?s=b9f1e06192afe235f486de9c059e7c36c152f614)](https://www.codefactor.io/repository/github/maiconfi/financialcontrol)

Financial control application with CQRS and Event Sourcing.

Aplicação ASP.NET Core para realizar o gerenciamento do financeiro. Foram utilizados os padrões arquiteturais CQRS e Event Sourcing, possibilitando
que todas as alterações sejam replicadas para o banco de dados NoSQL. 

Foi configurado o arquivo docker-compose com a aplicação e suas dependências. Para testar execute o seguinte comando:
```
docker-compose up --build -d
```

Foi criada e disponibilizada uma imagem da aplicação no Docker Hub:
```
https://hub.docker.com/r/maiconfi/financial-control
```
