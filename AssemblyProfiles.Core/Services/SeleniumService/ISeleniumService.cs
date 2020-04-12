namespace AssemblyProfiles.Core.Services
{
    /// <summary>
    /// Сервис Selenium для получения исходной страницы
    /// </summary>
    public interface ISeleniumService
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns>Страница</returns>
        object GetPageSource();
    }
}
