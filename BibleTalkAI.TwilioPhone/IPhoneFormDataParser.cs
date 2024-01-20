namespace BibleTalkAI.TwilioPhone;

public interface IPhoneFormDataParser
{
    PhoneVoiceInitForm? ReadPhoneVoiceInitForm(Stream stream);
    PhoneVoiceRespondForm? ReadPhoneVoiceRespondForm(Stream stream);
    PhoneDigitsRespondForm? ReadPhoneDigitsRespondForm(Stream stream);
    PhonePaymentRespondForm? ReadPhonePaymentRespondForm(Stream stream);
}
