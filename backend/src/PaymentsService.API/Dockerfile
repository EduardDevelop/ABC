FROM ubuntu:22.04

WORKDIR /app

# Instalar dependencias necesarias para .NET
RUN apt-get update && apt-get install -y \
    curl \
    ca-certificates \
    libicu70 \
    libssl3 \
    zlib1g

# Agregar repositorio Microsoft
RUN curl -sSL https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -o packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb

# Instalar ASP.NET runtime
RUN apt-get update && apt-get install -y aspnetcore-runtime-8.0

# Copiar aplicación publicada
COPY publish/ .

EXPOSE 8080

ENTRYPOINT ["dotnet", "PaymentsService.API.dll"]