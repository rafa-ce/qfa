using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QFA.Repositorys;

namespace QFA.Tests
{
    [TestClass]
    public class DiscoverRepositoryTest
    {
        [TestMethod]
        public void DiscoverMoviesByGenreIdAsync()
        {
            var repository = new DiscoverRepository();
            var movies = repository.DiscoverMoviesByGenreIdAsync(28).Result ;
        }
    }
}
