using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LayoutTemplate.Application.BlobStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // POST: api/blobstorage/container/{blobContainerName}
        // To creates a new container in a storage account.,
        // for more details, see https://docs.microsoft.com/en-us/rest/api/storageservices/create-container.
        [HttpPost("blobstorage/container/{blobContainerName}")]
        public async Task<ActionResult<BlobContainerClient>> CreateBlobContainer([FromRoute] string blobContainerName)
        {
            _log.LogDebug($"REST request to create a new container: {blobContainerName}");
            return await _storageService.CreateBlobContainerAsync(blobContainerName);
        }

        // POST: api/blobstorage/container/{blobContainerName}
        // To upload blobs to a container
        [HttpPost("blobstorage/container/{blobContainerName}/blob")]
        public async Task<ActionResult<bool>> UploadAsync([FromRoute] string blobContainerName, IFormFile file)
        {
            _log.LogDebug($"REST request to upload blobs to a container: {blobContainerName}");
            return await _storageService.UploadAsync(blobContainerName, file);
        }


        // GET: api/blobstorage/container/{blobContainerName}/blob
        // To list all of the blobs in a container.
        [HttpGet("blobstorage/container/{blobContainerName}/blob")]
        public async Task<List<BlobItem>> GetBlobsAsync([FromRoute] string blobContainerName)
        {
            _log.LogDebug($"REST request to upload blobs to a container: {blobContainerName}");
            return await _storageService.GetBlobsAsync(blobContainerName);
        }
    }
}
