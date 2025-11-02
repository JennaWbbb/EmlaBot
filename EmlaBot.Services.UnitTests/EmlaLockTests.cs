using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmlaBot.Services;
using Moq;

namespace EmlaBot.Services.UnitTests
{
    [TestClass]
    public class EmlaLockTests
    {
        private readonly Mock<IEmlaLockConfig> _mockConfig;
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly EmlaLock _emlaLock;

        public EmlaLockTests()
        {
            _mockConfig = new Mock<IEmlaLockConfig>();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _emlaLock = new EmlaLock(_mockConfig.Object, _mockHttpClientFactory.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            _mockConfig.SetupGet(x => x.BaseUrl).Returns(new Uri("https://example.com"));
        }

        [TestMethod]
        public void ParseRssTitle_ValidTitleAndPubDate_ReturnsAggregatedAction()
        {
            // Arrange
            string title = "Test user's duration changed because of the Friend Link. (+1 Day)";
            string pubDate = "Sat, 08 Feb 2025 19:04:43 GMT";

            // Act
            var result = _emlaLock.ParseRssTitle(title, pubDate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2025, 02, 08, 19, 04, 43, DateTimeKind.Utc).ToUnixTimestamp(), result.Time);
        }

        [TestMethod]
        public void ParseRssTitle_NullTitle_ThrowsArgumentNullException()
        {
            // Arrange
            string title = null;
            string pubDate = "Wed, 02 Oct 2002 08:00:00 EST";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _emlaLock.ParseRssTitle(title, pubDate));
        }

        [TestMethod]
        public void ParseRssTitle_InvalidPubDate_ThrowsFormatException()
        {
            // Arrange
            string title = "Test Action";
            string pubDate = "Invalid Date";

            // Act & Assert
            Assert.Throws<FormatException>(() => _emlaLock.ParseRssTitle(title, pubDate));
        }
    }
}