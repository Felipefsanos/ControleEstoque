#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ControleEstoque/ControleEstoque.csproj", "ControleEstoque/"]
COPY ["ControleEstoque.Application/ControleEstoque.Application.csproj", "ControleEstoque.Application/"]
COPY ["ControleEstoque.Infra.Helpers/ControleEstoque.Infra.Helpers.csproj", "ControleEstoque.Infra.Helpers/"]
COPY ["ControleEstoque.Domain/ControleEstoque.Domain.csproj", "ControleEstoque.Domain/"]
COPY ["ControleEstoque.Infra.Data.IoC/ControleEstoque.Infra.Data.IoC.csproj", "ControleEstoque.Infra.Data.IoC/"]
COPY ["ControleEstoque.Infra.Data/ControleEstoque.Infra.Data.csproj", "ControleEstoque.Infra.Data/"]
RUN dotnet restore "ControleEstoque/ControleEstoque.csproj"
COPY . .
WORKDIR "/src/ControleEstoque"
RUN dotnet build "ControleEstoque.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleEstoque.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleEstoque.dll"]