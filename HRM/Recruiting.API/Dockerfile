# Fetching asp.net run time
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Get the sdk from microsoft, for compiling and building our application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# copy the project files to the docker
COPY ["Recruiting.API/Recruiting.API.csproj", "Recruiting.API/"]
COPY ["Services/Recruiting/ApplicationCore/ApplicationCore.csproj", "Services/Recruiting/ApplicationCore/"]
COPY ["Services/Recruiting/Infrastructure/Infrastructure.csproj", "Services/Recruiting/Infrastructure/"]
# restore the references
RUN dotnet restore "Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/Recruiting.API"
# compile app.
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]
