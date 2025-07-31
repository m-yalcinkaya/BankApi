# 💼 Proje Hakkında

- Database olarak **MSSQL** kullanıldı.
- Tablolar **Code First** yaklaşımı ile oluşturuldu ve **Migration** işlemleri yapıldı.
- ORM olarak **Entity Framework Core** kullanıldı.
- **Pagination** ve isActive filtresi eklendi.

---

# 🚀 Deployment Hakkında

- Azure üzerinde **SQL Database** oluşturuldu.
- Azure üzerinde **Web App (API)** yayınlandı.
- **Otomatik migration** desteği eklendi (her yeni push sonrası yeniden deploy işlemi gerçekleşiyor).
- Veritabanı bilgileri (kullanıcı adı, parola vs.) **environment variable** olarak tanımlandı.

---

# 🔧 API Kullanımı (cURL Örnekleri)

## ✅ Tüm Bankaları Listele (Filtreli ve Sayfalı)

```bash
curl -X GET "https://bankapi-fffkhvfkfqg2cnck.germanywestcentral-01.azurewebsites.net/api/Bank?isActive=true&page=1&pageSize=10"
```

---

## ✅ 2. Belirli ID'ye Göre Banka Getir

```bash
curl -X GET "https://bankapi-fffkhvfkfqg2cnck.germanywestcentral-01.azurewebsites.net/api/Bank/1"
```

## ➕ Yeni Banka Ekle

```bash
curl -X POST "https://bankapi-fffkhvfkfqg2cnck.germanywestcentral-01.azurewebsites.net/api/Bank" \
-H "Content-Type: application/json" \
-d '{"name": "Ziraat Bankası", "isActive": true, "address": "Ankara"}'
```

---

## 🔄 Banka Güncelle

```bash
curl -X PUT "https://bankapi-fffkhvfkfqg2cnck.germanywestcentral-01.azurewebsites.net/api/Bank" \
-H "Content-Type: application/json" \
-d '{"id": 1, "name": "Ziraat Bankası A.Ş.", "isActive": true, "address": "İstanbul"}'

```

---

## ❌ Banka Sil

```bash
curl -X DELETE "https://bankapi-fffkhvfkfqg2cnck.germanywestcentral-01.azurewebsites.net/api/Bank?id=1"
```

