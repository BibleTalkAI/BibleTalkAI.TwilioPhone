namespace BibleTalkAI.TwilioPhone;

public struct PhonePaymentRespondForm
{
    public string? CallSid { get; set; }
    public string? Result { get; set; }
    public string? ProfileId { get; set; }

    /// <summary>To phone number</summary>
    public string? To { get; set; }

    /// <summary>From phone number</summary>
    public string? From { get; set; }
}
