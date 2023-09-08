FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Marten-tenancy-modular-monolith/Marten-tenancy-modular-monolith.csproj", "Marten-tenancy-modular-monolith/"]
RUN dotnet restore "Marten-tenancy-modular-monolith/Marten-tenancy-modular-monolith.csproj"
COPY . .
WORKDIR "/src/Marten-tenancy-modular-monolith"
RUN dotnet build "Marten-tenancy-modular-monolith.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Marten-tenancy-modular-monolith.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Marten-tenancy-modular-monolith.dll"]
