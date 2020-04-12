using AssemblyProfiles.Core.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AssemblyProfiles.Core.Services.ApiService
{
    public class ApiService : IApiService
    {
        private readonly string token;
        private readonly HttpClient client;
        private const string _keyGetNewLink = "GetNewLink";
        private const string _keyAddOrGetLinkInfo = "AddOrGetLinkInfo";
        private const string _keySetOrGetLinkInProgress = "SetOrGetLinkInProgress";
        private const string _keyToken = "Token";

        public string CurrentLink { get; set; }

        public ApiService()
        {
            token = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyToken);
            client = new HttpClient();
        }

        public async void AddLinkInfo(string link, string json)
        {
            var tokenDecode = HttpUtility.UrlDecode(token);
            var postValues = new Dictionary<string, string>()
                {
                    { nameof(token), tokenDecode },
                    { nameof(link), link },
                    { nameof(json), json }
                };
            var query = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyAddOrGetLinkInfo);
            var content = new FormUrlEncodedContent(postValues);
            var response = await client.PostAsync(query, content);
        }

        public string GetJsonByLink(string link)
        {
            var query = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyAddOrGetLinkInfo);
            var getQuery = $"{query}?{nameof(token)}={token}&{nameof(link)}{link}";
            var task = Task.Run(() => client.GetStringAsync(getQuery));
            task.Wait();
            var response = task.Result;
            return response;
        }

        public string GetNewLink(string net)
        {
            var query = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyGetNewLink);
            var getQuery = $"{query}?{nameof(token)}={token}&{nameof(net)}={net}";
            var task = Task.Run(() => client.GetStringAsync(getQuery));
            task.Wait();
            var response = task.Result;
            CurrentLink = response;
            SetStatusInProgressToLink(response);
            return response;
        }

        public async void SetStatusInProgressToLink(string link)
        {
            var tokenDecode = HttpUtility.UrlDecode(token);
            var postValues = new Dictionary<string, string>()
                {
                    { nameof(token), tokenDecode },
                    { nameof(link), link },
                };
            var query = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keySetOrGetLinkInProgress);
            var content = new FormUrlEncodedContent(postValues);
            var response = await client.PostAsync(query, content);
        }

        public string ShowAllLinkInProgress()
        {
            var query = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keySetOrGetLinkInProgress);
            var getQuery = $"{query}?{nameof(token)}={token}";
            var task = Task.Run(() => client.GetStringAsync(getQuery));
            task.Wait();
            var response = task.Result;
            return response;
        }
    }
}
