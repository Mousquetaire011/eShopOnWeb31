powershell
docker --version

docker pull mcr.microsoft.com/dotnet/core/aspnet:3.1
docker pull mcr.microsoft.com/dotnet/core/sdk:3.1
docker pull microsoft/mssql-server-linux

Appsettings.json:
 "CatalogConnection": "Data Source=127.0.0.1;User ID=sa;Password=Pass@word1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Microsoft.eShopOnWeb.CatalogDb;",
 "IdentityConnection": "Data Source=127.0.0.1;User ID=sa;Password=Pass@word1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Microsoft.eShopOnWeb.Identity;",

Dockfile content for SQL Linux : 
	FROM microsoft/mssql-server-linux
	ENV SA_PASSWORD=Pass@word1
	ENV ACCEPT_EULA=Y

docker build -t sqlserverlinuximage .
docker run -d -p 1433:1433 --name dockersqllinux sqlserverlinuximage


dotnet restore
dotnet tool restore
dotnet ef database update -c catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
dotnet ef database update -c appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
