FROM ubuntu:22.04

WORKDIR /app

# Instalar dependencias
RUN apt-get update && apt-get install -y \
    curl \
    ca-certificates \
    libicu70 \
    libssl3 \
    zlib1g

# Instalar repositorio Microsoft
RUN curl -sSL https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -o packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb

# Instalar runtime ASP.NET 8
RUN apt-get update && apt-get install -y aspnetcore-runtime-8.0

COPY publish/ .

EXPOSE 8080

ENTRYPOINT ["dotnet", "UsersService.Api.dll"]