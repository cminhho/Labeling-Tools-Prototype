using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LayoutTemplate.Application.BlobStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace LayoutService.Controllers
{
    [Route("api")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly ILogger<FormRecognizer> _log;
        private readonly IStorageService _storageService;

        public BlobStorageController(ILogger<FormRecognizer> log,
            IStorageService storageService)
        {
            _log = log;
            _storageService = storageService;
        }

        /// <summary>
        ///     Creates a new container 
        /// </summary>
        [HttpPost("blobstorage/container/{blobContainerName}")]
        public async Task<ActionResult<BlobContainerClient>> CreateBlobContainer([FromQuery, BindRequired] string blobContainerName)
        {
            _log.LogDebug($"REST request to create a new container: {blobContainerName}");
            return await _storageService.CreateBlobContainerAsync(blobContainerName);
        }

        /// <summary>
        ///     Creates a new block, page, or append blob, or updates the content of an existing block blob.
        /// </summary>
        [HttpPut("blobstorage/container/{blobContainerName}")]
        public async Task<ActionResult<bool>> UploadAsync([FromRoute] string blobContainerName, IFormFile file)
        {
            _log.LogDebug($"REST request to upload blobs to a container: {blobContainerName}");
            return await _storageService.UploadAsync(blobContainerName, file);
        }

        /// <summary>
        /// 	Lists all of the blobs in a container.
        /// </summary>
        [HttpGet("blobstorage/container/{blobContainerName}")]
        public async Task<List<BlobItem>> GetBlobsAsync([FromRoute] string blobContainerName)
        {
            _log.LogDebug($"REST request to get all blobs in a container: {blobContainerName}");
            return await _storageService.GetBlobsAsync(blobContainerName);
        }

        /// <summary>
        ///     Deletes a specific blob in a container.
        /// </summary>
        [HttpDelete("blobstorage/container/{blobContainerName}/{filePath}")]
        public async Task<IActionResult> DeleteBlobAsync([FromRoute]string blobContainerName, [FromRoute]string filePath)
        {
            _log.LogDebug($"REST request to delete {filePath} in a container: {blobContainerName}");
            await _storageService.DeleteBlobAsync(blobContainerName, filePath);
            return Ok();
        }
    }
}
