FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app
COPY . .

#RUN dotnet restore 
#RUN dotnet build -c Release -o /out
RUN dotnet publish src/WebApi/DockerExample.WebApi/DockerExample.WebApi.csproj -c Release -o /out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
COPY --from=build-env /out .

# Full PGO
ENV DOTNET_TieredPGO 1 
ENV DOTNET_TC_QuickJitForLoops 1 
ENV DOTNET_ReadyToRun 0
ENV ASPNETCORE_URLS=http://+:9001

EXPOSE 9001
ENTRYPOINT dotnet DockerExample.WebApi.dll