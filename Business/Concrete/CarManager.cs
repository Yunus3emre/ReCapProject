using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal ıcardar)
        {
            _carDal = ıcardar;
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }
        public void Update(Car car)
        {
            _carDal.Add(car);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }        

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
