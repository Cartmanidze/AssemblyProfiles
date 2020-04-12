using AssemblyProfiles.Core.Services;
using AssemblyProfiles.Core.Services.HtmlParseService;

namespace AssemblyProfiles.Core.Factory
{
    public interface IFactoryNetwork
    {
        /// <summary>
        /// Создание сервиса для Selenium
        /// </summary>
        /// <returns></returns>
        ISeleniumService CreateSeleniumService();

        /// <summary>
        /// Создание парсера Html
        /// </summary>
        /// <returns></returns>
        IHtmlParseService CreateHtmlParseService();

        /// <summary>
        /// Создание сервиса записи
        /// </summary>
        /// <returns></returns>
        IRecordingService CreateRecordingService();
    }
}
