namespace AssemblyProfiles.Core.Services.ApiService
{
    public interface IApiService
    {
        /// <summary>
        /// Текущая ссылка в обработке
        /// </summary>
        string CurrentLink { get; set; }
        /// <summary>
        /// Получение новой ссылки
        /// </summary>
        /// <returns>Ссылка</returns>
        string GetNewLink(string net);
        /// <summary>
        /// Показать все ссылки в процессе сбора информации
        /// </summary>
        /// <returns>Ссылки в процессе</returns>
        string ShowAllLinkInProgress();
        /// <summary>
        /// Установить статус прогресса
        /// </summary>
        /// <param name="link">Ссылка</param>
        void SetStatusInProgressToLink(string link);
        /// <summary>
        /// Возвращает Json по ссылке
        /// </summary>
        /// <param name="link">Ссылка</param>
        /// <returns>Json даныне по ссылке</returns>
        string GetJsonByLink(string link);
        /// <summary>
        /// Добавляет инофрмацию о ссылке в формате Json
        /// </summary>
        /// <param name="json">Json данные</param>
        /// <param name="link">Ссылка</param>
        void AddLinkInfo(string link, string json);
    }
}
