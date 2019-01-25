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
            var response = await _client.ExecuteTaskAsync(GetRequest(GETORGANIZATIONS_URL, Method.GET));

            if(response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<OrganizationModel>>(response.Content);
            }

            return new List<OrganizationModel>();
        }

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            var request = GetRequest(GETORGANIZATION_URL, Method.GET, parameters: parameters);

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<OrganizationModel>(response.Content);
            }

            return new OrganizationModel();
        }

        public async Task<int> CreateOrganization(OrganizationModel model)
        {
            var request = GetRequest(CREATEORGANIZATION_URL, Method.POST, model);

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<int>(response.Content);
            }

            return 0;
        }

        public async Task UpdateOrganization(OrganizationModel model)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "id", model.Id }
            };

            var request = GetRequest(UPDATEORGANIZATION_URL, Method.PUT, parameters, model);

            await _client.ExecuteTaskAsync(request);
        }

        public async Task DeleteOrganization(int id)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            var request = GetRequest(DELETEORGANIZATION_URL, Method.DELETE, parameters: parameters);

            await _client.ExecuteTaskAsync(request);
        }

        public async Task<UserModel> GetUser(int id)
        {
            var request = GetRequest(GETUSER_URL, Method.GET);

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
            var parameters = new Dictionary<string, object>()
            {
                { "id", model.Id }
            };

            var request = GetRequest(UPDATEUSER_URL, Method.PUT, parameters, model);

            await _client.ExecuteTaskAsync(request);
        }

        public async Task<int> CreateUser(UserModel model)
        {
            var request = GetRequest(CREATEUSER_URL, Method.POST, model);

            var response = await _client.ExecuteTaskAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<int>(response.Content);
            }

            return 0;
        }

        public async Task DeleteUser(int id)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "id", id }
            };

            var request = GetRequest(DELETEUSER_URL, Method.DELETE, parameters: parameters);

            await _client.ExecuteTaskAsync(request);
        }

        private RestRequest GetRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }

        private RestRequest GetRequest(string resource, Method method, Dictionary<string, object> parameters)
        {
            var request = new RestRequest(resource, method);

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            return request;
        }

        private RestRequest GetRequest(string resource, Method method, object model)
        {
            var request = new RestRequest(resource, method);

            request.AddJsonBody(model);

            return request;
        }

        private RestRequest GetRequest(string resource, Method method, Dictionary<string, object> parameters, object model)
        {
            var request = new RestRequest(resource, method);

            parameters.ToList().ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.UrlSegment));

            request.AddJsonBody(model);

            return request;
        }
    }
}
