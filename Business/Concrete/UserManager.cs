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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(true, Messages.AddedUser);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(true, Messages.DeletedUser);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new DataResult<List<User>>(_userDal.GetAll(), true, Messages.Success);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccesDataResult<User>(_userDal.Get(c => c.Id == id));
        }

        public IResult Update(User user)
        {
            _userDal.Add(user);
            return new Result(true, Messages.Success);
        }
    }
}
