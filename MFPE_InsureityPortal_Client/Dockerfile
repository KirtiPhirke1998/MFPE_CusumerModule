#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["MFPE_InsureityPortal_Client/MFPE_InsureityPortal_Client.csproj", "MFPE_InsureityPortal_Client/"]
#RUN dotnet restore "MFPE_InsureityPortal_Client/MFPE_InsureityPortal_Client.csproj"
#COPY . .
#WORKDIR "/src/MFPE_InsureityPortal_Client"
#RUN dotnet build "MFPE_InsureityPortal_Client.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "MFPE_InsureityPortal_Client.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MFPE_InsureityPortal_Client.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MFPE_InsureityPortal_Client.dll"]