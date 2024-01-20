using BibleTalkAI.FormReaders;
using BibleTalkAI.ObjectPools;

namespace BibleTalkAI.TwilioPhone;

/// <remarks>
/// Skips Twilio Phone request Form fields AccountSid,ApiVersion,ToCity etc.
/// </remarks>
public class TwilioFormReader
    (IStringBuilderPool stringBuilderPool, IDictionaryPool dictionaryPool)
    : FormReaderBase(stringBuilderPool, dictionaryPool)
{
    private bool _firstCharS = false;
    private bool _firstCharT = false;
    private bool _firstCharAllowed = false;

    public override void Reset()
    {
        base.Reset();
        _firstCharS = false;
        _firstCharT = false;
        _firstCharAllowed = false;
    }

    protected override void StartReadNextPair()
    {
        base.StartReadNextPair();
        _firstCharS = false;
        _firstCharT = false;
        _firstCharAllowed = false;
    }

    protected override bool ReadCharCustom(char c, int builderLength, char separator, out string? word)
    {
        if (separator == '=')
        {
            if (builderLength == 0)
            {
                // check first letter of key

                if (c == 'S')
                {
                    _firstCharS = true;
                }
                else if (c == 'T')
                {
                    _firstCharT = true;
                    _firstCharAllowed = true;
                }
                else if (c == 'C' || c == 'D' || c == 'F' || c == 'P' || c == 'R')
                {
                    _firstCharAllowed = true;
                }

                if (!_firstCharS && !_firstCharAllowed)
                {
                    // skip parsing AccountSid, ApiVersion, etc. ...
                    _skipCurrent = true;
                }
            }
            else if (builderLength == 3)
            {
                if (_firstCharT)
                {
                    // skip parsing To* ...
                    _skipCurrent = true;
                }
            }
        }

        word = null;
        return false;
    }

    // '+' un-escapes to ' ', %HH un-escapes as ASCII (or utf-8?)
    protected override string BuildWord()
    {
        _builder!.Replace('+', ' ');
        var result = _builder.ToString();
        _builder.Clear();
        if (_firstCharS)
        {
            return Uri.UnescapeDataString(result);
        }
        return result;
    }
}
