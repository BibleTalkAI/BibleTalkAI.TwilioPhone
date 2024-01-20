using BibleTalkAI.ObjectPools;
using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.TwilioPhone;

public class TwilioFormReaderPooledObjectPolicy(IStringBuilderPool stringBuilderPool, IDictionaryPool dictionaryPool) : IPooledObjectPolicy<TwilioFormReader>
{
    public TwilioFormReader Create() => new(stringBuilderPool, dictionaryPool);

    public bool Return(TwilioFormReader obj)
    {
        obj.Reset();
        return true;
    }
}
