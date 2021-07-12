FROM centos:7

# install .net core sdk
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum -y install dotnet-sdk-3.1

CMD ["/usr/sbin/init"]

