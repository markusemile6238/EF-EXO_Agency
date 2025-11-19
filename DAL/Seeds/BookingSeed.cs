using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    public class BookingSeed : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking() { Id=1,CustomerId=1,  BookingDate=new DateTime(2026,05,10) },
                new Booking() { Id=2,CustomerId=1,  BookingDate=new DateTime(2026,05,11) },
                new Booking() { Id=3,CustomerId=2,  BookingDate=new DateTime(2026,01,20) }
                );
        }
    }
}
