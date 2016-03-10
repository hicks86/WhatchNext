using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmdbApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmdbApi.Tests
{
    [TestClass()]
    public class OmdbShowsServiceTests
    {
        [TestMethod]
        public async Task GetImdbShowDetailsTest_PassInValidImdbId_ReturnImdbShowInformation()
        {
            //Arrange
            OmdbShowsService service = new OmdbShowsService();

            //Act
            var show = await service.GetImdbShowDetails("tt0903747");

            //Assert
            Assert.IsNotNull(show);

        }
    }
}