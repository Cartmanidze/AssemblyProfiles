using AssemblyProfiles.Core.Storage;
using System.Collections.Generic;

namespace AssemblyProfiles.Data
{
    public class LinkedInProfile : IProfile
    {
        public LinkedInProfile()
        {
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Контакты
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// Образование
        /// </summary>
        public List<string> Education { get; set; }
        /// <summary>
        /// Опыт
        /// </summary>
        public List<string> Experience { get; set; }

    }

}


