#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0.1-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0.101-alpine3.12 AS build
WORKDIR /src
COPY ["Clock.SignalR.Server/Clock.SignalR.Server.csproj", "Clock.SignalR.Server/"]
RUN dotnet restore "Clock.SignalR.Server/Clock.SignalR.Server.csproj"
COPY . .
WORKDIR "/src/Clock.SignalR.Server"
RUN dotnet build "Clock.SignalR.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clock.SignalR.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clock.SignalR.Server.dll"]