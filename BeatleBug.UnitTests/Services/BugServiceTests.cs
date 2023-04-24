using BeatleBug.Repository;
using BeatleBug.Services;
using BeatleBug.Models.Dtos;
using Moq;
using BeatleBug.Models;
using System.Reflection;

namespace BeatleBug.UnitTests.Services
{
    /// <summary>
    /// Simple test class with basic test method
    /// </summary>
    [TestClass]
    public class BugServiceTests
    {
        private BugService _bugService;
        private Mock<IBugRepository> _mockBugRepository;
        readonly Bug data = new()
        {
            BugId = 1,
            Title = "Test",
            Description = "description",
            Assignee = "User1",
            Reporter = "User2"
        };    

        [TestInitialize]
        public void Setup()
        {
            _mockBugRepository = new Mock<IBugRepository>();
            _bugService = new BugService(_mockBugRepository.Object);
        }

        [TestMethod]
        public async Task BetService_GetSingleBug_ReturnsBug()
        {
            // Arrange
            Bug bug = data;
            _mockBugRepository.Setup(p => p.GetSingleBug(1)).ReturnsAsync(bug);

            // Act
            var actual = await _bugService.GetSingleBug(1);

            // Assert
            _mockBugRepository.Verify(x => x.GetSingleBug(1), Times.Once());
        }
    }
}