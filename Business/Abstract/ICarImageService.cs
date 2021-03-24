﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImage);
        IDataResult<CarImage> GetById(int id);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
