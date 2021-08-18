FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["M220N_mogo_cource.csproj", "./"]
RUN dotnet restore "M220N_mogo_cource.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "M220N_mogo_cource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "M220N_mogo_cource.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "M220N_mogo_cource.dll"]
