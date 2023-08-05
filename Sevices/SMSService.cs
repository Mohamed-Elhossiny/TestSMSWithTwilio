using Microsoft.Extensions.Options;
using TestSMS.Helper;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Intelligence.V2;

namespace TestSMS.Sevices
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSetting _twilio;

        public SMSService(IOptions<TwilioSetting> twilio)
        {
            this._twilio = twilio.Value;
        }
        public MessageResource Send(string PhoneNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
            var result = MessageResource.Create(
                body:body,
                from:new Twilio.Types.PhoneNumber(_twilio.PhoneNumber),
                to:PhoneNumber
                );
            return result;
        }
    }
}
