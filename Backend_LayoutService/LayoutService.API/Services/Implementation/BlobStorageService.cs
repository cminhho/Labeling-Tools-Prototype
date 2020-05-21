using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using LayoutService.API.Infrastructure;
using LayoutService.API.Services.Dto;
using LayoutTemplate.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static LayoutService.API.Configuration.AppConfig;

// https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
namespace LayoutService.API.Services.Implementation
{
    public class BlobStorageService : IStorageService
    {
        private readonly ILogger<BlobStorageService> _log;
        string _azureConnectionString = string.Empty;

        public BlobStorageService(ILogger<BlobStorageService> log)
        {
            _log = log;
            this._azureConnectionString = AppConfiguration.GetConfiguration("AzureStorageConnectionString");
        }

        public async Task<BlobContainerClient> CreateBlobContainerAsync(string blobContainerName)
        {
            BlobServiceClient blobServiceClient = CreateBlobServiceClient();

            // Create the container and return a container client object
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(blobContainerName);
            
            return containerClient;
        }

        public string UploadFileToBlob(string blobContainerName, string strFileName, byte[] fileData, string fileMimeType)
        {
            try
            {

                var _task = Task.Run(() => this.UploadFileToBlobAsync(blobContainerName, strFileName, fileData, fileMimeType));
                _task.Wait();
                string fileUrl = _task.Result;
                return fileUrl;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private async Task<string> UploadFileToBlobAsync(string blobContainerName, string strFileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                BlobServiceClient blobServiceClient = CreateBlobServiceClient();
                BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

                string fileName = this.GenerateFileName(strFileName);

                if (fileName != null && fileData != null)
                {
                    //CloudBlockBlob cloudBlockBlob = blobServiceClient.GetBlockBlobReference(fileName);
                    //cloudBlockBlob.Properties.ContentType = fileMimeType;
                    //await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
                    //return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private string GenerateFileName(string fileName)
        {
            string strFileName = string.Empty;
            string[] strName = fileName.Split('.');
            strFileName = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        public async Task<bool> UploadAsync(string blobContainerName, IFormFile file)
        {
            BlobServiceClient blobServiceClient = CreateBlobServiceClient();

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

            // Create a local file in the ./data/ directory for uploading and 
            string uploadDirectory = "./Uploads/";
            bool uploadDirectoryExists = Directory.Exists(uploadDirectory);
            if (!uploadDirectoryExists)
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            var fileName = Path.GetFileName(file.FileName);
            //var fileStream = new FileStream(Path.Combine(uploadDirectory, uploadPdfDto.Pdf.FileName), FileMode.Create);
            //string mimeType = uploadPdfDto.Pdf.ContentType;
            byte[] fileData = new byte[file.Length];

            string localFilePath = Path.Combine(uploadDirectory, fileName);

            // Write text to the file
            await File.WriteAllTextAsync(localFilePath, "Hello, World!");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            
            _log.LogDebug($"Uploading to Blob storage as blob: {blobClient.Uri}");
            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            return true;
        }

        public async Task<List<BlobItem>> GetBlobsAsync(string blobContainerName)
        {
            List<BlobItem> results = new List<BlobItem>();
            BlobServiceClient blobServiceClient = CreateBlobServiceClient();

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
                results.Add(blobItem);
            }
            return results;
        }

        private BlobServiceClient CreateBlobServiceClient()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(Constants.azureConnectionString);
            return blobServiceClient;
        }
    }
}
