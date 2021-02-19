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
    public class RentalManager: IRentalService
    {
        IRentalDal _rentaldal;
        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }

        public IResult Add(Rental rental)
        {
            _rentaldal.Add(rental);
            return new Result(true, Messages.AddedRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new Result(true,Messages.DeletedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentaldal.GetAll(), true, Messages.Success);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccesDataResult<Rental>(_rentaldal.Get(c => c.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Add(rental);
            return new Result(true, Messages.Success);
        }
    }
}
