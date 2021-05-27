using FluentValidation;
using HairdressingStudio.Models;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Validation
{
    public class ClientValidator : AbstractValidator<ClientsDTO>
    {
        public ClientValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.PhoneNumber).NotEmpty().InclusiveBetween(111111111, 999999999);
            RuleFor(c => c.Email).EmailAddress().WithMessage("Adres email jest niepoprawny");
        }
    }
}
