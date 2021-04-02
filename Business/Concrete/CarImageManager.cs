using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageExceed(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.Path = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.AddedImage);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new Result(true, Messages.DeletedCarImage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(ı => ı.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.Success);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetByImageId(int id)
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(ı => ı.Id == id));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(ı => ı.CarId == id));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.Path = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).Path, formFile);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfCarImageExceed(int id)
        {
            var result = _carImageDal.GetAll(ı => ı.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageExceed);
            }
            return new SuccessResult();
        }
    }
}
