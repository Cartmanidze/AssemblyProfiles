using AssemblyProfiles.Core.Storage;

namespace AssemblyProfiles.Core.Services.HtmlParseService
{
    public interface IHtmlParseService
    {
        /// <summary>
        /// Получение профиля
        /// </summary>
        /// <param name="html">Hml страница</param>
        /// <returns>Профиль</returns>
        IProfile GetProfileFromHtml(object html);
    }
}
