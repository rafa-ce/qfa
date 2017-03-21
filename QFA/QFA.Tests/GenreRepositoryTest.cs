using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QFA.Repositorys;
using System.Threading.Tasks;

namespace QFA.Tests
{
    [TestClass]
    public class GenreRepositoryTest
    {
        [TestMethod]
        public void GetGenresAsync()
        {
            var Repository = new GenreRepository();
            var items = Repository.GenreMovieListAsync().Result;

            Assert.AreEqual(19, items.Count);
        }
    }
}
