using AssemblyProfiles.Core.Services;
using AssemblyProfiles.Core.Services.ApiService;
using AssemblyProfiles.Core.Services.HtmlParseService;
using AssemblyVkProfile.SocialNetworks.LinkedIn;
using AssemblyProfiles.Core.Factory;
using AssemblyVkProfile.SocialNetworksServices.LinkedIn;
using AssemblyProfiles.Core.Helpers;

namespace AssemblyVkProfile.FactorySocialNetworks.LinkedInFactory
{
    internal class LinkedInFactory : IFactoryNetwork
    {
        private IApiService _apiService;
        private const string _netKey = "LinkedIn";
        private readonly string _net;
        public LinkedInFactory(IApiService apiService)
        {
            _apiService = apiService;
            _net = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_netKey); 
        }

        IHtmlParseService IFactoryNetwork.CreateHtmlParseService()
        {
            return new LinkedInHtmlParseService();
        }

        ISeleniumService IFactoryNetwork.CreateSeleniumService()
        {
            return new LinkedInSeleniumService(_apiService, _net);
        }

        IRecordingService IFactoryNetwork.CreateRecordingService()
        {
            return new LinkedInRecordingService(_apiService);
        }
    }
}
