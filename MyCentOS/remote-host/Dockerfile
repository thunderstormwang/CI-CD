FROM centos:7

RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum -y install dotnet-sdk-3.1

CMD ["/usr/sbin/init"]

