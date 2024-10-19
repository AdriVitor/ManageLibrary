FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ManageLibrary_API/ManageLibrary_API.csproj", "ManageLibrary_API/"]
COPY ["ManageLibrary_Infra.Ioc/ManageLibrary_Infra.Ioc.csproj", "ManageLibrary_Infra.Ioc/"]
COPY ["ManageLibrary_Application/ManageLibrary_Application.csproj", "ManageLibrary_Application/"]
COPY ["ManageLibrary_Domain/ManageLibrary_Domain.csproj", "ManageLibrary_Domain/"]
COPY ["ManageLibrary_Infra.Data/ManageLibrary_Infra.Data.csproj", "ManageLibrary_Infra.Data/"]
RUN dotnet restore "./ManageLibrary_API/ManageLibrary_API.csproj"
COPY . .
WORKDIR "/src/ManageLibrary_API"
RUN dotnet build "./ManageLibrary_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ManageLibrary_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManageLibrary_API.dll"]