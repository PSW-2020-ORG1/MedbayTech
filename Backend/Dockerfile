FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster-slim

RUN groupadd -g 999 appuser && \
    useradd -r -u 999 -g appuser appuser
User appuser


WORKDIR /app

COPY ./Backend/Backend.csproj .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Backend.dll"]
