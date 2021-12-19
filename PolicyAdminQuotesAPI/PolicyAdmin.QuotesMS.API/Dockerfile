#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PolicyAdmin.QuotesMS.API/PolicyAdmin.QuotesMS.API.csproj", "PolicyAdmin.QuotesMS.API/"]
RUN dotnet restore "PolicyAdmin.QuotesMS.API/PolicyAdmin.QuotesMS.API.csproj"
COPY . .
WORKDIR "/src/PolicyAdmin.QuotesMS.API"
RUN dotnet build "PolicyAdmin.QuotesMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PolicyAdmin.QuotesMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PolicyAdmin.QuotesMS.API.dll"]