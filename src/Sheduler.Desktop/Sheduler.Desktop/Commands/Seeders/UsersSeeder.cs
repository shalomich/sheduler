﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Sheduler.Domain.Users.Entities;

namespace Sheduler.Desktop.Commands.Seeders
{
    /// <summary>
    /// Users seeder.
    /// </summary>
    public class UsersSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly ILogger<UsersSeeder> logger;

        private readonly Faker faker = new Faker();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userManager">User manager.</param>
        /// <param name="logger">Logger.</param>
        public UsersSeeder(UserManager<User> userManager, ILogger<UsersSeeder> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        /// <summary>
        /// Seed.
        /// </summary>
        /// <param name="numberOfItems">Total items to create.</param>
        /// <param name="password">Default user password.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Number of created items.</returns>
        public async Task<int> Seed(int numberOfItems, string password = "11111111Aa")
        {
            var count = 0;
            foreach (var chunk in Saritasa.Tools.Common.Utils.CollectionUtils
                .ChunkSelectRange(Enumerable.Range(0, numberOfItems), chunkSize: 50))
            {
                foreach (var chunkRange in chunk)
                {
                    var result = await userManager.CreateAsync(GenerateUser(), password);
                    if (!result.Succeeded)
                    {
                        logger.LogWarning($"Cannot create user: {result}.");
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            logger.LogInformation($"Created {count} users.");
            return count;
        }

        private User GenerateUser()
        {
            var email = faker.Internet.Email(provider: "redman.com");
            return new User
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumber = faker.Phone.PhoneNumber("###-###-#####"),
                PhoneNumberConfirmed = true
            };
        }
    }
}
