FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5229

ENV ASPNETCORE_URLS=http://+:5229

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["AcaApp.RazorWeb/AcaApp.RazorWeb.csproj", "AcaApp.RazorWeb/"]
RUN dotnet restore "AcaApp.RazorWeb/AcaApp.RazorWeb.csproj"
COPY . .
WORKDIR "/src/AcaApp.RazorWeb"
RUN dotnet build "AcaApp.RazorWeb.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "AcaApp.RazorWeb.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcaApp.RazorWeb.dll"]
