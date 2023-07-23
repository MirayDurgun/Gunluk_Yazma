using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Gunluk_Yazma
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Ad("Miray");
			Sifre("17072023");
			static void Ad(string ad)
			{
				Console.WriteLine($"{ad} günlüğe hoşgeldin, bizde seni bekliyorduk");
				Console.WriteLine("Menüden seçimini yapmayı unutma\n");
				Thread.Sleep(1000);
			}
			static void Menu()
			{
				Console.WriteLine("1. Yeni Günlük Yaz");
				Console.WriteLine("2. Günlük Oku");
				Console.WriteLine("Lütfen seçmek istediğin menünün numarasını yaz");
				Console.WriteLine("Örnek günlük yazmak için '1'");
				string menuOku = Console.ReadLine();
				Console.Clear();

				if (menuOku == "1")
				{
					Console.WriteLine("Yeni günlük yazma işlemi seçtiniz.");
					GunlukYaz();
				}
				else if (menuOku == "2")
				{
					Console.WriteLine("Günlük okuma işlemi seçtiniz.");
					Console.Write("Okumak istediğiniz günlüğün başlığını seçiniz : \n\n");
					#region emre hoca
					List<string> gunlukler = Directory.GetFiles("C:\\odev").ToList<string>();
					int cnt = 1;
					foreach (string s in gunlukler)
					{
						Console.WriteLine(cnt + " - " + s);
						cnt++;
					}


					int siraNumarasi = int.Parse(Console.ReadLine());
					Console.Clear();
					string dosyaAdi = gunlukler[siraNumarasi - 1];
					GunlukDosyaOkuma(dosyaAdi);
					string oku = File.ReadAllText(dosyaAdi); //videodan izledim dosyanın içindekini yazdırıyor
					Console.WriteLine(oku);
					#endregion
				}
				else
				{
					Console.WriteLine("Geçersiz seçim yaptınız.");
				}
			}
			static void GunlukYaz()
			{
				Console.Clear();
				Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
				string tarih = DateTime.Now.ToString("dd-MM-yyyy");
				string saat = DateTime.Now.ToString("t");
				Console.WriteLine(tarih + "\n");
				Console.Write("Günlük Konusu : ");
				string konuYaz = Console.ReadLine();
				Console.WriteLine("\nGünlük İçeriği: ");
				string icerikYaz = Console.ReadLine();
				Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
				string metin = $"{tarih}\n{saat}\n{konuYaz}\n{icerikYaz}";
				GunlukDosyaYazdirma($"c:\\odev\\{konuYaz}.txt", metin); //metin belgesinde bütün halde yazsın diye
																		//normalde 2 parametre alıyormuş fazlasını bilmiyorum
				Console.WriteLine("Günlük kaydedildi");
				System.Threading.Thread.Sleep(1000);
				//console ekranında 1 saniye bekletir
			}
			static void GunlukDosyaYazdirma(string path, string deger)
			{
				File.AppendAllText(path, deger);
			}
			static void GunlukDosyaOkuma(string path)
			{
				File.ReadAllText(path);
			}
			static void Sifre(string sifre)
			{
				Console.WriteLine("Lütfen şifrenizi giriniz");
				sifre = Console.ReadLine();
				Console.Clear();
				if (sifre == "17072023")
				{
					Menu();
				}
				else
				{
					Console.WriteLine("Yanlış şifre, yeniden deneyiniz");
					Sifre(sifre);
				}
			}
		}
	}
}