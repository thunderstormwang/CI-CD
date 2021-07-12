FROM ubuntu:20.04

# avoid interactive mode when installing tzdata
ENV DEBIAN_FRONTEND noninteractive

RUN apt-get update
RUN apt-get -y install docker.io

# install .net core SDK
RUN apt-get update && \
    apt-get install -y wget && \
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb
RUN apt-get update && \
    apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y dotnet-sdk-3.1

# install Cake.Tool
RUN dotnet new tool-manifest --name tool-manifest && \
    dotnet tool install Cake.Tool --version 1.1.0

CMD ["sleep","infinity"]
