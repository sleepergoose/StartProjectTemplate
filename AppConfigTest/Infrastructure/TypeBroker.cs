using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppConfigTest.Models;

namespace AppConfigTest.Infrastructure
{
    public class TypeBroker
    {
        private static Type repoType = typeof(MemoryRepository);
        private static IRepository repoTest;

        public static IRepository Repository =>
            repoTest ?? Activator.CreateInstance(repoType) as IRepository;

        public static void SetRepoType<T>() where T : IRepository =>
            repoType = typeof(T);

        public static void SetRepoTest(IRepository repository) =>
            repoTest = repository;
    }
}
