using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sifre = "ab18";
            double bakiye = 250;
            Console.WriteLine("****************ÜÇÜNCÜ BİNYIL BANK***************");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("HOŞGEDİNİZ");
            Console.WriteLine("-----------------------------");
        DON:
            Console.WriteLine("Yapacağınız İşlemi Seçiniz\n1-Kartlı İşlem\n2-Kartsız İşlem");
            int birincisecim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------------------------------------");

            switch (birincisecim)
            {
                #region -------------- KARTLI İŞLEMLER-----------------
                case 1:   

                int hak = 3;    ///ŞİFRE KONTOL
                while (0 < hak)
                {

                    Console.WriteLine("şifreyi giriniz");
                    string sifre2 = Console.ReadLine();
                    if (sifre == sifre2)
                    {
                        Console.WriteLine("şifre doğru");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("tekrar deneyiniz");
                        hak--;
                        Console.WriteLine("------------------");
                    }
                    Console.WriteLine("Kalan hakkınız:" + hak);
                }
                if (hak == 0)
                {
                    Console.WriteLine("Kartınıza El Konulmuştur");
                }

            ANAMENU:           //ANAMENÜ
                Console.WriteLine("********************ANA MENÜ");
                Console.WriteLine("Lütfen Yapağınız İşlemi Seçiniz");
                Console.WriteLine("1-Para Çekmek\n2-Para Yatırmak\n3-Para Transferleri\n4-Eğitim Ödemeleri\n5-Ödemeler\n6-Bilgi Güncelleme");
                int anamenusecim = Convert.ToInt32(Console.ReadLine());
                #region Kartlı İşlem--Para Çekme
                if (anamenusecim == 1) // KARTLI İŞLEM-------PARA ÇEKME
                {
                CEKIMTEKRAR:
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("BAKİYE:"+bakiye+"TL");
                        Console.WriteLine("Çekeceğiniz miktarı giriniz");
                    int cekim = Convert.ToInt32(Console.ReadLine());

                    if (cekim > bakiye)
                    {
                        Console.WriteLine("Yetersiz bakiye");
                        Console.WriteLine("Çekilebilen max tutar:" + bakiye);
                        goto CEKIMTEKRAR;
                    }
                    else
                    {
                        bakiye = bakiye - cekim;
                        Console.WriteLine("kalan tutar:" + bakiye);

                    }
                    Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                    Console.WriteLine("ÇIKMAK İÇİN              0");
                    int c = Convert.ToInt32(Console.ReadLine());

                    if (c == 9)
                    {
                        goto ANAMENU;
                    }
                    else if (c == 0)
                    {
                        goto CIKIS;
                    }

                }
                #endregion
                #region Kartlı İşlemler---Para Yatırma
                else if (anamenusecim == 2)  //KARTLI İŞLEM-------PARA YATIRMA

                {

                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("1-Kredi Kartına Para Yatırma\n2-Hesaba Para Yatırma");
                    int kredihesap = Convert.ToInt32(Console.ReadLine());

                    if (kredihesap == 1)   //PARA YATIRMA-----KREDİ KARTINA

                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("12 haneli kart numaranızı giriniz");
                        string kartno = Console.ReadLine();
                            if (kartno.Length <= 12)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");



                            KREDIDENHESABA:
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("Bakiyeniz:" + bakiye);
                                Console.WriteLine("Ne kadar yatırmak istersiniz");
                                int hesaptankarta = Convert.ToInt32(Console.ReadLine());
                                if (hesaptankarta > bakiye)
                                {
                                    Console.WriteLine("Bakiyenizden fazla tutar girdiniz");
                                    Console.WriteLine("Bakiyeniz:" + bakiye);
                                    goto KREDIDENHESABA;
                                }
                                else
                                {
                                    bakiye = bakiye - hesaptankarta;
                                    Console.WriteLine("Bakiyeniz:" + bakiye);
                                }
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }





                            }
                    }
                    else if (kredihesap == 2)
                    {
                        Console.WriteLine("Yatıracağınız tutarı giriniz");
                        int yatantutar = Convert.ToInt32(Console.ReadLine());

                        bakiye = bakiye + yatantutar;

                        Console.WriteLine("BAKİYE:" + bakiye);

                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                        Console.WriteLine("ÇIKMAK İÇİN              0");
                        int c = Convert.ToInt32(Console.ReadLine());

                        if (c == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (c == 0)
                        {
                            goto CIKIS;
                        }
                    } //HESABA PARA YATIRMA



                }
                #endregion
                #region Kartlı İşlemler EFT-HAVALE
                else if (anamenusecim == 3)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("1-Başka Hesaba EFT\n2-Başka Hesaba Havale");
                    int havale = Convert.ToInt32(Console.ReadLine());
                    if (havale == 1)  // KARTLI EFT
                    {
                    EFT:
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("EFT yapmak istediğiniz hesabın iban numarasını yazınız");
                        string iban = Console.ReadLine();
                        if (iban.StartsWith("TR") && iban.Length == 14)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("EFT yapılacak tutar giriniz");
                            int efttutar = Convert.ToInt32(Console.ReadLine());
                            if (efttutar < bakiye)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                bakiye = bakiye - efttutar;
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }

                            }
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("Yetersiz bakiye");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Hatalı girdiniz");
                            goto EFT;
                        }

                    }
                    else if (havale == 2) //KARTLI HAVALE
                    {
                    HVL:
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Havale için Hesap Numarası Giriniz");
                        string hesabahavale = Console.ReadLine();

                        if (hesabahavale.Length == 12)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Tutar Giriniz");
                            int havaletutar = Convert.ToInt32(Console.ReadLine());

                            if (havaletutar < bakiye)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                bakiye = bakiye - havaletutar;
                                Console.WriteLine("Yetersiz bakiye");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }

                            }
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("Yetersiz Bakiye");
                                Console.WriteLine("Yetersiz bakiye");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Hataı Giriş Yaptınız");
                            goto HVL;
                        }
                    }
                }
                #endregion
                #region KArtlı İşlemler---Eğitim Ödemeleri
                else if (anamenusecim == 4)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("Eğitim Ödemeleri Sayfası Arızalıdır");
                    Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                    Console.WriteLine("ÇIKMAK İÇİN              0");
                    int c = Convert.ToInt32(Console.ReadLine());

                    if (c == 9)
                    {
                        goto ANAMENU;
                    }
                    else if (c == 0)
                    {
                        goto CIKIS;
                    }
                }
                #endregion
                #region Kartlı işlemler---Ödemeler
                else if (anamenusecim == 5)
                {
                    Random r = new Random();
                    double kartlıfaturabeli = r.Next(30, 200);
                    Console.WriteLine("-------------------------------------------------------------------------------------");

                    Console.WriteLine("1-Elektrik Faturası\n2-Telefon Faturası\n3-İnternet Faturası\n4-Su Faturası\n5-OGS Ödemeleri ");
                    int faturamenu = Convert.ToInt32(Console.ReadLine());

                    if (faturamenu == 1)
                    {

                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Fatura Tutarı :" + kartlıfaturabeli + "TL");

                        if (kartlıfaturabeli < bakiye)
                        {
                            bakiye = bakiye - kartlıfaturabeli;
                            Thread.Sleep(3000);
                            Console.WriteLine("Ödeme işlemi gerçekleşmiştir");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }

                    }

                    else if (faturamenu == 2)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Fatura Tutarı :" + kartlıfaturabeli + "TL");

                        if (kartlıfaturabeli < bakiye)
                        {
                            bakiye = bakiye - kartlıfaturabeli;
                            Thread.Sleep(3000);
                            Console.WriteLine("Ödeme işlemi gerçekleşmiştir");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }

                        }
                    }
                    else if (faturamenu == 3)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Fatura Tutarı :" + kartlıfaturabeli + "TL");

                        if (kartlıfaturabeli < bakiye)
                        {
                            bakiye = bakiye - kartlıfaturabeli;
                            Thread.Sleep(3000);
                            Console.WriteLine("Ödeme işlemi gerçekleşmiştir");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }

                        }
                    }
                    else if (faturamenu == 4)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Fatura Tutarı :" + kartlıfaturabeli + "TL");

                        if (kartlıfaturabeli < bakiye)
                        {
                            bakiye = bakiye - kartlıfaturabeli;
                            Thread.Sleep(3000);
                            Console.WriteLine("Ödeme işlemi gerçekleşmiştir");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }

                        }
                    }
                    else if (faturamenu == 5)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Fatura Tutarı :" + kartlıfaturabeli + "TL");

                        if (kartlıfaturabeli < bakiye)
                        {
                            bakiye = bakiye - kartlıfaturabeli;
                            Thread.Sleep(3000);
                            Console.WriteLine("Ödeme işlemi gerçekleşmiştir");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yetersiz Bakiye");
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }

                        }
                    }
                    else if (anamenusecim == 6)
                    {
                        Console.WriteLine("1-Şifre Değiştirmek");
                        int bilgi = Convert.ToInt32(Console.ReadLine());

                        if (bilgi == 1)
                        {
                            Console.WriteLine("Yeni Şifre Giriniz");
                            string sifre2 = Console.ReadLine();
                            sifre = sifre2;
                            Console.WriteLine("Şifre Başarıyla Değiştirildi");
                        }
                        Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                        Console.WriteLine("ÇIKMAK İÇİN              0");
                        int c = Convert.ToInt32(Console.ReadLine());

                        if (c == 9)
                        {
                            goto ANAMENU;
                        }
                        else if (c == 0)
                        {
                            goto CIKIS;
                        }
                    }
                }
                #endregion
                #region KARTLI İŞLEMLER---BİLGİ GÜNCELLEME
                else if (anamenusecim == 6)

                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("Yeni Bir Şifre Giriniz");
                    string yenisifre = Console.ReadLine();
                    sifre = yenisifre;
                    Console.WriteLine("Şifre Değiştirme İşlemi Başarı ile Gerçekleşmiştir");
                    Thread.Sleep(3000);

                    Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                    Console.WriteLine("ÇIKMAK İÇİN              0");
                    int c = Convert.ToInt32(Console.ReadLine());

                    if (c == 9)
                    {
                        goto ANAMENU;
                    }
                    else if (c == 0)
                    {
                        goto CIKIS;
                    }

                }
                    #endregion

                    break;
                #endregion
                #region -------------- KARTSIZ İŞLEMLER-----------------
                case 2:
                
                  ANAMENU2:
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    Console.WriteLine("********************ANA MENÜ");
                    Console.WriteLine("Lütfen Yapağınız İşlemi Seçiniz");
                    Console.WriteLine("1-CepBank Para Çekmek\n2-Para Yatırmak\n3-Kredi Kartı Ödemeleri\n4-Eğitim Ödemeleri\n5-Ödemeler");
                    int kartsızanamenusecim = Convert.ToInt32(Console.ReadLine());
                   
                    if (kartsızanamenusecim == 1)
                    {
                        int hak1 = 2;
                    TCTEL:
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Lütfen 11 Haneli TC Kimlik Numaranızı Tuşlayınız");
                        string tc = Console.ReadLine();
                        Console.WriteLine("Telefon Numaranızı Tuşlayınız");
                        string telno = Console.ReadLine();

                        if (tc.Length == 11 && telno.Length == 11)
                        {
                            Console.WriteLine("1000 TL Çekim İşleminiz Gerçekleşmiştir");
                        }
                        else
                        {
                            while (0 < hak1)
                            {
                                Console.WriteLine("Hatalı Giriş Yaptınız");
                                hak1--;
                                Console.WriteLine("Kalan hak:" + (hak1 + 1));
                                goto TCTEL;
                            }

                            if (hak1 == 0)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("3 Kez Üst Üste Hatalı Giriş Yaptınız.Lütfen 1 saat sonra tekrar deneyiniz veya");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                        }
                    }
                   
                    
                    else if (kartsızanamenusecim == 2)

                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("1-Nakit Ödeme\n2-Hesaptan Ödeme\nVEYA\nANA MENÜYE DÖNMEK İÇİN   9\nÇIKMAK İÇİN              0 ");
                        int kartsızparayatırma = Convert.ToInt32(Console.ReadLine());
                        if (kartsızparayatırma == 1)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Kredi Kartı Numaranızı Giriniz");
                            string kredikart = Console.ReadLine();
                            Console.WriteLine("TC Kimlik No Giriniz");
                            string tc = Console.ReadLine();
                            if (kredikart.Length <= 12 && tc.Length == 11)
                            {

                                Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Para Yatırma Bölmesinin İçine Koyunuz");
                                System.Threading.Thread.Sleep(4000);
                                Console.WriteLine("Yatırma İşleminiz gerçekleşmiştir");
                                System.Threading.Thread.Sleep(2000);
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                        }
                        else if (kartsızparayatırma == 2)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Kredi Kartı Numaranızı Giriniz");
                            string kredikart = Console.ReadLine();
                            Console.WriteLine("11 Hanei Hesap Numarası Giriniz");
                            string hesapno = Console.ReadLine();
                            if (kredikart.Length <= 12 && hesapno.Length == 11)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("BAKİYENİZ:" + bakiye + "₺");
                                Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Yazınız");
                                int hesaptanyatirim = Convert.ToInt32(Console.ReadLine());
                                System.Threading.Thread.Sleep(4000);
                                Console.WriteLine("Yatırma İşleminiz gerçekleşmiştir");
                                System.Threading.Thread.Sleep(2000);
                                bakiye = bakiye - hesaptanyatirim;
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("HATALI GİRİŞ YAPTINIZ");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }


                        }
                        else if (kartsızparayatırma == 9)
                        {
                            goto ANAMENU2;
                        }
                        else if (kartsızparayatırma == 0)
                        {
                            goto CIKIS;
                        }
                    }
                    
                   
                    else if (kartsızanamenusecim == 3) //KARSIZ------ EFT VEYA HAVALE
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("1-Başka Hesaba EFT\n2-Başka Hesaba Havale");
                        int transfer = Convert.ToInt32(Console.ReadLine());
                        if (transfer == 1) // EFT İÇİN
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("EFT Yapmak İstediğiniz Hesabın İban Numarasını Giriniz");
                            string iban = Console.ReadLine();
                            if (iban.StartsWith("TR") && iban.Length == 14)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Para Yatırma Bölmesinin İçine Koyunuz");
                                System.Threading.Thread.Sleep(4000);
                                Console.WriteLine("Yatırma İşleminiz gerçekleşmiştir");
                                System.Threading.Thread.Sleep(2000);
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("HATALI GİRİŞ YAPTINIZ");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                        }
                        else if (transfer == 2) // HAVALE İÇİN
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Havale Yapmak İstediğiniz Hesabın 11 Hanei Hesap  Numarasını Giriniz");
                            string hesapno = Console.ReadLine();
                            if (hesapno.Length == 11)
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Para Yatırma Bölmesinin İçine Koyunuz");
                                System.Threading.Thread.Sleep(4000);
                                Console.WriteLine("Yatırma İşleminiz gerçekleşmiştir");
                                System.Threading.Thread.Sleep(2000);
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                            else
                            {
                                Console.WriteLine("-------------------------------------------------------------------------------------");
                                Console.WriteLine("HATALI GİRİŞ YAPTINIZ");
                                Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                                Console.WriteLine("ÇIKMAK İÇİN              0");
                                int c = Convert.ToInt32(Console.ReadLine());

                                if (c == 9)
                                {
                                    goto ANAMENU2;
                                }
                                else if (c == 0)
                                {
                                    goto CIKIS;
                                }
                            }
                        }

                    }
                    
                    
                    else if (kartsızanamenusecim == 4) // KARTSIZ SEÇİM-*---EĞİTİM ÖDEMELERİ
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("Eğitim Sayfası Geçici Olarak Hizmete Kapatımıştır");
                        Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                        Console.WriteLine("ÇIKMAK İÇİN              0");
                        int c = Convert.ToInt32(Console.ReadLine());

                        if (c == 9)
                        {
                            goto ANAMENU2;
                        }
                        else if (c == 0)
                        {
                            goto CIKIS;
                        }

                    }
                    
                    
                    else if (kartsızanamenusecim == 5)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        double paraustu;
                        Random r = new Random();
                        double faturabeli = r.Next(30, 200);
                        Console.WriteLine("1-Elektrik Faturası\n2-Telefon Faturası\n3-İnternet Faturası\n4-Su Faturası\n5-OGS Ödemeleri ");
                        int faturamenu = Convert.ToInt32(Console.ReadLine());
                        
                        if (faturamenu == 1)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Fatura Bedeli:" + faturabeli + "TL");
                            Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz ve Para Yatırma Bölmesinin İçine Koyunuz");
                            int nakitpara = Convert.ToInt32(Console.ReadLine());
                            Thread.Sleep(3000);
                            paraustu = nakitpara - faturabeli;
                            Console.WriteLine("Ödeme İşlemi Gerçekleşmiştir.\nPara Üstünüz:" + paraustu + "TL");
                            Thread.Sleep(3000);
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU2;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }



                        }
                       
                        
                        else if (faturamenu == 2)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Fatura Bedeli:" + faturabeli + "TL");
                            Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz ve Para Yatırma Bölmesinin İçine Koyunuz");
                            int nakitpara = Convert.ToInt32(Console.ReadLine());
                            Thread.Sleep(3000);
                            paraustu = nakitpara - faturabeli;
                            Console.WriteLine("Ödeme İşlemi Gerçekleşmiştir.\nPara Üstünüz:" + paraustu + "TL");
                            Thread.Sleep(3000);
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU2;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                       
                       
                        else if (faturamenu == 3)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Fatura Bedeli:" + faturabeli + "TL");
                            Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz ve Para Yatırma Bölmesinin İçine Koyunuz");
                            int nakitpara = Convert.ToInt32(Console.ReadLine());
                            Thread.Sleep(3000);
                            paraustu = nakitpara - faturabeli;
                            Console.WriteLine("Ödeme İşlemi Gerçekleşmiştir.\nPara Üstünüz:" + paraustu + "TL");
                            Thread.Sleep(3000);
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU2;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        
                        
                        else if (faturamenu == 4)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Fatura Bedeli:" + faturabeli + "TL");
                            Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz ve Para Yatırma Bölmesinin İçine Koyunuz");
                            int nakitpara = Convert.ToInt32(Console.ReadLine());
                            Thread.Sleep(3000);
                            paraustu = nakitpara - faturabeli;
                            Console.WriteLine("Ödeme İşlemi Gerçekleşmiştir.\nPara Üstünüz:" + paraustu + "TL");
                            Thread.Sleep(3000);
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU2;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                        
                        
                        else if (faturamenu == 5)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Fatura Bedeli:" + faturabeli + "TL");
                            Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz ve Para Yatırma Bölmesinin İçine Koyunuz");
                            int nakitpara = Convert.ToInt32(Console.ReadLine());
                            Thread.Sleep(3000);
                            paraustu = nakitpara - faturabeli;
                            Console.WriteLine("Ödeme İşlemi Gerçekleşmiştir.\nPara Üstünüz:" + paraustu + "TL");
                            Thread.Sleep(3000);
                            Console.WriteLine("ANA MENÜYE DÖNMEK İÇİN   9");
                            Console.WriteLine("ÇIKMAK İÇİN              0");
                            int c = Convert.ToInt32(Console.ReadLine());

                            if (c == 9)
                            {
                                goto ANAMENU2;
                            }
                            else if (c == 0)
                            {
                                goto CIKIS;
                            }
                        }
                       
                    }
                   

                
                    break;
                #endregion

                default:
                
                    Console.WriteLine("Hatalı Giriş Yaptınız!");
                    goto DON;
                    break;   

            

            }
        CIKIS:
            Console.WriteLine("HOŞÇAKALIN");
            Console.ReadLine();
        }
    }
}