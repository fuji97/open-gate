FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/OpenGate.STS.Identity/OpenGate.STS.Identity.csproj", "src/OpenGate.STS.Identity/"]
COPY ["src/OpenGate.Admin.EntityFramework.Shared/OpenGate.Admin.EntityFramework.Shared.csproj", "src/OpenGate.Admin.EntityFramework.Shared/"]
COPY ["src/OpenGate.Admin.EntityFramework.SqlServer/OpenGate.Admin.EntityFramework.SqlServer.csproj", "src/OpenGate.Admin.EntityFramework.SqlServer/"]
COPY ["src/OpenGate.Admin.EntityFramework.PostgreSQL/OpenGate.Admin.EntityFramework.PostgreSQL.csproj", "src/OpenGate.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/OpenGate.Admin.EntityFramework.MySql/OpenGate.Admin.EntityFramework.MySql.csproj", "src/OpenGate.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/OpenGate.STS.Identity/OpenGate.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/OpenGate.STS.Identity"
RUN dotnet build "OpenGate.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenGate.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "OpenGate.STS.Identity.dll"]