using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _IcarDal;

        public CarManager(ICarDal ıcardar)
        {
            _IcarDal = ıcardar;
        }
        public void Add(Car car)
        {
            _IcarDal.Add(car);
        }
        public void Update(Car car)
        {
            _IcarDal.Add(car);
        }
        public List<Car> GetAll()
        {
            return _IcarDal.GetAll();
        }
        public List<Car> GetAllByBrand(int BrandId)
        {
             return _IcarDal.GetAllByBrand(BrandId);
        }
        public Car GetById(int Id)
        {
            return _IcarDal.GetById(Id);
        }

        public void Delete(Car car)
        {
            _IcarDal.Delete(car);
        }
    }
}
