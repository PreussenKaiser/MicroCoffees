FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/MicroCoffees.Coffees/MicroCoffees.Coffees.csproj", "MicroCoffees.Api/"]
RUN dotnet restore "MicroCoffees.Api/MicroCoffees.Coffees.csproj"
COPY . .
WORKDIR "/src/Services/MicroCoffees.Coffees"
RUN dotnet build "MicroCoffees.Coffees.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroCoffees.Coffees.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroCoffees.Coffees.dll"]