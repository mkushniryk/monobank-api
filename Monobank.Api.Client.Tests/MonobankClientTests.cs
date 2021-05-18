using Monobank.Api.Client.Abstractions;
using Monobank.Api.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;


namespace Monobank.Api.Client.Tests
{

    public class MonobankClientTests : BaseTest
    {
        private readonly IMonobankClient Client;

        public MonobankClientTests() : base()
        {
            Client = MonobankApi.Create(Token);
        }

        [Fact]
        public void Test()
        {

        }

        [Fact]
        public async Task GetClientInfo()
        {
            var response = await Client.GetClientInfoAsync();

            response.Should().NotBeNull();
        }
    }
}