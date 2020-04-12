using AssemblyProfiles.Core.Helpers;
using AssemblyProfiles.Core.Services;
using AssemblyProfiles.Core.Services.ApiService;
using AssemblyProfiles.Core.Storage;

namespace AssemblyProfile.SocialNetworksServices
{
    internal abstract class BaseRecordingService : IRecordingService
    {
        private readonly IApiService _apiService;
        public BaseRecordingService(IApiService apiService)
        {
            _apiService = apiService;
        }

        void IRecordingService.Write(IProfile data)
        {
            var json = JsonConverterHelper.ToJson(data);
            var currentLink = _apiService.CurrentLink;
            _apiService.AddLinkInfo(currentLink, json);
        }
    }
}
