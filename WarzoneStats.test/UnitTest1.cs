using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WarzoneStats.Controllers;
using WarzoneStats.Data;

namespace WarzoneStats.test
{
    public class Tests
    {
        [Test]
        public async Task GetReturnsContentNotNullWyatt()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetWyattStatAsync())
                .ReturnsAsync(new WyattStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.WyattStatsRaw();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetReturnsContentNotNullAustin()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetAustinStatAsync())
                .ReturnsAsync(new AustinStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.AustinStatsRaw();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetReturnsContentNotNullMatt()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetMattStatAsync())
                .ReturnsAsync(new Models.MattStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.MattStatsRaw();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetReturnsContentNotNullSam()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetSamStatAsync())
                .ReturnsAsync(new Models.SamStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.SamStatsRaw();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetReturnsContentNotNullSteve()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetSteveStatAsync())
                .ReturnsAsync(new Models.SteveStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.SteveStatsRaw();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetReturnsContentNotNullUser()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetUserStatAsync("the_accountv", "psn"))
                .ReturnsAsync(new Models.UserStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.UserStatsRaw("the_accountv", "psn");

            // Assert
            Assert.IsNotNull(response);
        }
        [Test]
        public async Task GetReturnsContentIsNullUser()
        {
            // Arrange
            var mockRepository = new Mock<IStatService>();
            mockRepository.Setup(x => x.GetUserStatAsync("klafjlakdgj", "kdagjiae"))
                .ReturnsAsync(new Models.UserStatResult());

            var controller = new StatsController(mockRepository.Object);

            // Act
            var response = await controller.UserStatsRaw("dgda", "kdaagaergjiae");

            // Assert
            Assert.IsNull(response);
        }



    }
}