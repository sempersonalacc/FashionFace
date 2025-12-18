FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

ENV TZ=UTC
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["FashionFace.Executable.Hubs/FashionFace.Executable.Hubs.csproj", "FashionFace.Executable.Hubs/"]
RUN dotnet restore "FashionFace.Executable.Hubs/FashionFace.Executable.Hubs.csproj"
COPY . .
WORKDIR "/src/FashionFace.Executable.Hubs"
RUN dotnet build "FashionFace.Executable.Hubs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FashionFace.Executable.Hubs.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FashionFace.Executable.Hubs.dll"]