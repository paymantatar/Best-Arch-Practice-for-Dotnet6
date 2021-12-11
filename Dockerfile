#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sample.sln", "Sample.sln"]
COPY ["Sample.Web/", "Sample.Web/"]
COPY ["Sample.Model/", "Sample.Model/"]
COPY ["Sample.Api/", "Sample.Api/"]
COPY ["Sample.DataAccess/", "Sample.DataAccess/"]
COPY ["Sample.Buisness/", "Sample.Buisness/"]

RUN dotnet restore "Sample.sln"

COPY . .
WORKDIR "/src/Sample.Web"
RUN dotnet build "Sample.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Web.dll"]