#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Assignment1.csproj", "./Assignment1/"]
RUN dotnet restore "Assignment1/Assignment1.csproj"

WORKDIR "/src/Assignment1"
COPY . .
RUN dotnet build "Assignment1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assignment1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assignment1.dll"]