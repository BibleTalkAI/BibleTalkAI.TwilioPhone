namespace BibleTalkAI.TwilioPhone;

public struct PhoneVoiceInitForm
{
    /// <summary>From phone number</summary>
    public string? From { get; set; }
    public string? FromCity { get; set; }
    public string? FromState { get; set; }
    public string? FromZip { get; set; }
    public string? FromCountry { get; set; }
}
