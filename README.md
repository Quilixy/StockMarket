Database Conf.
--------------
api/appsettings.json içerisindeki DefaultConnection değerini bu şekilde yapınız:
```
"Data Source={PC_ID}\\SQLEXPRESS;Initial Catalog={DB_NAME};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
```

Migrations dosyasını içindekilerle birlikte siliniz.

Ardından komut terminalinde aşağıdaki kodları çalıştırınız:
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef migrations add Init 
```
```
dotnet ef migrations add Identity
```
```
dotnet ef migrations add SeedRole 
```

Kodlarını çalıştırdıktan sonra 
```
dotnet ef database update
```
kodunu da çalıştırınız.

Uygulamanın başlatılması
------------------------
* api --> http://localhost:5284/ Url'sinde çalışır.
* frontend/BlazorApp --> http://localhost:5248/ Url'sinde çalışır.

>[!NOTE]
>Programın tam çalışabilmesi için belirtilen dizinlerdeki klasörlere girerek (Örn: ```cd api``` ya da ```cd .\frontend\BlazorApp\```) ```dotnet watch run``` komutunu her iki uygulama için de ayrı ayrı çalıştırılması gerekir.