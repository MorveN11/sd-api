FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Project.Api/Project.Api.csproj", "Project.Api/"]
COPY ["Project.Business/Project.Business.csproj", "Project.Business/"]
COPY ["Project.DataAccess/Project.DataAccess.csproj", "Project.DataAccess/"]
COPY ["Project.Core/Project.Core.csproj", "Project.Core/"]
RUN dotnet restore "Project.Api/Project.Api.csproj"
COPY . .
WORKDIR "/src/Project.Api"
RUN dotnet build "Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.Api.dll"]
