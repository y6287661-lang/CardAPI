# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# المرحلة الأساسية لتشغيل التطبيق
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# مرحلة البناء
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CardAPI/CardAPI.csproj", "CardAPI/"]
RUN dotnet restore "CardAPI/CardAPI.csproj"
COPY . .
WORKDIR "/src/CardAPI"
RUN dotnet build "CardAPI.csproj" -c Release -o /app/build

# مرحلة النشر
FROM build AS publish
RUN dotnet publish "CardAPI.csproj" -c Release -o /app/publish

# المرحلة النهائية لتشغيل التطبيق
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardAPI.dll"]