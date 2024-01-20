using BibleTalkAI.ObjectPools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.TwilioPhone;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTwilioPhoneServices(this IServiceCollection services)
    {
        return services.AddTwilioFormReaderPool()
            .AddSingleton<IPhoneFormDataParser, PhoneFormDataParser>();
    }

    public static IServiceCollection AddTwilioFormReaderPool(this IServiceCollection services) =>
        services.AddStringBuilderObjectPool()
            .AddDictionaryObjectPool()
            .AddSingleton(serviceProvider =>
            {
                var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
                var stringBuilderPool = serviceProvider.GetRequiredService<IStringBuilderPool>();
                var dictionaryPool = serviceProvider.GetRequiredService<IDictionaryPool>();
                var policy = new TwilioFormReaderPooledObjectPolicy(stringBuilderPool, dictionaryPool);
                return provider.Create(policy);
            })
            .AddSingleton<ITwilioFormReaderPool, TwilioFormReaderPool>();
}