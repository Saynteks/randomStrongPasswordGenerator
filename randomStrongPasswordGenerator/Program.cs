using System;
using System.Linq;
using MySql.Data.MySqlClient;
namespace randomStrongPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection baglanti1;
            string connectionString = "server=localhost;database=passwordGenerator;uid=root;pwd=12345";
            baglanti1 = new MySqlConnection(connectionString);
            Console.Write("Ne Yapmak İstersin?:\n1)Şifrelerime Bak\n2)Şifre Oluştur\n");
            int amac = int.Parse(Console.ReadLine());
            if (amac==1)
            {
                Console.Write("İsminizi Girin:");
                string isim2 = Console.ReadLine();
                baglanti1.Open();
                MySqlCommand sorgu = new MySqlCommand("select * from bilgiler where isim=@isim", baglanti1);
                sorgu.Parameters.AddWithValue("@isim", isim2);
                MySqlDataReader oku;
                oku = sorgu.ExecuteReader();
                 
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine(oku[0] + ":\n" + oku[1] + "\n" + oku[2]);
                    while (oku.Read())
                    {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("İsim: " + oku["isim"].ToString());
                        Console.WriteLine("Platform: " + oku["platform"].ToString());
                        Console.WriteLine("Şifre: " + oku["sifre"].ToString());
                    Console.WriteLine("----------------------------------------");
                    
                    
                }


                Console.ReadKey();

            }
            else { 
            Console.Write("İsminizi Girin: ");
            string isim = Console.ReadLine();
            Console.Write("Şifre Hangi Platform İçin Oluşturuldu?: ");
            string platform = Console.ReadLine();
            Console.Write("Şifrenin uzunluğunu girin: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Ne Tür Şifre Oluşturmak İstersin?\n1)Büyük Harfler\n2)Küçük Harfler\n3)Sayılar\n4)Semboller\n5)Hepsi\n ");
            int durum=int.Parse(Console.ReadLine());
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            string specialChars = "!@#$%^&*()_+";
            if (durum==1)
            {
                Random random1 = new Random();
                string password1 = new string(Enumerable.Repeat(uppercaseChars, length)
                  .Select(s => s[random1.Next(s.Length)]).ToArray());

                Console.WriteLine("Oluşturulan şifre: " + password1);

                    string sorgu = "insert into bilgiler (isim,platform,sifre) Values (@isim,@platform,@sifre)";
                    MySqlCommand kayitEkle = new MySqlCommand(sorgu, baglanti1);
                    kayitEkle.Parameters.AddWithValue("@isim", isim);
                    kayitEkle.Parameters.AddWithValue("@platform", platform);
                    kayitEkle.Parameters.AddWithValue("@sifre", password1);
                    baglanti1.Open();
                    kayitEkle.ExecuteNonQuery();
                    baglanti1.Close();
                }
            else if (durum==2)
            {
                Random random2 = new Random();
                string password2 = new string(Enumerable.Repeat(lowercaseChars, length)
                  .Select(s => s[random2.Next(s.Length)]).ToArray());

                Console.WriteLine("Oluşturulan şifre: " + password2);
                    string sorgu = "insert into bilgiler (isim,platform,sifre) Values (@isim,@platform,@sifre)";
                    MySqlCommand kayitEkle = new MySqlCommand(sorgu, baglanti1);
                    kayitEkle.Parameters.AddWithValue("@isim", isim);
                    kayitEkle.Parameters.AddWithValue("@platform", platform);
                    kayitEkle.Parameters.AddWithValue("@sifre", password2);
                    baglanti1.Open();
                    kayitEkle.ExecuteNonQuery();
                    baglanti1.Close();
                }
            else if (durum==3)
            {
                Random random3 = new Random();
                string password3 = new string(Enumerable.Repeat(digits, length)
                  .Select(s => s[random3.Next(s.Length)]).ToArray());

                Console.WriteLine("Oluşturulan şifre: " + password3);
                    string sorgu = "insert into bilgiler (isim,platform,sifre) Values (@isim,@platform,@sifre)";
                    MySqlCommand kayitEkle = new MySqlCommand(sorgu, baglanti1);
                    kayitEkle.Parameters.AddWithValue("@isim", isim);
                    kayitEkle.Parameters.AddWithValue("@platform", platform);
                    kayitEkle.Parameters.AddWithValue("@sifre", password3);
                    baglanti1.Open();
                    kayitEkle.ExecuteNonQuery();
                    baglanti1.Close();
                }
            else if (durum==4)
            {
                Random random4 = new Random();
                string password4 = new string(Enumerable.Repeat(specialChars, length)
                  .Select(s => s[random4.Next(s.Length)]).ToArray());

                Console.WriteLine("Oluşturulan şifre: " + password4);
                    string sorgu = "insert into bilgiler (isim,platform,sifre) Values (@isim,@platform,@sifre)";
                    MySqlCommand kayitEkle = new MySqlCommand(sorgu, baglanti1);
                    kayitEkle.Parameters.AddWithValue("@isim", isim);
                    kayitEkle.Parameters.AddWithValue("@platform", platform);
                    kayitEkle.Parameters.AddWithValue("@sifre", password4);
                    baglanti1.Open();
                    kayitEkle.ExecuteNonQuery();
                    baglanti1.Close();
                }
            else
            {
                string chars = uppercaseChars + lowercaseChars + digits + specialChars;

                Random random = new Random();
                string password = new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                Console.WriteLine("Oluşturulan şifre: " + password);
                    string sorgu = "insert into bilgiler (isim,platform,sifre) Values (@isim,@platform,@sifre)";
                    MySqlCommand kayitEkle = new MySqlCommand(sorgu, baglanti1);
                    kayitEkle.Parameters.AddWithValue("@isim", isim);
                    kayitEkle.Parameters.AddWithValue("@platform", platform);
                    kayitEkle.Parameters.AddWithValue("@sifre", password);
                    baglanti1.Open();
                    kayitEkle.ExecuteNonQuery();
                    baglanti1.Close();
                    Console.Write("Uygulamayı kapatmak için bir tuşa basın...");
                    Console.ReadKey();
                }
                
            }
            
        }
    }
}
