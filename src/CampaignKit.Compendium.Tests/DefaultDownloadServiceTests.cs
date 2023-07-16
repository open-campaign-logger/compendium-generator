// Unit Test
using CampaignKit.Compendium.Core.Services;
using CampaignKit.Compendium.Utility;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Moq;

namespace CampaignKit.Compendium.Core.Tests
{
    [TestClass]
    public class DefaultDownloadServiceTests
    {
        private IConfigurationService? configurationService;

        [TestMethod]
        public async Task DownloadFile_Should_Create_Directory_If_Not_Exists()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object, GetConfigurationService());
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out string path, out string file);

            // Act
            await sourceHelper.DownloadFile(sourceDataUri, overwrite);

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file)));
        }

        [TestMethod]
        public async Task DownloadFile_Should_Download_If_File_Exists_And_Overwrite_Is_True()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = true;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object, GetConfigurationService());
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out string path, out string file);

            // Act
            Directory.CreateDirectory(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path));
            File.WriteAllText(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, overwrite);
            FileInfo fileInfoAfter = new(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file)));
            Assert.AreNotEqual(0, fileInfoAfter.Length);
        }

        [TestMethod]
        public async Task DownloadFile_Should_Not_Download_If_File_Exists_And_Overwrite_Is_False()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object, GetConfigurationService());
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out string path, out string file);

            // Act
            Directory.CreateDirectory(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path));
            File.WriteAllText(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, overwrite);
            FileInfo fileInfoAfter = new (Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetRootDataDirectory(), path, file)));
            Assert.AreEqual(0, fileInfoAfter.Length);

        }

        [TestInitialize]
        public void Setup()
        {
            // Setup the configuration service if required.
            this.configurationService ??= GetConfigurationService();

            // Check if the directory exists.
            if (Directory.Exists(this.configurationService.GetRootDataDirectory()))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(this.configurationService.GetRootDataDirectory(), true);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Check if the directory exists.
            if (Directory.Exists(GetConfigurationService().GetRootDataDirectory()))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(GetConfigurationService().GetRootDataDirectory(), true);
            }
        }

        private IConfigurationService GetConfigurationService()
        {
            if (this.configurationService != null)
            {
                return this.configurationService;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>();

            var configuration = builder.Build(); // Build the configuration

            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();

            return new DefaultConfigurationService(loggerMock.Object, configuration);

        }
    }
}