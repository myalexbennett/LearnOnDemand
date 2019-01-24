using LearnOnDemand.Interfaces;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnDemand.Services
{
    public class SendGridService : ISendGridService
    {
        private readonly RestClient _client;

        private const string SENDMAIL_URL = "mail/send";

        public SendGridService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task SendMail(string to, string email)
        {
            var request = new RestRequest(SENDMAIL_URL, Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer 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");

            var parameters = $"{{\"personalizations\":[{{\"to\":[{{\"email\":\"{email}\",\"name\":\"{to}\"}}],\"subject\":\"New Organization Assignment\"}}],\"from\":{{\"email\":\"info@learnondemandsystems.com\",\"name\":\"Learn On Demand\"}},\"reply_to\":{{\"email\":\"no_reply@example.com\",\"name\":\"No Reply\"}},\"content\":[{{\"type\":\"text/plain\",\"value\":\"You have been assigned to a new Organization\"}}]}}";

            request.AddParameter("application/json", parameters, ParameterType.RequestBody);

            var response = await _client.ExecuteTaskAsync(request);
        }
    }
}
