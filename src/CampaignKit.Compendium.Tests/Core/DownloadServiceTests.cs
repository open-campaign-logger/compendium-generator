// Unit Test
using CampaignKit.Compendium.Core.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Moq;

namespace CampaignKit.Compendium.Tests.Core
{
    [TestClass]
    public class DownloadServiceTests
    {
        private IConfigurationService? configurationService;

        [TestMethod]
        public async Task DownloadFile_Should_Create_Directory_If_Not_Exists()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object);
            this.DerivePathAndFileNames(sourceDataUri, out string path, out string file, "");

            // Act
            await sourceHelper.DownloadFile(sourceDataUri, configurationService?.GetPrivateDataDirectory() ?? string.Empty, overwrite);

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file)));
        }

        [TestMethod]
        public async Task DownloadFile_Should_Download_If_File_Exists_And_Overwrite_Is_True()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = true;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object);
            this.DerivePathAndFileNames(sourceDataUri, out string path, out string file, "");

            // Act
            Directory.CreateDirectory(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path));
            File.WriteAllText(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, configurationService?.GetPrivateDataDirectory() ?? string.Empty, overwrite);
            FileInfo fileInfoAfter = new(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file)));
            Assert.AreNotEqual(0, fileInfoAfter.Length);
        }

        [TestMethod]
        public async Task DownloadFile_Should_Not_Download_If_File_Exists_And_Overwrite_Is_False()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object);
            this.DerivePathAndFileNames(sourceDataUri, out string path, out string file, "");

            // Act
            Directory.CreateDirectory(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path));
            File.WriteAllText(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, configurationService?.GetPrivateDataDirectory() ?? string.Empty, overwrite);
            FileInfo fileInfoAfter = new(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path)));
            Assert.IsTrue(File.Exists(Path.Combine(GetConfigurationService().GetPrivateDataDirectory(), path, file)));
            Assert.AreEqual(0, fileInfoAfter.Length);

        }

        [TestMethod]
        public async Task DownloadFile_Should_Use_Overridename_If_Provided()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<DefaultDownloadService>>();
            var sourceHelper = new DefaultDownloadService(loggerMock.Object);

            // Act
            var filePath = await sourceHelper.DownloadFile(
                sourceDataUri, 
                configurationService?.GetPrivateDataDirectory() ?? string.Empty,
                overwrite,
                "document.html");

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(filePath.EndsWith("document.html"));

        }

        [TestInitialize]
        public void Setup()
        {
            // Setup the configuration service if required.
            configurationService ??= GetConfigurationService();

            // Check if the directory exists.
            if (Directory.Exists(configurationService.GetPrivateDataDirectory()))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(configurationService.GetPrivateDataDirectory(), true);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Check if the directory exists.
            if (Directory.Exists(GetConfigurationService().GetPrivateDataDirectory()))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(GetConfigurationService().GetPrivateDataDirectory(), true);
            }
        }

        private IConfigurationService GetConfigurationService()
        {
            if (configurationService != null)
            {
                return configurationService;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build(); // Build the configuration

            return new DefaultConfigurationService(configuration);

        }

        /// <summary>
        /// Separates the given URI into components and assigns the path and file name to the out parameters.
        /// </summary>
        /// <param name="sourceDataUri">The URI to be separated.</param>
        /// <param name="path">The path component of the URI.</param>
        /// <param name="file">The file name component of the URI.</param>
        /// <param name="filenameOverride">An optional override for the file name.</param>
        private void DerivePathAndFileNames(string sourceDataUri, out string path, out string file, string filenameOverride)
        {
            // Separate the URI into components
            var uri = new Uri(sourceDataUri);
            path = uri.AbsolutePath;
            file = Path.GetFileName(uri.AbsolutePath);

            if (string.IsNullOrEmpty(file) && !string.IsNullOrEmpty(filenameOverride))
            {
                file = filenameOverride;
            }

            if (string.IsNullOrEmpty(file))
            {
                throw new Exception($"Unable to derive filename from URI: {sourceDataUri}");
            }

            // Trim the leading slash off the uriPath.
            if (path.StartsWith("/"))
            {
                path = path[1..];
            }

            // Remove the file name from the path.
            path = Path.GetDirectoryName(path) ?? path;
        }
    }
}