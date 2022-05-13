#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Onboarding.API/Onboarding.API.csproj", "Onboarding.API/"]
RUN dotnet restore "Onboarding.API/Onboarding.API.csproj"
COPY . .
WORKDIR "/src/Onboarding.API"
RUN dotnet build "Onboarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding.API.dll"]