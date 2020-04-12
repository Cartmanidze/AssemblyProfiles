namespace AssemblyProfiles.Core.Services.AssemblyProfileService
{
    public interface IAssemblyProfileService
    {
        /// <summary>
        /// Старт отправки
        /// </summary>
        void Start();

        /// <summary>
        /// Остановка отправки
        /// </summary>
        void Stop();
    }
}
