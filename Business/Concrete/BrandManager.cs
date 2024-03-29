﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            //business codes
            _brandDal.Add(brand);
            return new Result(true, Messages.CarAdded);
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, "Güncelleme"+Messages.Success);
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, "Silme işlemi Başarılı");
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true,"Markalar Listelendi");
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b=>b.BrandId==brandId));            
        }
    }
}
