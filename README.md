
# Easy Cash Asp.Net Core 6.0 Identity Projesi-Devam

Bu proje, ASP.NET Core Identity öğrenmek ve bu teknolojiyi kullanarak bankacılık senaryolarını uygulamak için tasarlanmıştır. Proje, ASP.NET Core 6.0 sürümünü kullanmaktadır ve MSSQL veritabanını kullanarak n-tier mimari ve repository design patterniyle geliştirilmiştir.

![App-Screenshots](https://github.com/gamzemeryemkaya/EasyCashIdentityProject/blob/master/easyg%C3%B6rseller/profil.png?raw=true)

## Proje Açıklaması

Proje, aşağıdaki ana başlıkları içermektedir:

- **Identity**: ASP.NET Core Identity kütüphanesi, kullanıcı kimlik doğrulaması, kayıt ve giriş işlemleri için kullanılmıştır.

- **Veritabanı**: MSSQL veritabanı, müşteri hesapları, para transferleri (havale/eft) ve müşteri hareketleri gibi bankacılık işlemlerini desteklemek için kullanılmıştır.

- **Kullanıcı Yönetimi**: Proje, üyelik işlemleri üzerine odaklanmaktadır. Kullanıcıların kaydolması, giriş yapması ve mail doğrulama gibi işlemleri içerir.

- **Para Transferi**: Müşteriler arasında para transferi (havale ve eft) işlemleri gerçekleştirilebilir. Özellikle LINQ alt sorguları kullanılarak bu işlemler desteklenir.

- **Döviz Bilgileri**: Döviz kuru bilgileri Rapid API ile çekilir ve döviz dönüşümleri sağlanır.







## Ekran Görüntüleri

### Confirm Sayfası

![Uygulama Ekran Görüntüsü](https://github.com/gamzemeryemkaya/EasyCashIdentityProject/blob/master/easyg%C3%B6rseller/confirmsayfa.png?raw=true)
### Para Transferi 

![Uygulama Ekran Görüntüsü](https://github.com/gamzemeryemkaya/EasyCashIdentityProject/blob/master/easyg%C3%B6rseller/para%20g%C3%B6nderme.png?raw=true)
