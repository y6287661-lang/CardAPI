# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# المرحلة الأولى - البناء
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

# نسخ ملف المشروع واستعادة الحزم
COPY ["CardAPI/CardAPI.csproj", "./"]
RUN dotnet restore "CardAPI.csproj"

# نسخ باقي ملفات المشروع وبناؤه
COPY CardAPI/. ./
RUN dotnet publish "CardAPI.csproj" -c Release -o /out

# المرحلة الثانية - التشغيل
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["dotnet", "CardAPI.dll"]