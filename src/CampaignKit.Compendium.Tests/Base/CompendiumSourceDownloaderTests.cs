using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignKit.Compendium.Core.Base;
using System;

namespace CampaignKit.Compendium.Core.Base.Tests
{
    [TestClass()]
    public class CompendiumSourceDownloaderTests
    {
        [TestMethod()]
        public void Constructor_NullSourceDataUrl_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CompendiumSourceDownloader(null, "sourceLicenseUrl", "dataFolder"));
        }

        [TestMethod()]
        public void Constructor_NullSourceLicenseUrl_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CompendiumSourceDownloader("sourceDataUrl", null, "dataFolder"));
        }

        [TestMethod()]
        public void Constructor_NullDataFolder_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CompendiumSourceDownloader("sourceDataUrl", "sourceLicenseUrl", null));
        }

    }
}
