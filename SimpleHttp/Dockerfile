FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleHttp/SimpleHttp.csproj", "SimpleHttp/"]
RUN dotnet restore "SimpleHttp/SimpleHttp.csproj"
COPY . .
WORKDIR "/src/SimpleHttp"
RUN dotnet build "SimpleHttp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleHttp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleHttp.dll"]
