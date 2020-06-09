﻿namespace WebParkingMVC
{
    using Azure.Storage.Blobs;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using System.Configuration;

    public class WebRole : RoleEntryPoint
    {
        private static readonly string BlobContainer = ConfigurationManager.AppSettings["ContainerName"];

        public override bool OnStart()
        {
            BlobContainerClient container = new BlobContainerClient(CloudConfigurationManager.GetSetting("Storage"), BlobContainer);
            container.CreateIfNotExists();

            return base.OnStart();
        }
    }
}