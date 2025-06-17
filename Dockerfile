# ===================================================================
# ETAPA 1: BUILD do front-end usando Node.js
# ===================================================================
FROM node:18 AS client-build

# 1.1) Define diretório de trabalho no ClientApp
WORKDIR /app/ClientApp

# 1.2) Copia package.json e package-lock.json para instalação otimizada
COPY ClientApp/package*.json ./

# 1.3) Instala as dependências do front-end
RUN npm install

# 1.4) Copia o restante dos arquivos e executa o build
COPY ClientApp/. ./
RUN npm run build


# ===================================================================
# ETAPA 2: BUILD do back-end ASP.NET Core 8.0 + front-end embutido
# ===================================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2.1) Copia os .csproj das camadas para restauração dos pacotes
COPY ministerio_gideoes_mirins.sln ./
COPY ministerio_gideoes_mirins/ministerio_gideoes_mirins.csproj ministerio_gideoes_mirins/
COPY Application/Application.csproj Application/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

# 2.2) Restaura os pacotes NuGet
RUN dotnet restore ministerio_gideoes_mirins.sln

# 2.3) Copia todo o restante da aplicação
COPY . .

# 2.4) Copia os arquivos do front-end buildado para o wwwroot da API
COPY --from=client-build /app/ClientApp/dist ./ministerio_gideoes_mirins/wwwroot/

# 2.5) Publica a aplicação (desabilitando o Target interno do front)
RUN dotnet publish ministerio_gideoes_mirins/ministerio_gideoes_mirins.csproj -c Release -o /app/publish -p:DisableBuildClientApp=true



# ===================================================================
# ETAPA 3: RUNTIME otimizado com segurança
# ===================================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 3.1) Cria usuário seguro não-root
RUN useradd -m appuser
USER appuser

# 3.2) Copia a aplicação publicada
COPY --from=build /app/publish .

# 3.3) Expõe a porta padrão da API
EXPOSE 80

# 3.4) Define variáveis de ambiente
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

# 3.5) Executa a aplicação
ENTRYPOINT ["dotnet", "ministerio_gideoes_mirins.dll"]
