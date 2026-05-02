# Product Catalog System (Məhsul Kataloqu Sistemi)

Bu layihə ASP.NET Core MVC texnologiyası istifadə edilərək hazırlanmış, məhsulların idarə edilməsini həyata keçirən veb tətbiqdir. Layihədə əsas diqqət mürəkkəb vizual dizayna deyil, təmiz backend arxitekturasının qurulmasına, məlumatların təhlükəsiz yoxlanılmasına (Data Validation) və fayl əsaslı məlumat anbarının (JSON) idarə edilməsinə yönəldilmişdir.

## 🛠️ İstifadə olunan texnologiyalar
* **Backend:** C#, ASP.NET Core MVC
* **Məlumatların Saxlanması:** JSON (File-based storage)
* **Frontend:** Razor Views, HTML/CSS

## 📌 Əsas Xüsusiyyətlər və Arxitektura

**1. MVC Arxitekturası:**
* Tətbiq Model-View-Controller (MVC) standartlarına tam uyğun şəkildə qurulub. Controller və Action-lar vasitəsilə biznes məntiqi və istifadəçi interfeysi (UI) bir-birindən izolyasiya edilib.

**2. Model Binding və Validasiya (Data Integrity):**
* **Model Binding:** İstifadəçi tərəfindən form vasitəsilə daxil edilən məlumatların arxa planda avtomatik olaraq C# modellərinə xətasız ötürülməsi.
* **Server-Side Validation:** Sistemə daxil edilən məlumatların bütövlüyünü qorumaq üçün qəti qaydaların tətbiqi (Məhsul adının boş olmaması, qiymətin 0-dan böyük olması, mütləq kateqoriya seçimi). Şərtlər ödənmədikdə məlumatın yaddaşda saxlanmasının qarşısının alınması və istifadəçiyə dinamik xəta mesajlarının göstərilməsi.

**3. Məhsulların İdarəedilməsi (CRUD Əməliyyatları):**
* Baza daxilindəki bütün məhsulların (Ad, Qiymət, Kateqoriya) siyahı şəklində ekrana çıxarılması.
* Dropdown (açılan siyahı) vasitəsilə kateqoriya seçimi edərək sistemə yeni məhsulların əlavə edilməsi.
* Mövcud məhsullar üzərində məlumatların yenilənməsi (Update) və silinməsi (Delete).

**4. JSON Data Storage:**
* Layihənin daha yüngül və portativ olması üçün bütün məlumatların oxunması və yazılması birbaşa JSON faylı üzərindən həyata keçirilir.

<img width="1726" height="574" alt="image" src="https://github.com/user-attachments/assets/3585ad93-542b-4b17-a713-81a190612121" />

<img width="1110" height="799" alt="image" src="https://github.com/user-attachments/assets/312c8522-8edf-44d4-abd4-2e099757957d" />
