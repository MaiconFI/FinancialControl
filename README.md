# FinancialControl

[![CodeFactor](https://www.codefactor.io/repository/github/maiconfi/financialcontrol/badge?s=b9f1e06192afe235f486de9c059e7c36c152f614)](https://www.codefactor.io/repository/github/maiconfi/financialcontrol)

Financial control application with CQRS and Event Sourcing.

ASP.NET Core application to perform the financial management. The architectural patterns CQRS and Event Sourcing were used, allowing the replication of all changes to the NoSQL database.

The docker-compose file was configured with the application and its dependencies. To test run the following command:
```
docker-compose up --build -d
```

An image of the application was created and made available on the Docker Hub:
```
https://hub.docker.com/r/maiconfi/financial-control
```
