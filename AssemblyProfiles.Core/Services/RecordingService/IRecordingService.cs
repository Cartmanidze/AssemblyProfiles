using AssemblyProfiles.Core.Storage;

namespace AssemblyProfiles.Core.Services
{
    public interface IRecordingService
    {
        /// <summary>
        /// Запись
        /// </summary>
        /// <param name="data">Данные профиля</param>
        void Write(IProfile data); 
    }
}
