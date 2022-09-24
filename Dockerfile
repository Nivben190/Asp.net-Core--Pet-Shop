
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY amirProject.csproj ./
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef --version 6.0.8

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build-env /app/MyDb.db .
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "amirProject.dll"]