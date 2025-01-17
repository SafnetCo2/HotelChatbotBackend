# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file(s) and restore dependencies
COPY ["HotelChatbotBackend.csproj", "./"]
RUN dotnet restore "HotelChatbotBackend.csproj"

# Copy the rest of the application and build
COPY . .
WORKDIR /src
RUN dotnet build "HotelChatbotBackend.csproj" -c Release -o /app/build

# Publish the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "HotelChatbotBackend.dll"]
