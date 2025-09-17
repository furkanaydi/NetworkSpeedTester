# Network Speed Tester

Bu depo, **PingAtlas** fikrinin kücük bir masaübüstü versiyonunu içerir. Uygulama C# dilinde, .NET 6 tabanlı bir Windows Forms arayüzü ile geliştirilmiştir ve belirttiğiniz bir ana makineye ICMP ping göndererek ağ gecikmesini (round‑trip time) ölçer. Sonuçlar anlık olarak kullanıcı arayüzünde görüntülenir.

## Özellikler

- Basit ve hafif arayüz – hedef sunucu/alan adı girip testi başlatabilirsiniz.
- Beş ping isteği göndererek ortalama yanıt sürestini hesaplar.
- Ağ hatalarını yakalar ve kullanıcıya geri bildirir.
- C# ve .NET 6 ile geliştirildi; kod okunabilir olması için yorum satırları eklenmiştir.

## Kurulum

Bu projeyi derleyip çalıştırmak için .NET 6 SDK veya daha yeni bir sürümünün yüklü olması gerekir. Henüz yüklü değilse [Microsoft’un .NET sitesi](https://dotnet.microsoft.com/download/dotnet/6.0) üzerinden indirebilirsiniz.

### Depoyu Klonla

```bash
git clone https://github.com/<kullanici-adiniz>/NetworkSpeedTester.git
cd NetworkSpeedTester
```

### Derleme

Windows Forms projeleri yalnızca Windows işletim sistemi ücüzerinde derlenebilir. Uygulamayı derlemek için aşağıdaki komutu çalıştırın:

```bash
dotnet build
```

Bu komut, `bin/` klasörü altında çalıştırılabilir `.exe` dosyasını oluşturacaktır.

### Çalıştırma

Derleme tamamlandıktan sonra uygulamayı ya Visual Studio içerisinden ya da komut satırından çalıştırabilirsiniz:

```bash
dotnet run
```

veya Windows Dosya Gezgini üzerinden `bin/Debug/net6.0-windows/NetworkSpeedTester.exe` dosyasını çift tıklayarak çalıştırabilirsiniz.

## Nasıl Çalışır?

Uygulama arayüzünde varsayılan olarak `google.com` hedefi gelmektedir. Farklı bir hedef denemek için metin kutusuna alan adını veya IP adresini yazıp **Test** butonuna tıklamanız yeterlidir. Program belirtilen hedefe art arda beş adet ping isteği gönderecek ve her birinin yanıt sürestini listeleyecek, ardından ortalama süreyi hesaplayacaktır.

## Katkıda Bulunma

Proje fikir aşamasındadır ve geliştirilmeye açıktır. Pull request ve issue’lar ile katkılarınızı bekliyoruz.

---

Bu proje temiz kod ve yorum satırları ile geliştirilmiştir. Kodla ilgili sorularınız için lütfen issue açmaktan çekinmeyin.
