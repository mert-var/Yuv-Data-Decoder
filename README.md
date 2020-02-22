# YUV (RAW DATA) ÇÖZÜCÜ

YUV renk formatı, RGB renk uzayına alternatif olarak önerilmiş bir renk uzayıdır. Y bileşeni ışıklılık bileşenine, U (Cb) ve V (Cr) ise renk bileşenlerine karşılık gelmektedir. Y ve U-V bileşenleri, ışıklılık ve renk kanalları olarak da bilinmektedir. RGB renk uzayında bir piksel ortalama 24 bit ile ifade edilirken, YUV renk uzayında piksel başına ortalama 24 bitten daha az sayıda bit kullanılabilmektedir. Bunun nedeni, U ve V kanallarında Y kanalına göre daha az sayıda piksel içermesidir. Literatürde farklı örnekleme türleriyle hazırlanmış YUV formatları bulunmaktadır. Örneğin;

    • 4:4:4 formatı: Renk kanallarında(Chroma kanallarında, Cr-Cb) herhangi bir alt-örnekleme yapılmamıştır.
    
    • 4:2:2 formatı: Renk kanallarında, ½ oranında yatay alt-örnekleme yapıldığı, düşeyde ise herhangi bir 
    alt-örnekleme yapılmadığı duruma karşılık gelmektedir. 

    • 4:2:0 formatı: Renk kanallarında, ½ oranında yatay ve düşey alt-örnekleme yapıldığı durumdur.

RGB’den YUV’a dönüşüm işleminden sonra .yuv uzantılı dosyalarda N adet çerçeve bilgisi bulunmaktadır. Her bir çerçeve için sırasıyla Y,U ve V bileşenleri tutulmaktadır. Aşağıdaki şekilde, ışıklılık (luma) ve renk bileşenleri (chroma) için hangi örneklerin/piksellerin seçilip/seçilmediği bilgisi gösterilmektedir. 

![image2](https://user-images.githubusercontent.com/21347887/75091588-1386d600-5580-11ea-8a55-f8b486c2ab05.png)

### Proje İsterleri

    • Arayüz tasarımı: Tasarlanacak arayüz üzerinden dosya okuma, .bmp kaydetme, görüntü oynatma ve 
    ayarlar seçeneği olacaktır.

    • Dosya okuma: .yuv uzantılı dosyalar okunacak ve render/parse işlemine tabii tutulacaktır.

    • Ayarlar:  Hangi formatta okuma işlemi yapılacağı ve görüntülerin en/boy bilgisinin ayarlandığı 
    bölüm olacaktır.
    
    • .bmp kaydetme: Parse işlemi sonrası tüm görüntü çerçevelerinin sadece Y bileşenleri 
    numaralandırılarak kaydedilecektir.

    • Görüntü oynatma/gösterme: Parse işlemi sonrası sadece Y bileşenleri, tasarlanacak arayüz üzerinde 
    oynatılacaktır. Oynatma işlemi, çerçeve bazlı yapılacaktır.

#### Projede kullanılabilecek örnek .yuv uzantılı dosyalar:

   • 4:2:0 referans diziler: http://trace.eas.asu.edu/yuv/index.html

   • 4:2:2 referans diziler: http://samples.mplayerhq.hu/raw-video/squirrel-720x576-422P.yuv

   • 4:4:4 referans diziler: http://samples.mplayerhq.hu/raw-video/squirrel-720x576-444P.yuv
