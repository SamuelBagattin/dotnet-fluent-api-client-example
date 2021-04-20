using System;
using FluentApiClientExample;
using FluentApiClientExample.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SonarQubeFluentApiClient.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMyClient(
            this IServiceCollection serviceCollection,
            Func<MyClientBaseUrlBuilder, AuthType> clientBuilder) =>
            serviceCollection.AddSingleton(_ => MyClientInitiator.NewClient(clientBuilder));
    }
}