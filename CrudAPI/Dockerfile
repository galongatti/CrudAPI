#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CrudAPI/CrudAPI.csproj", "CrudAPI/"]
RUN dotnet restore "CrudAPI/CrudAPI.csproj"
COPY . .
WORKDIR "/src/CrudAPI"
RUN dotnet build "CrudAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudAPI.dll"]