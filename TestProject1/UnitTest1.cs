using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentApiClientExample;
using FluentApiClientExample.RequestBuilders.Components;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Test1()
        {
            var client = MyClientInitiator.NewClient(e => e
                .WithBaseUrl("http://localhost:9000")
                .WithAnonymousAuth
            );
            var request = client.MakeRequest(e => e
                .GetProjects
                .WithQualifiers(new[] {ComponentsQualifiers.Trk})
            );

            var res = await request.Execute();
            _testOutputHelper.WriteLine(res.ToString());
        }
    }


}