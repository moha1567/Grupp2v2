# Use the .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . ./

# Restore dependencies
RUN dotnet restore

# Build the project
RUN dotnet build --configuration Debug --output /app/build

# Use the .NET SDK image as the runtime environment
FROM mcr.microsoft.com/dotnet/sdk:9.0

# Set the working directory in the container
WORKDIR /app

# Copy the build output from the build environment
COPY --from=build-env /app/build .

# Specify the entry point for the application
CMD ["dotnet", "docker-intro-gh.dll"]