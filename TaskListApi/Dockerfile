# Imagem de build com suporte para .NET 8.0 (substituir com a versão mais recente disponível)
FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src

# Copie o arquivo csproj e restaure as dependências
COPY ["TaskListApi/TaskListApi.csproj", "TaskListApi/"]
RUN dotnet restore "TaskListApi/TaskListApi.csproj"

# Copie os arquivos restantes e construa o projeto
COPY . .
WORKDIR "/src/TaskListApi"
RUN dotnet build "TaskListApi.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "TaskListApi.csproj" -c Release -o /app/publish

# Imagem base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 3000

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskListApi.dll"]
