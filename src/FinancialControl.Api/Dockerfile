#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/FinancialControl.Api/FinancialControl.Api.csproj", "src/FinancialControl.Api/"]
COPY ["src/FinancialControl.Infrastructure.Data/FinancialControl.Infrastructure.Data.csproj", "src/FinancialControl.Infrastructure.Data/"]
COPY ["src/FinancialControl.Domain/FinancialControl.Domain.csproj", "src/FinancialControl.Domain/"]
COPY ["src/FinancialControl.Application/FinancialControl.Application.csproj", "src/FinancialControl.Application/"]
COPY ["src/FinancialControl.Queries/FinancialControl.Queries.csproj", "src/FinancialControl.Queries/"]
RUN dotnet restore "src/FinancialControl.Api/FinancialControl.Api.csproj"
COPY . .
WORKDIR "/src/src/FinancialControl.Api"
RUN dotnet build "FinancialControl.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialControl.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialControl.Api.dll"]