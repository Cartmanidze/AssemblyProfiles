using AssemblyProfiles.Core.Helpers;
using AssemblyProfiles.Core.Services.ApiService;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

namespace AssemblyProfiles.Core.Services.SeleniumService
{
    public abstract class BaseSeleniumService : ISeleniumService
    {
        private const string _keyPathToBrowser = "PathToBrowser";
        private const string _keyPathToProfile = "PathToProfile";
        protected readonly string _net;
        protected readonly ChromeDriver _chromeDriver;
        protected readonly ChromeOptions _chromeOptions;
        protected readonly WebDriverWait _webDriverWait;
        protected readonly IApiService _apiService;
        protected BaseSeleniumService(IApiService apiService, string net)
        {
            _net = net;
            var pathToBrowser = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyPathToBrowser);
            var pathToProfile = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyPathToProfile);
            _apiService = apiService;
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            _chromeOptions = new ChromeOptions();
            _chromeOptions.BinaryLocation = pathToBrowser;
            _chromeOptions.AddArgument($"--user-data-dir={pathToProfile}");
            _chromeOptions.AddArgument("--allow-file-access-from-files");
            _chromeOptions.AddArgument("--enable-file-cookies");
            _chromeOptions.AddArgument("--disable-web-security");
            _chromeOptions.AddArgument("--headless");
            _chromeOptions.AddArguments("--ignore-ssl-errors=true");
            _chromeOptions.AddArguments("--ssl-protocol=any");
            _chromeOptions.AddArguments("--disable-gpu");
            _chromeOptions.AddArguments("--user-agent=Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            _chromeDriver = new ChromeDriver(service, _chromeOptions);
            _webDriverWait = new WebDriverWait(_chromeDriver, TimeSpan.FromSeconds(2));
        }

        public virtual object GetPageSource()
        {
            var link = _apiService.GetNewLink(_net);
            var linkToByteArray = Encoding.Default.GetBytes(link);
            var linkToUtf8String = Encoding.UTF8.GetString(linkToByteArray);
            _chromeDriver.Url = linkToUtf8String;
            var pageSource = _chromeDriver.PageSource;
            return pageSource;
        }
    }
}
