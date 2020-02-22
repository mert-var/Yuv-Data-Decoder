# YUV (RAW DATA) ÇÖZÜCÜ

YUV renk formatı, RGB renk uzayına alternatif olarak önerilmiş bir renk uzayıdır.  Y bileşeni ışıklılık bileşenine, U (Cb) ve V (Cr) ise renk bileşenlerine karşılık gelmektedir. Y ve U-V bileşenleri, ışıklılık ve renk kanalları olarak da bilinmektedir.  RGB renk uzayında bir piksel ortalama 24 bit ile ifade edilirken, YUV renk uzayında piksel başına ortalama 24 bitten daha az sayıda bit kullanılabilmektedir. Bunun nedeni, U ve V kanallarında Y kanalına göre daha az sayıda piksel içermesidir. Literatürde farklı örnekleme türleriyle hazırlanmış YUV formatları bulunmaktadır. Örneğin;

    •	4:4:4 formatı: Renk kanallarında (Chroma kanallarında, Cr-Cb) herhangi bir alt örnekleme yapılmamıştır.

    •	4:2:2 formatı: Renk kanallarında, ½ oranında yatay alt-örnekleme yapıldığı, düşeyde ise herhangi bir alt-örnekleme        
    yapılmadığı duruma karşılık gelmektedir. 

    •	4:2:0 formatı:  Renk kanallarında, ½ oranında yatay alt-örnekleme ve düşey alt-örnekleme yapıldığı durumdur.


RGB’den YUV’a dönüşüm işleminden sonra .yuv uzantılı dosyalarda N adet çerçeve bilgisi bulunmaktadır. Her bir çerçeve için sırasıyla Y,U ve V bileşenleri tutulmaktadır. Şekil-1’de, ışıklılık (luma) ve renk bileşenleri (chroma) için hangi örneklerin/piksellerin seçilip/seçilmediği bilgisi gösterilmektedir. 


