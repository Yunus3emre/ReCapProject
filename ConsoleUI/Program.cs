using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            //oldConsol(carManager);
            CarManager efcarManager = new CarManager(new EfCarDal());
            //efcarmanagertest(efcarManager);
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //BrandTest(brandManager); 
            //JoinTest(efcarManager);
            var result = efcarManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in efcarManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.Description + " / " + car.BranName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void JoinTest(CarManager efcarManager)
        {
            foreach (var car in efcarManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Description + " / " + car.BranName);
            }
        }

        private static void BrandTest(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void efcarmanagertest(CarManager efcarManager)
        {
            foreach (var car in efcarManager.GetAll().Data)
            {
                Console.WriteLine(car.ModelYear);
            }

            foreach (var car in efcarManager.GetAllByBrandId(1).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void oldConsol(CarManager carManager)
        {
            int loop = 1;
            //int selectedCarid;
            while (loop == 1)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçip enter tuşuna basınız.");
                Console.WriteLine("Araçları Listelemek için         1");
                Console.WriteLine("Markaya Göre Filtrelemek için    2");
                Console.WriteLine("Yeni araç eklemek için           3");
                Console.WriteLine("Araç Bilgilerini Güncellemek     4");

                int stoper = Convert.ToInt32(Console.ReadLine());
                //Car selectedCar;
                switch (stoper)
                {
                    case 1:
                        foreach (var car in carManager.GetAll().Data)
                        {
                            Console.WriteLine(car);
                            Console.WriteLine("Arac Id: " + car.Id + " Arac Marka ID: " + car.BrandId + " Arac RenkId: " + car.ColorId + " Arac Günlük Ücret: " + car.DailyPrice + " Aracın Model Yılı: " + car.ModelYear + " Açıklama: " + car.Description);
                            Console.WriteLine("---");
                        }
                        break;

                    //case 2:
                    //    Console.WriteLine("Marka Filtreli Arama");
                    //    Console.WriteLine("Filtrelemek istediğiniz Marka(BMW = 1 , Audi = 2, Mercedes = 3)");
                    //    int filtre = Convert.ToInt32(Console.ReadLine());
                    //    foreach (var car in carManager.GetAllByBrand(filtre))
                    //    {
                    //        Console.WriteLine("Arac Id:             " + car.Id);
                    //        Console.WriteLine("Arac Marka ID:       " + car.BrandId);
                    //        Console.WriteLine("Açıklama:            " + car.Description);
                    //        Console.WriteLine("Arac RenkId:         " + car.ColorId);
                    //        Console.WriteLine("Arac Günlük Ücret:   " + car.DailyPrice);
                    //        Console.WriteLine("Aracın Model Yılı:   " + car.ModelYear);
                    //        Console.WriteLine("---");

                    //    }
                    //    break;

                    //case 3:
                    //    Console.WriteLine("--Yeni Araç ekleme Ekranı--");

                    //    Console.WriteLine("Arac Id:             ");
                    //    int createdtempcarid = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Arac Marka ID:       ");
                    //    int createdtempcarbrandid = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Açıklama:            ");
                    //    string createdtempcardescription = Console.ReadLine();
                    //    Console.WriteLine("Arac RenkId:         ");
                    //    int createdtempcarcolorid = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Arac Günlük Ücret:   ");
                    //    double createdtempcardailyprice = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Aracın Model Yılı:   ");
                    //    string createdtempcarmodelyear = Console.ReadLine();
                    //    Console.WriteLine("---");

                    //    carManager.Add(new Car { Id = createdtempcarid, BrandId = createdtempcarbrandid, ColorId = createdtempcarcolorid, ModelYear = createdtempcarmodelyear, DailyPrice = createdtempcardailyprice, Description = createdtempcardescription });
                    //    Console.WriteLine("Aracınız Eklendi");
                    //    break;

                    //case 4:
                    //    Console.WriteLine("Araç Bilgilerini Güncelleme Ekranı.");
                    //    Console.WriteLine("Güncellenecek aracın id");
                    //    selectedCarid = Convert.ToInt32(Console.ReadLine());
                    //    selectedCar = carManager.GetById(selectedCarid);
                    //    Console.WriteLine("Arac Marka ID:       (" + selectedCar.BrandId + ")");
                    //    selectedCar.BrandId = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Açıklama:            (" + selectedCar.Description + ")");
                    //    selectedCar.Description = Console.ReadLine();
                    //    Console.WriteLine("Arac RenkId:         (" + selectedCar.ColorId + ")");
                    //    selectedCar.ColorId = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Arac Günlük Ücret:   (" + selectedCar.DailyPrice + ")");
                    //    selectedCar.DailyPrice = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Aracın Model Yılı:   (" + selectedCar.ModelYear + ")");
                    //    selectedCar.ModelYear = Console.ReadLine();
                    //    Console.WriteLine("---");

                    //    carManager.Update(selectedCar);
                    //    Console.WriteLine("Bilgiler Başarı ile Güncellendi. ");
                    //    break;

                    //case 5:
                    //    Console.WriteLine("Silinecek aracın id");
                    //    selectedCarid = Convert.ToInt32(Console.ReadLine());
                    //    selectedCar = carManager.GetById(selectedCarid);
                    //    carManager.Delete(selectedCar);
                    //    break;
                    //default:
                    //    Console.WriteLine("Hatalı Giriş yaptınız!!");
                    //    break;
                }
                Console.WriteLine("Başka bir işlem yapmak istiyor musunuz?");
                Console.WriteLine("Evet = 1 , Hayır (Çıkış) = 0");
                loop = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
