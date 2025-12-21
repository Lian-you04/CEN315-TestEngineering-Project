# Gym Booking App - Test Engineering Project 🏋️‍♂️

Bu proje, bir spor salonu rezervasyon sisteminin modern test teknikleri, CI/CD süreçleri ve Docker entegrasyonu ile nasıl güvence altına alındığını gösteren kapsamlı bir test mühendisliği çalışmasıdır.

## 🚀 Öne Çıkan Teknik Başarılar

### 🛡️ Test Kalitesi & Mutation Testing
Testlerimizin sadece kodun üzerinden geçmediğini, aynı zamanda mantıksal hataları yakalama kapasitesini **Stryker.NET** ile kanıtladık.

- **Service Layer Mutation Score: %84.21** 
- **Overall Code Coverage: %94.1** 
- *Detaylı mutasyon raporu fotoğrafına `GymBookingApp.Api/TestingDocuments/MutationTestResult(services).png` yolundan ulaşılabilir.*

### ⚡ Performans ve Ölçeklenebilirlik
Uygulamanın yük altındaki dayanıklılığı ve tepki süresi ölçülmüştür:
- **Yük Testi:** 100 eşzamanlı istekte toplam **2231 ms** yanıt süresi.
- **Hız:** Ortalama istek başına **22.3 ms** yanıt süresi ile yüksek performans.

### 🔗 CI/CD & DevOps
- **GitHub Actions:** Her "push" ve "Pull Request" işleminde testler otomatik olarak koşar.
- **Docker Ready:** Proje tamamen konteynerize edilmiştir. `docker-compose up` komutu ile hem API hem de test ortamı saniyeler içinde ayağa kalkar.

## 🧪 Uygulanan Test Teknikleri
1. **Behavior Driven Development (BDD):** SpecFlow kullanılarak kullanıcı hikayeleri test senaryolarına dönüştürüldü.
2. **Black-Box Testing:** Decision Table ve Pairwise metotları ile minimum eforla maksimum hata yakalama oranı sağlandı.
3. **Integration Testing:** Katmanlar arası iletişim, izole bir Docker ortamında doğrulandı.
4. **Mutation Testing:** Test suitinin "mutant" hataları öldürme yeteneği test edildi.
