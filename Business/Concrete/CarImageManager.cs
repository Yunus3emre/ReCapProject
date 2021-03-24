using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new Result(true, Messages.AddedCarImage);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new Result(true, Messages.DeletedCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.Success);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new Result(true, Messages.Success);
        }
    }
}
