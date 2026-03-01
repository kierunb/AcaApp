FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5174

ENV ASPNETCORE_URLS=http://+:5174

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["AcaApp.WebApi/AcaApp.WebApi.csproj", "AcaApp.WebApi/"]
RUN dotnet restore "AcaApp.WebApi/AcaApp.WebApi.csproj"
COPY . .
WORKDIR "/src/AcaApp.WebApi"
RUN dotnet build "AcaApp.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "AcaApp.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcaApp.WebApi.dll"]
