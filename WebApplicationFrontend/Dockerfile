FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 

RUN groupadd -g 999 appuser && \
    useradd -r -u 999 -g appuser appuser
User appuser


WORKDIR /app

COPY ./WebApplicationFrontend/bin/Release/netcoreapp3.1/ .

EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApplicationFrontend.dll"]