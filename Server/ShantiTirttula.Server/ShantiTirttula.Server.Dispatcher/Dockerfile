#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 707

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ShantiTirttula.Server.Dispatcher/ShantiTirttula.Server.Dispatcher.csproj", "ShantiTirttula.Server.Dispatcher/"]
RUN dotnet restore "ShantiTirttula.Server.Dispatcher/ShantiTirttula.Server.Dispatcher.csproj"
COPY . .
WORKDIR "/src/ShantiTirttula.Server.Dispatcher"
RUN dotnet build "ShantiTirttula.Server.Dispatcher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShantiTirttula.Server.Dispatcher.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShantiTirttula.Server.Dispatcher.dll"]