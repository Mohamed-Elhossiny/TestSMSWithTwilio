using Twilio.Rest.Api.V2010.Account;

namespace TestSMS.Sevices
{
    public interface ISMSService
    {
        MessageResource Send(string PhoneNumber, string body);
    }
}
