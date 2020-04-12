using AssemblyProfiles.Core.Factory;
using AssemblyProfiles.Core.Helpers;
using AssemblyProfiles.Core.Services.HtmlParseService;
using AssemblyProfiles.Core.Storage;
using System;
using System.Timers;

namespace AssemblyProfiles.Core.Services.AssemblyProfileService
{
    public class AssemblyProfileService : IAssemblyProfileService
    {
        private const string _keyStartInterval = "StartInterval";
        private readonly Timer _timer;
        private readonly IFactoryNetwork _factoryNetwork;
        private readonly IProfile _profile;
        private IHtmlParseService _parseService;
        private ISeleniumService _seleniumService;
        private IRecordingService _recordingService;


        public AssemblyProfileService(IFactoryNetwork factoryNetwork)
        {
            var startIntervalValue = ConfigValueGetterHelper.GetValueByKeyFromConfiguration(_keyStartInterval);
            if (int.TryParse(startIntervalValue, out int startInterval))
            {
                var interval = new TimeSpan(0, startInterval, 0);
                _timer = new Timer { Enabled = true, AutoReset = true, Interval = interval.TotalMilliseconds };
            }
            else
            {
                throw new ArgumentException("Неккорректное значение интервала из файла конфигурации");
            }          
            _factoryNetwork = factoryNetwork;
            InitServices();
        }

        private void InitServices()
        {
            if (_factoryNetwork != null)
            {
                _parseService = _factoryNetwork.CreateHtmlParseService();
                _seleniumService = _factoryNetwork.CreateSeleniumService();
                _recordingService = _factoryNetwork.CreateRecordingService();
            }
            else
            {
                throw new Exception("Инициализация фабрики сетей не выполнена");
            }
        }

        private IProfile AssemblyProfiles() 
        {
            var pageSource = _seleniumService.GetPageSource();
            var profile = _parseService.GetProfileFromHtml(pageSource);
            return profile;
        }

        private void SendProfile()
        {
            var profile = AssemblyProfiles();
            _recordingService.Write(profile);
        }

        public void Start()
        {
            _timer.Elapsed += (s, e) =>
           {
               SendProfile();
           };
        }

        public void Stop()
        {
            _timer?.Stop();
        }
    }
}
