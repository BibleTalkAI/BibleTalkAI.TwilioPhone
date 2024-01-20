using Microsoft.Extensions.ObjectPool;

namespace BibleTalkAI.TwilioPhone;

public class TwilioFormReaderPool(ObjectPool<TwilioFormReader> pool) : ITwilioFormReaderPool
{
    public TwilioFormReader Get() => pool.Get();

    public void Return(TwilioFormReader instance) => pool.Return(instance);
}
