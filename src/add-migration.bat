@ECHO OFF
SET /P migrationName=Digite o nome do migration: 

CD %CD%
CALL dotnet ef migrations add "%migrationName%" -s "FinancialControl.Api\FinancialControl.Api.csproj" -p "FinancialControl.Infrastructure.Data\FinancialControl.Infrastructure.Data.csproj" -v

PAUSE