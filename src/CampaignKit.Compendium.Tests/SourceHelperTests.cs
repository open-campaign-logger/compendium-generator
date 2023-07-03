// Unit Test
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace CampaignKit.Compendium.Core.Tests
{
    [TestClass]
    public class SourceHelperTests
    {
        private readonly string rootDataFolder = Path.Combine(Path.GetTempPath(), "CompendiumGenerator");

        private IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Add the json configuration file

            var configuration = builder.Build(); // Build the configuration

            return configuration;

        }

        [TestInitialize] public void Setup()
        {
            // Check if the directory exists.
            if (Directory.Exists(rootDataFolder))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(rootDataFolder, true);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Check if the directory exists.
            if (Directory.Exists(rootDataFolder))
            {
                // If the directory exists, delete it. The 'true' parameter means 
                // all files and subdirectories will also be deleted.
                Directory.Delete(rootDataFolder, true);
            }
        }

        [TestMethod]
        public async Task DownloadFile_Should_Create_Directory_If_Not_Exists()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<SourceHelper>>();
            var sourceHelper = new SourceHelper(loggerMock.Object, GetConfiguration());
            string path, file;
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out path, out file);

            // Act
            await sourceHelper.DownloadFile(sourceDataUri, rootDataFolder, overwrite);

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(rootDataFolder, path)));
            Assert.IsTrue(File.Exists(Path.Combine(rootDataFolder, path, file)));
        }

        [TestMethod]
        public async Task DownloadFile_Should_Not_Download_If_File_Exists_And_Overwrite_Is_False()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = false;
            var loggerMock = new Mock<ILogger<SourceHelper>>();
            var sourceHelper = new SourceHelper(loggerMock.Object, GetConfiguration());
            string path, file;
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out path, out file);

            // Act
            Directory.CreateDirectory(Path.Combine(rootDataFolder, path));
            File.WriteAllText(Path.Combine(rootDataFolder, path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, rootDataFolder, overwrite);
            FileInfo fileInfoAfter = new FileInfo(Path.Combine(rootDataFolder, path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(rootDataFolder, path)));
            Assert.IsTrue(File.Exists(Path.Combine(rootDataFolder, path, file)));
            Assert.AreEqual(0, fileInfoAfter.Length);

        }

        [TestMethod]
        public async Task DownloadFile_Should_Download_If_File_Exists_And_Overwrite_Is_True()
        {
            // Arrange
            var sourceDataUri = "https://raw.githubusercontent.com/open5e/open5e-api/staging/data/WOTC_5e_SRD_v5.1/document.json";
            var overwrite = true;
            var loggerMock = new Mock<ILogger<SourceHelper>>();
            var sourceHelper = new SourceHelper(loggerMock.Object, GetConfiguration());
            string path, file;
            sourceHelper.DerivePathAndFileNames(sourceDataUri, out path, out file);

            // Act
            Directory.CreateDirectory(Path.Combine(rootDataFolder, path));
            File.WriteAllText(Path.Combine(rootDataFolder, path, file), string.Empty);
            await sourceHelper.DownloadFile(sourceDataUri, rootDataFolder, overwrite);
            FileInfo fileInfoAfter = new(Path.Combine(rootDataFolder, path, file));

            // Assert
            Assert.IsTrue(Directory.Exists(Path.Combine(rootDataFolder, path)));
            Assert.IsTrue(File.Exists(Path.Combine(rootDataFolder, path, file)));
            Assert.AreNotEqual(0, fileInfoAfter.Length);
        }
    }
}