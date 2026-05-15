# StudyHub API

StudyHub API, öğrencilerin çalışma süreçlerini takip edebilmesi için geliştirilen bir ASP.NET Core Web API projesidir.

Kullanıcılar sisteme kayıt olabilir, giriş yapabilir, görevlerini yönetebilir, çalışma oturumlarını kaydedebilir ve çalışma istatistiklerini görüntüleyebilir.


---

## Proje Amacı

Bu proje ile aşağıdaki backend kavramlarını öğrenmek ve uygulamak hedeflenmiştir:

- JWT Authentication
- Entity Framework Core
- DTO kullanımı
- Repository Pattern
- Service Layer
- Dependency Injection
- Validation
- Entity ilişkileri
- İstatistik hesaplamaları
- Yetkilendirme (Authorization)

---

## Özellikler

### Kimlik Doğrulama (Authentication)

- Kullanıcı kayıt işlemi
- Kullanıcı giriş işlemi
- JWT Token oluşturma
- Şifre hashleme

### Todo Yönetimi

- Görev ekleme
- Görev güncelleme
- Görev silme
- Görevi tamamlandı olarak işaretleme
- Kullanıcı sadece kendi görevlerini görüntüleyebilir

### Çalışma Oturumları

- Çalışma oturumu ekleme
- Çalışma oturumu silme
- Ders adı, süre ve tarih bilgisi kaydetme

Örnek:

```json
{
   "subject":"ASP.NET Core",
   "durationMinutes":90,
   "studyDate":"2026-05-13"
}
```

### İstatistikler

- Toplam çalışma süresi
- Tamamlanan görev sayısı
- Toplam çalışma oturumu sayısı
- Haftalık çalışma özeti

---

## Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- JWT Authentication
- Repository Pattern
- Service Layer
- DTO Pattern
- Dependency Injection
- Validation

---

## Proje Mimarisi

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Entity Framework Core
    ↓
SQLite Database
```

Business logic işlemleri Service katmanında, veritabanı işlemleri Repository katmanında tutulmuştur.

---



## Veritabanı Modelleri

### User

Kullanıcı bilgilerini saklar.

Alanlar:

```text
Id
Name
Email
PasswordHash
```

### Todo

```text
Id
Title
IsCompleted
UserId
```

### StudySession

```text
Id
Subject
DurationMinutes
StudyDate
UserId
```

İlişkiler:

```text
User → Todos
User → StudySessions
```

---

## API Endpointleri

### Authentication

```http
POST /api/auth/register
POST /api/auth/login
```

### Todo

```http
GET /api/todos
GET /api/todos/{id}

POST /api/todos

PUT /api/todos/{id}

DELETE /api/todos/{id}
```

### Study Session

```http
GET /api/study-sessions

POST /api/study-sessions

DELETE /api/study-sessions/{id}
```

### İstatistik

```http
GET /api/stats/summary

GET /api/stats/weekly
```

---

## Kurulum

Projeyi klonla:

```bash
git clone https://github.com/kullaniciadi/StudyHub_API.git
```

Proje klasörüne gir:

```bash
cd StudyHub_API
```

Paketleri yükle:

```bash
dotnet restore
```

Migration oluştur:

```bash
dotnet ef migrations add InitialCreate
```

Veritabanını oluştur:

```bash
dotnet ef database update
```

Projeyi çalıştır:

```bash
dotnet run
```

---

## Yetkilendirme

Korunan endpointlere erişmek için JWT Token gereklidir.

Örnek:

```http
Authorization: Bearer token_buraya
```

Public endpointler:

```text
Register
Login
```

---
