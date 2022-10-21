using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Nito.AsyncEx;

namespace WhatsAppApiUCU
{
    public class WhatsAppApi
    {
        private static bool initialized = false;
        private static string accountSid;
        private static string authToken;

        public WhatsAppApi()
        {
            if (!initialized)
			{
				AsyncContext.Run(InitializeAsync);
				initialized = true;
			}
        }

		private static async Task InitializeAsync()
		{
			HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(@"https://pii-secretsapiwebapp.azurewebsites.net/WhatsAppApiSecrets");
            string result = await response.Content.ReadAsStringAsync();
            WhatsAppApiSecrets secrets = JsonSerializer.Deserialize<WhatsAppApiSecrets>(result,
                new JsonSerializerOptions { PropertyNamingPolicy  = JsonNamingPolicy.CamelCase });

            accountSid = secrets.AccountSid;
            authToken = secrets.AuthToken;
		}

        public string Send(string to, string text)
        {
            if (!to.StartsWith("+598"))
            {
                return "El número al que mandás el mensaje de comienzar con +598";
            }

            if (to.Length != 12)
            {
                return "Le faltan o sobran dígitos al número al que querés mandar el mensaje";
            }

            if (!Int64.TryParse(to, out _))
            {
                return "El número al que mandás el mensaje tiene que tener sólo números";
            }

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                to: new Twilio.Types.PhoneNumber($"whatsapp:{to}")
            );

            return message.Sid;
        }
    }
}