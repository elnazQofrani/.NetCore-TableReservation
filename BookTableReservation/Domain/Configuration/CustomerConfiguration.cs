using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Configuration
{
    internal class CustomerConfiguration : AbstractValidator<Customer>, IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.LastName).HasMaxLength(30);
            builder.Property(p => p.PhoneNumber).IsRequired();

            // for regex pattern used AbstractValidator
            RuleFor(p => p.PhoneNumber)
           .NotEmpty()
           .WithMessage("Phone number is required")
           .Matches(@"^\+?\d{10,15}$") 
           .WithMessage("Invalid phone number format.");

            RuleFor(p => p.Email)
           .NotEmpty()
           .WithMessage("Email is required.")
           .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
           .WithMessage("Invalid email format.");

        }
    }
}
