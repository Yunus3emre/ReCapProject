using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(100);
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.DailyPrice).GreaterThan(200).When(c => c.BrandId == 2);
            RuleFor(c => c.ModelYear).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("2");
        }
    }
}
