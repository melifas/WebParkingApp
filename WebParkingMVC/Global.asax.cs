using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebParkingMVC;
using WebParkingMVC.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebParkingMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                DeployStaticContent();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Deploying Static Content - Message:{0}", ex.Message);
                throw;
            }

        }

        private void DeployStaticContent()
        {
            string connectionString = Settings.StaticContentStorageConnectionString;
            string containerName = Settings.StaticContentContainer;

            var blobServiceClient = new BlobServiceClient(connectionString);
            var staticContentContainer = blobServiceClient.GetBlobContainerClient(containerName);
           

            //Create the container with public access permissions on the blobs in those containers
            staticContentContainer.CreateIfNotExists(PublicAccessType.Blob);

            // Αυτό διαγράφει το blob container αν υπάρχει ηδη. Χωρίς αυτό χτυπάει Exception
            try
            {
                staticContentContainer.DeleteIfExists();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Delete Failed {0}", ex.Message);
                throw;
            }


            //Upload Images folder
            UploadFolder("Images", staticContentContainer);

            //Upload Scripts folder
            UploadFolder("Scripts", staticContentContainer);
        }

        /// <summary>
        /// Upload the files in the folder
        /// </summary>
        /// <param name="folderName">Folder in web application project to upload files from</param>
        /// <param name="container">Destination BLOB Storage container to upload files to</param>
        private void UploadFolder(string folderName, BlobContainerClient container)
        {
            Trace.TraceInformation("Uploading Static Content Folder - Container:{0} Folder:{1}", container, folderName);

            var imageFiles = Directory.GetFiles(Server.MapPath(folderName));
            foreach (var imageFile in imageFiles)
            {
                Trace.TraceInformation("Uploading File - Container:{0} Folder:{1} File:{2}", container, folderName, imageFile);

                var fileName = Path.GetFileName(imageFile);

                if (fileName == null)
                {
                    return;
                }

                var blobFile = container.GetBlobClient(string.Format("{0}/{1}", folderName, fileName));
                blobFile.Upload(imageFile);
            }
        }



    }
}
