namespace AssemblyProfiles.Core.Services
{
    public interface ISeleniumService
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns>Страница</returns>
        object GetPageSource();
    }
}
