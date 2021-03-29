using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal cardar, IBrandService brandService)
        {
            _carDal = cardar;
            _brandService = brandService;
        }
        //[SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                 CheckIfCarDescriptionAlreadyExist(car.Description),
                 CheckIfCarCountOfBrandCorrect(car.BrandId),
                 CheckIfBrandLimitExceded());
            if (result != null)
            {
                return result;     
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Add(car);
            return new Result(true, Messages.UpdatedCar);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.Success);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Silme işlemi Başarılı");
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), true, Messages.Success);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min), Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccesDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarDescriptionAlreadyExist(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarDescriptionAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CheckIfBrandLimitExceded);
            }
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), true, Messages.Success);
        }
    }
}
