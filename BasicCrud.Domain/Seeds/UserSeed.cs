using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Seeds
{
    public static class UserSeed
    {
        public static User GetAdministrator()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                CreatedDate = DateTime.UtcNow
            };
            user.NormalizedUsername = user.Username.ToUpperInvariant();
            user.Salt = "7oUcxS1ocT0s-29r_1XULrNbe6GaNRDTXD3shuNvrqIrThDSCkUhZPG2a_On7xIKNaleu6of1BlzOrKWFQb6-InaQFYjE7fg-cfqhcn2tz8gWf_11FdwRlXjKNnfNs_7";
            user.PasswordHash = PasswordManager.HashPassword(user.Salt, "Qwerty@123");

            return user;
        }

    }
}
