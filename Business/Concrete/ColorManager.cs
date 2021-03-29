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
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(true, Messages.CarAdded);
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.ColorListed);
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.ColorUpdated);
        }
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, Messages.ColorDeleted);
        }
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
    }
}
