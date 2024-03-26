using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentACar.DBContext;

namespace RentACar.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserId = 1,
                    PersonId = 1,
                    Email = "vedad.keskin98@gmail.ba",
                    UserName = "vedadke",
                    Password = "bayern123"
                },
                new User
                {
                    UserId = 2,
                    PersonId = 2,
                    Email = "vedad.keskin98@gmail.ba",
                    UserName = "saidke",
                    Password = "bayern123"
                });

        }
    }
}
