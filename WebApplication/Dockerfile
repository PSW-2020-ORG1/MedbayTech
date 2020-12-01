FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 

WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApplication.dll"]