using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Cars;
        List<Brand> _Brands;
        List<Color> _Colors;
        public InMemoryCarDal()
        {
            _Cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=150,Description="2010 model BMW Dizel.",ModelYear="2010" },
                new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=250,Description="2010 model BMW Otomatik vites.",ModelYear="2010" },
                new Car{Id=3,BrandId=2,ColorId=1,DailyPrice=350,Description="2010 model Audi Manuel vites benzinli.",ModelYear="2010" },
                new Car{Id=4,BrandId=2,ColorId=2,DailyPrice=100,Description="2010 model Audi Dizel",ModelYear="2010" },
                new Car{Id=5,BrandId=3,ColorId=2,DailyPrice=200,Description="2010 model Mercedes",ModelYear="2010" }
            };
            _Brands = new List<Brand>
            {
                new Brand{BrandId=1,Name="Beyaz"},
                new Brand{BrandId=2,Name="Siyah"},
                new Brand{BrandId=3,Name="Mercedes"}
            };
            _Colors = new List<Color>
            {
                new Color{ColorId=1,Name="Beyaz"},
                new Color{ColorId=2,Name="Siyah"}
            };
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _Cars.SingleOrDefault(c => c.Id == car.Id);

            _Cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _Cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public Car GetById(int Id)
        {
            return _Cars.SingleOrDefault(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _Cars.SingleOrDefault(c=>c.Id==car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
