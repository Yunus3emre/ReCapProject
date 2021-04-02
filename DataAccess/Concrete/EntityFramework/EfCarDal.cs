using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join color in context.Colors on c.ColorId equals color.ColorId
                             join img in context.CarImages on c.ImgId equals img.Id
                             select new CarDetailDto { 
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = color.Name,
                                 Description = c.Description,
                                 ImgPath=img.Path,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 Status = !context.Rentals.Any(r => r.CarId == c.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }
    }
}
