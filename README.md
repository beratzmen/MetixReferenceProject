# MetixReferenceProject
Fikstür oluşturan ve skor girişi yapılan bir proje


Özet: Lig motoru ile herhangi bir spor türünde uygulanabilecek 
bir lig fikstürü oluşturulacak. 
Otomatik oluşan fikstüre göre maç sonuçları kullanıcı tarafından girilecek. 
Girişler sonucunda oluşan puan durumu görüntülenebilecektir.

Detay:
•	Program takım ekleme ekranı ile açılır.
•	Kullanıcı takım isimlerini ekler, çıkarır veya düzenler. 
•	Takım sayısı 2 veya üstü bir çift sayı olduğunda Fikstür Oluştur butonu aktif olur.
•	Fikstür oluştur butonuna basıldığında arka planda fikstür oluşturulur ve yeni ekrana geçilir. 
•	Yeni ekranda ilk hafta maçları sıralanır. Haftanın maçlarıyla birlikte puan durumu da görüntülenir (ilk hafta tüm puanlar 0).
•	Sağ-sol butonlarıyla önceki (son hafta) ve sonraki (2. hafta) haftaya geçiş yapılabilir. 
•	Maç skorları bu ekrandan girilebilir.
•	Maç skorları girildikçe puan durumu otomatik güncellenir.
•	Kazanan takım +1 puan, kaybeden takım -1 puan alır, beraberlik 0 puandır.
•	Program kapatılıp tekrar açıldığında kalınan yerden devam edilir. Veriler kaybolmaz. 
•	Hiç maç skoru girilmemişse fikstür oluştur butonuna tekrar basılabilir. 
•	Herhangi bir haftaya maç skoru girişi varsa fikstür oluştur butonu ekrandan kaybolur.
•	Fikstür oluştur butonuna tekrar basıldığında aynı ilk hafta ekranı, farklı eşleşmelerle gelmelidir.
•	Program açık olduğu sürece browser refresh edilmez. (bkz. Single Page Application)

Kullanılan teknolojiler: 
•	BackEnd  .NET - RestApi . 
•	FrontEnd  Angular 
•	Önyüzde Single Page Application yapısı uygulanmıştır
•	Veritabanı olarak MS SQL Server
