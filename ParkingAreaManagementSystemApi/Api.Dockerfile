# BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ./ParkingAreaManagementSystemApi/ ./
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

# RUNTIME STAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
RUN apt-get update && apt-get install -y wait-for-it && chmod +x /usr/bin/wait-for-it
COPY --from=build /publish .
EXPOSE 5000

ENTRYPOINT ["wait-for-it", "postgres_db:5432", "--", "dotnet", "Presentation.dll"]
