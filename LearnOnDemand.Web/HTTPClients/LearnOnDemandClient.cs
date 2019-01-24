using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnDemand.Web.HTTPClients
{
    public class LearnOnDemandClient : ILearnOnDemandClient
    {
        private readonly RestClient _client;

        private const string GETORGANIZATIONS_URL = "Organization";
        private const string GETORGANIZATION_URL = "Organization/{id}";
        private const string UPDATEORGANIZATION_URL = "Organization/{id}";
        private const string CREATEORGANIZATION_URL = "Organization";
        private const string DELETEORGANIZATION_URL = "Organization/{id}";
        private const string GETUSER_URL = "User/{id}";
        private const string UPDATEUSER_URL = "User/{id}";
        private const string CREATEUSER_URL = "User";
        private const string DELETEUSER_URL = "User/{id}";
        public LearnOnDemandClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<List<OrganizationModel>> GetOrganizations()
        {
            var response = await _client.ExecuteTaskAsync(new RestRequest(GETORGANIZATIONS_URL, Method.GET));

            if(response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<OrganizationModel>>(response.Content);
            }

            return new List<OrganizationModel>();
        }

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            var request = new RestRequest(GETORGANIZATION_URL, Method.GET);
            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<OrganizationModel>(response.Content);
            }

            return new OrganizationModel();
        }

        public async Task<int> CreateOrganization(OrganizationModel model)
        {
            var request = new RestRequest(CREATEORGANIZATION_URL, Method.POST);

            request.AddJsonBody(model);

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<int>(response.Content);
            }

            return 0;
        }

        public async Task UpdateOrganization(OrganizationModel model)
        {
            var request = new RestRequest(UPDATEORGANIZATION_URL, Method.PUT);

            var parameters = new Dictionary<string, object>()
            {
                { "id", model.Id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            request.AddJsonBody(model);

            await _client.ExecuteTaskAsync(request);
        }

        public async Task DeleteOrganization(int id)
        {
            var request = new RestRequest(DELETEORGANIZATION_URL, Method.DELETE);

            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            await _client.ExecuteTaskAsync(request);
        }

        public async Task<UserModel> GetUser(int id)
        {
            var request = new RestRequest(GETUSER_URL, Method.GET);

            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<UserModel>(response.Content);
            }

            return new UserModel();
        }

        public async Task UpdateUser(UserModel model)
        {
            var request = new RestRequest(UPDATEUSER_URL, Method.PUT);

            var parameters = new Dictionary<string, object>()
            {
                { "id", model.Id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            request.AddJsonBody(model);

            await _client.ExecuteTaskAsync(request);
        }

        public async Task<int> CreateUser(UserModel model)
        {
            var request = new RestRequest(CREATEUSER_URL, Method.POST);

            request.AddJsonBody(model);

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<int>(response.Content);
            }

            return 0;
        }

        public async Task DeleteUser(int id)
        {
            var request = new RestRequest(DELETEUSER_URL, Method.DELETE);

            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            await _client.ExecuteTaskAsync(request);
        }
    }
}
