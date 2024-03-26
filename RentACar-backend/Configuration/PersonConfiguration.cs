using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentACar.DBContext;

namespace RentACar.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "Vedad",
                    LastName = "Keskin",
                    BirthDate = new DateTime(1998, 12, 12),
                    JMBG = "111111111"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Said",
                    LastName = "Keskin",
                    BirthDate = new DateTime(2001, 02, 16),
                    JMBG = "111111111"
                });

        }
    }
}
