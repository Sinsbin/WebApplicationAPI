# 第一階段：編譯階段 (Build Stage)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. 複製專案檔並還原 NuGet 套件 (利用快取機制，這步沒變動就不會重跑)
COPY ["WebApplication2.csproj", "./"]
RUN dotnet restore "WebApplication2.csproj"

# 2. 複製其餘所有原始碼並進行編譯
COPY . .
RUN dotnet build "WebApplication2.csproj" -c Release -o /app/build

# 3. 發布專案
FROM build AS publish
RUN dotnet publish "WebApplication2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 第二階段：執行階段 (Final/Runtime Stage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# 從發布階段將編譯好的檔案複製過來
COPY --from=publish /app/publish .

# 設定環境變數與啟動指令
# 注意：.NET 8 預設監聽連接埠已改為 8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebApplication2.dll"]