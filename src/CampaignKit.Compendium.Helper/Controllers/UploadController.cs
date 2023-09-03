using Azure;

using Microsoft.AspNetCore.Mvc;

using ReverseMarkdown.Converters;

namespace CampaignKit.Compendium.Helper.Controllers
{
    /// <summary>
    /// Default controller for handling file uploads.
    /// </summary>
    public partial class UploadController : Controller
    {
        /// <summary>
        /// Returns a file from the provided IFormFile.
        /// </summary>
        /// <param name="file">The file to be returned.</param>
        /// <returns>The file as an application/octet-stream.</returns>
        [HttpPost("upload/single")]
        public async Task<IActionResult> Single(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return this.BadRequest("No file uploaded.");
                }

                using var reader = new StreamReader(file.OpenReadStream());
                var content = await reader.ReadToEndAsync();

                return this.Ok(content);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

    }
}
