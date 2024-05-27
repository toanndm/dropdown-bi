# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY DropdownBI/*.csproj ./DropdownBI/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/DropdownBI
RUN dotnet publish -c Release -o out

# Stage 2: Serve
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/DropdownBI/out ./
ENTRYPOINT ["dotnet", "DropdownBI.dll"]