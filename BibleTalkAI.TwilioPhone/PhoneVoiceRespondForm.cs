namespace BibleTalkAI.TwilioPhone;

public struct PhoneVoiceRespondForm
{
    public string? CallSid { get; set; }
    public string? SpeechResult { get; set; }
    public string? Digits { get; set; }

    /// <summary>To phone number</summary>
    public string? To { get; set; }

    /// <summary>From phone number</summary>
    public string? From { get; set; }
}
