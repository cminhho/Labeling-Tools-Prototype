using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LayoutTemplate.Application.BlobStorage
{
    public interface IStorageService
    {
        Task<BlobContainerClient> CreateBlobContainerAsync(string blobContainerName);

        Task<bool> UploadAsync(string blobContainerName, IFormFile file);

        Task<List<BlobItem>> GetBlobsAsync(string blobContainerName);
    }
}
