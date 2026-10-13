[![C#](https://img.shields.io/badge/C%23-62.2%25-239120?logo=csharp&logoColor=white&style=flat-square)](https://learn.microsoft.com/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Backend-512BD4?logo=dotnet&logoColor=white&style=flat-square)](https://learn.microsoft.com/aspnet/core/)
[![HTML5](https://img.shields.io/badge/HTML5-26.8%25-E34F26?logo=html5&logoColor=white&style=flat-square)](https://developer.mozilla.org/docs/Web/HTML)
[![CSS3](https://img.shields.io/badge/CSS3-11.0%25-1572B6?logo=css3&logoColor=white&style=flat-square)](https://developer.mozilla.org/docs/Web/CSS)
[![xUnit](https://img.shields.io/badge/xUnit-Tests-9cf?logo=xunit&logoColor=black&style=flat-square)](https://xunit.net/)
[![Docker](https://img.shields.io/badge/Docker-container-blue?logo=docker&logoColor=white&style=flat-square)](https://www.docker.com/)

# 🚀 StockMarket — Yazılım Mühendisliği Vitrini

**StockMarket**, kişisel portföy takibi ve temel piyasa verilerini görselleştirmeye odaklı, C# ve ASP.NET Core tabanlı bir web uygulamasıdır. 

Bu repo ticari bir ürün olmaktan ziyade; **temiz mimari (Clean Architecture)**, tasarım desenleri (Design Patterns, SOLID), test güdümlü geliştirme (TDD) ve modüler sistem tasarımı gibi yazılım mühendisliği yetkinliklerini somut bir şekilde sergilemek amacıyla inşa edilmiş bir **"showcase" (vitrin)** projesidir.

---

## 🎯 İşe Alım Uzmanları & Teknik Liderler İçin Not

Bu projeyi incelerken, karmaşık iş kurallarını koda nasıl aktardığımı ve aşağıdaki mühendislik standartlarını nasıl uyguladığımı görebilirsiniz:

* **Katmanlı Mimari:** Clean Architecture ilkelerine sadık kalınarak API, Application, Domain ve Infrastructure katmanlarının kesin sınırlarla ayrılması.
* **Tasarım Desenleri:** MediatR kullanılarak **CQRS** (Command Query Responsibility Segregation) deseninin uygulanması; sorgu (query) ve komut (command) sorumluluklarının ayrıştırılması.
* **Veri Yönetimi:** **Repository Pattern** ve **Unit of Work** ile veri erişim katmanının soyutlanması, EF Core entegrasyonu.
* **Sistem Dayanıklılığı (Resiliency):** Dış servis entegrasyonlarında (piyasa verisi sağlayıcıları) *Retry* ve *Circuit-Breaker* politikalarının (Polly vb.) kullanılması.
* **Kod Kalitesi & Prensipler:** SOLID prensiplerine uygun, Dependency Injection (DI) tabanlı gevşek bağlı (loosely-coupled) tasarım. Anlamlı (semantic) commit mesajları ve detaylı PR açıklamaları.
* **API Tasarımı:** RESTful standartlar, API versiyonlama ve spesifik sorumluluklara sahip ince (thin) controller'lar.

---

## 🛠️ Kullanılan Teknolojiler

| Kategori | Teknoloji / Kütüphane | Rol & Notlar |
| :--- | :--- | :--- |
| **Backend** | C# / .NET (ASP.NET Core) | Clean Architecture, DI, async/await pratikleri |
| **Frontend** | HTML5, CSS3 | BEM sınıf yapısı, responsive düzen, erişilebilirlik (A11y) |
| **Veritabanı & ORM**| Entity Framework Core | Persistence, Repository + Unit of Work |
| **Mimari Araçlar**| MediatR | CQRS / Mediator pattern implementasyonu |
| **Altyapı** | Docker, Docker Compose | Yerel geliştirme ve CI için konteynerizasyon |

---

## 🏗️ Proje Mimarisi — Dosya ve Klasör Ağacı

Sorumlulukların ayrılığı ilkesi gereği proje aşağıdaki yapıya sahiptir:

```text
StockMarket/
├─ .github/
│  └─ workflows/                  # CI/CD Pipeline (Build)
├─ src/
│  ├─ StockMarket.Api/            # Presentation: Web API, DTO'lar, Middleware'ler, Swagger
│  ├─ StockMarket.Application/    # İş Kuralları: CQRS Handler'ları, Interfaceler, Validator'lar
│  ├─ StockMarket.Domain/         # Çekirdek: Entity'ler, Value Object'ler, Domain Exception'ları
│  └─ StockMarket.Infrastructure/ # Dış Dünya: EF Core DbContext, Dış API İstemcileri, Migrations
│
├─ docker-compose.yml
└─ README.md
```

---

## 📐 Kod Kalitesi & Mimari Örnekleri

**1. Repository Pattern Soyutlaması (Domain/Application Katmanı):**
```csharp
namespace StockMarket.Application.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock?> GetBySymbolAsync(string symbol, CancellationToken token = default);
        Task AddAsync(Stock entity, CancellationToken token = default);
        Task<IEnumerable<Stock>> QueryAsync(Expression<Func<Stock, bool>> predicate);
    }
}
```

**2. CQRS Handler Örneği (Application Katmanı):**
```csharp
public class GetPortfolioQueryHandler : IRequestHandler<GetPortfolioQuery, PortfolioDto>
{
    private readonly IPortfolioRepository _repo;
    private readonly IMapper _mapper;

    public GetPortfolioQueryHandler(IPortfolioRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PortfolioDto> Handle(GetPortfolioQuery request, CancellationToken cancellationToken)
    {
        var portfolio = await _repo.GetByUserIdAsync(request.UserId, cancellationToken);
        return _mapper.Map<PortfolioDto>(portfolio);
    }
}
```

---

## 🚀 Kurulum & Çalıştırma (Geliştirme Ortamı)

### Ön Gereksinimler
* .NET SDK 7+ (veya güncel sürüm)
* Docker Desktop (Opsiyonel)
* Git

### Seçenek 1: Manuel Kurulum (.NET CLI)

```bash
# 1. Repoyu klonlayın ve dizine gidin
git clone [https://github.com/Quilixy/StockMarket.git](https://github.com/Quilixy/StockMarket.git)
cd StockMarket

# 2. Veritabanı migrasyonlarını uygulayın
cd src/StockMarket.Infrastructure
dotnet ef database update --project ../StockMarket.Infrastructure --startup-project ../StockMarket.Api

# 3. API'yi çalıştırın
cd ../StockMarket.Api
dotnet restore
dotnet build
dotnet run
```

### Seçenek 2: Docker Compose İle (Önerilen)

```bash
# Tüm servisleri (Veritabanı + API) arka planda ayağa kaldır
docker-compose up --build -d

# Uygulama loglarını anlık olarak izle
docker-compose logs -f
```



## 📈 Performans & Sistem Notları

* **Veri Transferi:** Veri tabanından doğrudan Entity çekmek yerine, `Select` projeksiyonları ile doğrudan DTO'lara (Data Transfer Object) eşleme yapılarak aşırı veri yüklenmesi (over-fetching) önlenmiştir.
* **Harici API Çağrıları:** Piyasa verisi çekerken oluşabilecek ağ hatalarına karşı Timeout, Retry ve Exponential Backoff stratejileri entegre edilmiştir.

---

## 🔧 Gelecek Planları (To-Do)

- [ ] **Caching:** Yüksek okuma (read-heavy) oranına sahip piyasa verileri için Redis entegrasyonu.
- [ ] **CI/CD & Code Coverage:** GitHub Actions ile otomatik test, build, imaj yayınlama süreçlerinin kurulması ve `coverlet` + `codecov` ile test kapsama raporlarının alınması.
- [ ] **Güvenlik:** API Rate Limiting ve JWT + Refresh Token tabanlı yetkilendirme akışının eklenmesi.
- [ ] **Frontend Geliştirmeleri:** Zengin grafik kütüphaneleri (chart.js/D3) ile veri görselleştirme ve PWA (Progressive Web App) yeteneklerinin eklenmesi.
- [ ] **Deployment:** Canary veya Blue-Green deployment stratejilerinin test edilmesi.

---

## 🤝 Katkıda Bulunma

Bu repo temel olarak kişisel bir portföy sergisidir ancak kod incelemeleri (Code Review) ve katkılara açıktır:
1. Geliştirme yapmadan önce lütfen bir **Issue** açarak fikrinizi tartışın.
2. PR (Pull Request) gönderirken hangi tasarım kararlarını aldığınızı, alternatifleri neden elediğinizi ve uyguladığınız test stratejisini kısaca belirtin.

---

## 📄 Lisans & İletişim

* **Lisans:** Bu proje örnek amaçlı olup **MIT Lisansı** ile sunulmaktadır.
* **Geliştirici:** Yıldıray / Quilixy
* **GitHub:** [github.com/Quilixy](https://github.com/Quilixy)
* **LinkedIn:** [https://www.linkedin.com/in/yıldıray-dönmez-46b1a0243]
* **Email:** [yildiraydonmez.dev@gmail.com]
