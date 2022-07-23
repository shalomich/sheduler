﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Desktop.Infrastructure.DependencyInjection;
using Xunit;

namespace Sheduler.Desktop.Tests
{
    /// <summary>
    /// Test for AutoMapper configuration.
    /// </summary>
    public class AutoMapperTests
    {
        /// <summary>
        /// Verify that automapper configuration is valid.
        /// </summary>
        [Fact]
        public void AutoMapper_Configuration_Valid()
        {
            // Arrange
            var sc = new ServiceCollection();
            AutoMapperModule.Register(sc);

            // Act
            var serviceProvider = sc.BuildServiceProvider();
            var mapper = serviceProvider.GetRequiredService<IMapper>();

            // Assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
