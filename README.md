# Brick Breaker

Unity 6 ve C# ile sıfırdan yazdığım 2D tuğla kırma oyunu.

<!-- Buraya bir oynanış GIF'i ve 1-2 ekran görüntüsü ekle:
![Oynanış](docs/gameplay.gif)
-->

## Topun fiziği neden kendi kodum

Top için Unity'nin hazır zıplama materyalini (Physics Material 2D) kullanmadım. Bunun yerine
topu `FixedUpdate` içinde kendim bir yön vektörü boyunca hareket ettiriyorum; bir şeye çarptığında
da yönü çarpışma normaline göre `Vector3.Reflect` ile yansıtıyorum.

Sebebi: hazır fizik materyali zamanla enerji kaybedebilir veya kazanabilir. Tuğla kırma oyununda
bu ölümcüldür — top ya yavaşlayıp oyunu sıkıcı hale getirir ya da hızlanıp kontrolden çıkar.
Kendi yansımamı yazınca **topun hızı sabit kalıyor ve çarpma açısı tahmin edilebilir oluyor**,
ki oyuncunun nişan alabilmesi için gereken tam olarak bu.

## Yapı

Kod bilinçli olarak iki katmana ayrıldı:

```
Assets/_project/Scripts/
├── Elements/     Ball, Brick, Player, PlayerInput, Level
└── Managers/     GameDirector, LevelManager, BrickManager
```

**Elements** sahnedeki nesneler — her biri tek bir işi bilir. Tuğla kendi canını bilir, topun
nereden geldiğini bilmez. **Managers** oyunun durumunu tutar. `GameDirector` oyunu yönetir,
`LevelManager` bölüm ve top yaşam döngüsünü, `Level` ise o bölümdeki tuğlaları takip eder.

Tuğlalar birbirini veya yöneticileri doğrudan çağırmıyor: tuğla yok olduğunda kendi `Level`'ına
haber veriyor, `Level` listesi boşalınca `LevelManager`'a haber veriyor. Sorumluluk yukarı doğru
akıyor.

## Tasarım detayları

**Tuğlanın rengi canını söylüyor.** Tuğlanın rengi kalan canına göre hesaplanıyor
(`1 - can × colorStep`). Ayrı bir can göstergesine gerek yok — oyuncu tuğlaya bakınca kaç vuruş
daha gerektiğini görüyor. Vuruş anında renk yeni değere DOTween ile geçiş yapıyor.

**Vuruş geri bildirimi.** Tuğlaya her vuruşta ölçek zıplaması, konum sarsıntısı ve renk geçişi
aynı anda çalışıyor (`DOScale` + `DOPunchPosition` + `DOColor`). Yeni animasyon başlamadan önce
`DOKill` ile öncekiler temizleniyor, böylece hızlı vuruşlarda efektler üst üste binmiyor.

**Bölümler prefab.** Yeni bölüm eklemek kod yazmak değil, yeni bir prefab hazırlamak. Bölüm
numarası liste uzunluğuna göre modulo ile sarmalanıyor, yani bölümler bitince başa dönüyor.

**Çözünürlükten bağımsız kontrol.** Raket fareyle sürüklenerek hareket ediyor. Fare konumu ham
piksel olarak değil, ekran genişliğine göre normalize edilerek oyun koordinatına çevriliyor —
böylece kontrol her ekran boyutunda aynı hissettiriyor.

## Kontroller

| Tuş | İşlev |
|---|---|
| Fareyi sürükle | Raketi hareket ettir |
| R | Bölümü yeniden başlat |
| E / Q | Sonraki / önceki bölüm (geliştirme amaçlı) |

## Kullanılan teknolojiler

Unity 6 (6000.3.15f1) · C# · 2D fizik · URP 2D · DOTween

## Henüz yapılmadı

- Bölüm tamamlandığında bir kazanma akışı yok; `LevelManager.LevelCleard()` şu an boş
- `BrickManager` henüz iskelet halinde
- Skor, arayüz ve ses yok
