#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG TAG=5.0-alpine
ARG projName=Clock.SignalR.Server

FROM mcr.microsoft.com/dotnet/sdk:$TAG AS build
ARG projName
WORKDIR /src
COPY ${projName}/*.csproj .
RUN dotnet restore
COPY ${projName}/. .
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:$TAG
ARG projName
WORKDIR /app
COPY --from=build /app ./
ENV ASSEMBLY_NAME=${projName}.dll
ENTRYPOINT dotnet $ASSEMBLY_NAME