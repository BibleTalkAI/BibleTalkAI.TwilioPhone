using BibleTalkAI.ObjectPools;

namespace BibleTalkAI.TwilioPhone;

public class PhoneFormDataParser
    (ITwilioFormReaderPool formReaderPool, IDictionaryPool dictionaryPool)
    : IPhoneFormDataParser
{
    private static readonly HashSet<string> _phoneVoiceInitFormKeys =
    [
        "From",
        "FromCity",
        "FromState",
        "FromZip",
        "FromCountry"
    ];

    private static readonly HashSet<string> _phoneVoiceRespondFormKeys =
    [
        "CallSid",
        "SpeechResult",
        "Digits",
        "To",
        "From"
    ];

    private static readonly HashSet<string> _phoneDigitsRespondFormKeys =
    [
        "CallSid",
        "Digits",
        "To",
        "From"
    ];

    private static readonly HashSet<string> _phonePaymentRespondFormKeys =
    [
        "CallSid",
        "Result",
        "ProfileId",
        "To",
        "From"
    ];

    public PhoneVoiceInitForm? ReadPhoneVoiceInitForm(Stream stream)
    {
        TwilioFormReader formReader = formReaderPool.Get();
        Dictionary<string, string?>? parameters = formReader.ReadForm(stream, _phoneVoiceInitFormKeys);

        formReaderPool.Return(formReader);

        if (parameters == null) return null;

        parameters.TryGetValue("From", out string? from);
        parameters.TryGetValue("FromCity", out string? fromCity);
        parameters.TryGetValue("FromState", out string? fromState);
        parameters.TryGetValue("FromZip", out string? fromZip);
        parameters.TryGetValue("FromCountry", out string? fromCountry);

        dictionaryPool.Return(parameters);

        return new PhoneVoiceInitForm
        {
            From = from?.Replace("%2B", "+"),
            FromCity = fromCity,
            FromState = fromState,
            FromZip = fromZip,
            FromCountry = fromCountry
        };
    }

    public PhoneVoiceRespondForm? ReadPhoneVoiceRespondForm(Stream stream)
    {
        TwilioFormReader formReader = formReaderPool.Get();
        Dictionary<string, string?>? parameters = formReader.ReadForm(stream, _phoneVoiceRespondFormKeys);

        formReaderPool.Return(formReader);

        if (parameters == null) return null;

        parameters.TryGetValue("CallSid", out string? callSid);
        parameters.TryGetValue("SpeechResult", out string? speechResult);
        parameters.TryGetValue("Digits", out string? digits);
        parameters.TryGetValue("To", out string? to);
        parameters.TryGetValue("From", out string? from);

        dictionaryPool.Return(parameters);

        return new PhoneVoiceRespondForm
        {
            CallSid = callSid,
            SpeechResult = speechResult,
            Digits = digits,
            To = to?.Replace("%2B", "+"),
            From = from?.Replace("%2B", "+")
        };
    }

    public PhoneDigitsRespondForm? ReadPhoneDigitsRespondForm(Stream stream)
    {
        TwilioFormReader formReader = formReaderPool.Get();
        Dictionary<string, string?>? parameters = formReader.ReadForm(stream, _phoneDigitsRespondFormKeys);

        formReaderPool.Return(formReader);

        if (parameters == null) return null;

        parameters.TryGetValue("CallSid", out string? callSid);
        parameters.TryGetValue("Digits", out string? digits);
        parameters.TryGetValue("To", out string? to);
        parameters.TryGetValue("From", out string? from);

        dictionaryPool.Return(parameters);

        return new PhoneDigitsRespondForm
        {
            CallSid = callSid,
            Digits = digits,
            To = to?.Replace("%2B", "+"),
            From = from?.Replace("%2B", "+")
        };
    }

    public PhonePaymentRespondForm? ReadPhonePaymentRespondForm(Stream stream)
    {
        TwilioFormReader formReader = formReaderPool.Get();
        Dictionary<string, string?>? parameters = formReader.ReadForm(stream, _phonePaymentRespondFormKeys);

        formReaderPool.Return(formReader);

        if (parameters == null) return null;

        parameters.TryGetValue("CallSid", out string? callSid);
        parameters.TryGetValue("Result", out string? result);
        parameters.TryGetValue("ProfileId", out string? profileId);
        parameters.TryGetValue("To", out string? to);
        parameters.TryGetValue("From", out string? from);

        dictionaryPool.Return(parameters);

        return new PhonePaymentRespondForm
        {
            CallSid = callSid,
            Result = result,
            ProfileId = profileId,
            To = to?.Replace("%2B", "+"),
            From = from?.Replace("%2B", "+")
        };
    }
}
