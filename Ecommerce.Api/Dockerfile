# Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Ecommerce.Api/Ecommerce.Api.csproj Ecommerce.Api/
RUN dotnet restore Ecommerce.Api/Ecommerce.Api.csproj

COPY Ecommerce.Api/ Ecommerce.Api/
RUN dotnet publish Ecommerce.Api/Ecommerce.Api.csproj -c Release -o /app/publish --no-restore

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

ENTRYPOINT ["dotnet", "Ecommerce.Api.dll"]