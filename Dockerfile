# Use the .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . ./

# Restore dependencies
RUN dotnet restore

# Publish the project to create the runtime-ready output
RUN dotnet publish --configuration Release --output /app/publish

# Use the .NET Runtime image as the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build environment
COPY --from=build-env /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "docker-intro-gh.dll"]
