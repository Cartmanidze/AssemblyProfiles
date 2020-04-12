using AssemblyProfiles.Core.Services.ApiService;
using AssemblyProfiles.Core.Services.SeleniumService;
using System.Collections.Generic;
using System.Web;

namespace AssemblyProfile.SocialNetworks.LinkedIn
{
    public class LinkedInSeleniumService : BaseSeleniumService
    {
        public LinkedInSeleniumService(IApiService apiService, string net) : base(apiService, net)
        {
        }

        public override object GetPageSource()
        {
            var link = _apiService.GetNewLink(_net);
            var query = link.Substring(link.LastIndexOf('/') + 1);
            var queryToHttpEncode = HttpUtility.UrlEncode(query);
            var linkToHttpEncode = "https://www.linkedin.com/in/" + queryToHttpEncode.ToUpper();
            _chromeDriver.Url = linkToHttpEncode + '/';
            var pageSource = _chromeDriver.PageSource;
            _chromeDriver.Url = linkToHttpEncode + "/detail/contact-info/";
            var pageContacts = _chromeDriver.PageSource;
            return new KeyValuePair<string, string>(pageSource, pageContacts);
        }
    }
}
