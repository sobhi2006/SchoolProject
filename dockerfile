FROM mcr.microsoft.com/dotnet/sdk:9.0 As build
WORKDIR /app

# Copy project files for restore
COPY ["src/SchoolProject.Api/SchoolProject.Api.csproj", "src/SchoolProject.Api/"]
COPY ["src/SchoolProject.Core/SchoolProject.Core.csproj", "src/SchoolProject.Core/"]
COPY ["src/SchoolProject.Service/SchoolProject.Service.csproj", "src/SchoolProject.Service/"]
COPY ["src/SchoolProject.Domain/SchoolProject.Domain.csproj", "src/SchoolProject.Domain/"]
COPY ["src/SchoolProject.Infrastructure/SchoolProject.Infrastructure.csproj", "src/SchoolProject.Infrastructure/"]

RUN dotnet restore "src/SchoolProject.Api/SchoolProject.Api.csproj"
RUN dotnet restore "src/SchoolProject.Core/SchoolProject.Core.csproj"
RUN dotnet restore "src/SchoolProject.Service/SchoolProject.Service.csproj"
RUN dotnet restore "src/SchoolProject.Domain/SchoolProject.Domain.csproj"
RUN dotnet restore "src/SchoolProject.Infrastructure/SchoolProject.Infrastructure.csproj"

# Copy all source code
COPY . .


# Build and publish
RUN dotnet publish -o out

# ----- Final Stage -----
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "SchoolProject.Api.dll"]