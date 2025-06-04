FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ministerio_gideoes_mirins.sln ./
COPY ministerio_gideoes_mirins/ministerio_gideoes_mirins.csproj ministerio_gideoes_mirins/
COPY Application/Application.csproj Application/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore ministerio_gideoes_mirins.sln

# copy the remaining source
COPY . ./

RUN dotnet publish ministerio_gideoes_mirins/ministerio_gideoes_mirins.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ministerio_gideoes_mirins.dll"]