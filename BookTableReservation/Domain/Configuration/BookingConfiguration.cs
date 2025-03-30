using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {

            builder.HasKey(b=>b.Id);
            builder.Property(b=>b.SeatId).IsRequired();
            builder.Property(b => b.CustomerId).IsRequired();
            builder.Property(b => b.BookingDateTime).IsRequired();
            builder.Property(b => b.StartTime).IsRequired();
            builder.Property(b => b.Status).IsRequired();

        }
    }
}
