﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Diagnostics;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Azure;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;
using static WebParkingMVC.Controllers.HomeController;

namespace WebParkingMVC.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly string blobContainer;

        public ValuesController()
        {
            this.blobServiceClient = new BlobServiceClient(CloudConfigurationManager.GetSetting("Storage"));
            this.blobContainer = ConfigurationManager.AppSettings["ContainerName"];

            /* string connectionString = Settings.StaticContentStorageConnectionString;
             string containerName = Settings.StaticContentContainer;

             //var blobServiceClient = new BlobServiceClient(connectionString);
             var staticContentContainer = blobServiceClient.GetBlobContainerClient(containerName);*/
        }

        // GET api/Values
        [Route("api/Values")]
        public StorageEntitySas Get()
        {
            try
            {
                Debug.WriteLine("Valet : Got request for new data storage");
                var blobName = Guid.NewGuid();

                // Retrieve a shared access signature of the location we should upload this file to
                var blobSas = this.GetSharedAccessReferenceForUpload(blobName.ToString());
                Trace.WriteLine(string.Format("Blob Uri: {0} - Shared Access Signature: {1}", blobSas.BlobUri, blobSas.Credentials));
                Debug.WriteLine(string.Format("Valet : Created new Blob Uri : {0} - Shared Access signature {1}", blobSas.BlobUri, blobSas.Credentials));
                return blobSas;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error has ocurred"),
                    ReasonPhrase = "Critical Exception"
                });
            }
        }

        /// <summary>
        /// We return a limited access key that allows the caller to upload a file to this specific destination for defined period of time
        /// </summary>
        private StorageEntitySas GetSharedAccessReferenceForUpload(string blobName)
        {
            var blob = blobServiceClient.GetBlobContainerClient(this.blobContainer).GetBlobClient(blobName);

            var storageSharedKeyCredential = new StorageSharedKeyCredential(blobServiceClient.AccountName, ConfigurationManager.AppSettings["AzureStorageEmulatorAccountKey"]);

            var blobSasBuilder = new BlobSasBuilder

            {
                BlobContainerName = this.blobContainer,
                BlobName = blobName,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5),
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5)
            };
            blobSasBuilder.SetPermissions(BlobSasPermissions.Write);
            var sas = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential).ToString();

            return new StorageEntitySas
            {
                BlobUri = blob.Uri,
                Credentials = sas
            };
        }
        


        public struct StorageEntitySas
        {
            public string Credentials;
            public Uri BlobUri;
            public string Name;
        }
    }
}
