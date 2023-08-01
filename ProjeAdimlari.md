### Proje Oluşturma Adımları

1. dotnet new webapi -n WebApi // WebApi projesi oluşturma
2. dotnet new sln -n BookStoreSln // BookStoreSln çözümü oluşturma
3. dotnet sln add WebApi // WebApi projesini BookStoreSln çözümüne ekleme
4. launch.json oluştur. (Visual Studio Code için)
5. CRUD işlemleri için BookController oluştur.
6. BookController.cs içerisindeki metotlar için Book.cs oluştur.
7. CRUD kodlarını yaz.
8. Swagger için dotnet watch run // WebApi projesini çalıştırma

9. nuget.org üzerinden EntityFrameworkCore ve EntityFrameworkCore.InMemory paketlerini .NET CLI bölümündeki dotnet add package komutu ile yükle.
