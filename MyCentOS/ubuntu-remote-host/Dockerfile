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
    apt-get install -y dotnet-sdk-3.1

# install Cake.Tool
RUN dotnet new tool-manifest --name tool-manifest && \
    dotnet tool install Cake.Tool --version 1.1.0

# install openssh server
RUN apt update && \
    apt install -y openssh-server

# add user jenkins
RUN useradd -G docker jenkins && \
    echo "jenkins:1234" | chpasswd
# for the same group id with host
RUN groupmod -g 995 docker

# depoloy ssh key
RUN mkdir /home/jenkins && \
    mkdir /home/jenkins/.ssh && \
    chmod 700 /home/jenkins/.ssh
COPY remote-key.pub /home/jenkins/.ssh/authorized_keys
RUN chown jenkins:jenkins -R /home/jenkins && \
    chmod 400 /home/jenkins/.ssh/authorized_keys

RUN service ssh start

EXPOSE 22

CMD ["/usr/sbin/sshd", "-D"]
