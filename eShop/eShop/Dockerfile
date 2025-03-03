# https://hub.docker.com/_/microsoft-dotnet
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#COPY . /src
#WORKDIR /src
#RUN dotnet publish -c Release -o /app 


# final stage/image
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#COPY --from=build /app ./

# Указываем точку входа для запуска приложения
#ENTRYPOINT ["dotnet", "eShop.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "eShop.csproj"
RUN dotnet build "eShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShop.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.dll"]