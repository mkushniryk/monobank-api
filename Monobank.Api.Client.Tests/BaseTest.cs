using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Monobank.Api.Client.Tests
{
    public abstract class BaseTest
    {
        protected readonly string Token;

        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            Token = configuration.GetSection("Token").Value;
        }
    }
}