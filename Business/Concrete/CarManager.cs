using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }
        public IResult Update(Car car)
        {
            _carDal.Add(car);
            return new Result(true, Messages.Success);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true,Messages.Success);            
        }        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Silme işlemi Başarılı");
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), true,Messages.Success);            
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min),Messages.Success);
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == id));
            
        }
    }
}
