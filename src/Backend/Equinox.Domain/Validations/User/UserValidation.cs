﻿using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Domain.Commands.User;
using FluentValidation;

namespace Equinox.Domain.Validations.User
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }


        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUsername()
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Please ensure you have entered the Username")
                .Length(2, 50).WithMessage("The Username must have between 2 and 50 characters");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please ensure you have entered the password")
                .Equal(c => c.ConfirmPassword).WithMessage("Password and Confirm password must be equal")
                .MinimumLength(8).WithMessage("Password minimun length must be 8 characters");
        }
    }
}