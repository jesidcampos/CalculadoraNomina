FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["CalculadoraNomina.csproj", "./"]
RUN dotnet restore "CalculadoraNomina.csproj"

COPY . .
RUN dotnet publish "CalculadoraNomina.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "CalculadoraNomina.dll"]