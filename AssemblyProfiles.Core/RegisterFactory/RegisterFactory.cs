using AssemblyProfiles.Core.Factory;
using AssemblyProfiles.Core.Services.ApiService;
using AssemblyProfiles.Core.Storage;
using System;
using System.Collections.Generic;

namespace AssemblyProfiles.Core.RegisterFactory
{
    public static class RegisterFactory
    {
        public static Dictionary<IFactoryNetwork, IProfile> RegisteredFactory =  new Dictionary<IFactoryNetwork, IProfile>();

        /// <summary>
        /// Регистрация фабрики
        /// </summary>
        /// <typeparam name="TFactory">Тип фабрики</typeparam>
        /// <typeparam name="TProfile">Тип профиля</typeparam>
        /// <param name="apiService">Сервис Api</param>
        public static void Register<TFactory, TProfile>(IApiService apiService) 
            where TFactory : class, IFactoryNetwork
            where TProfile : IProfile
        {
            TFactory factory = (TFactory)Activator
                .CreateInstance(typeof(TFactory), new object[] { apiService });
            TProfile profile = (TProfile)Activator
                .CreateInstance(typeof(TProfile), new object[] {});
            RegisteredFactory.Add(factory, profile);
        }
    }
}
