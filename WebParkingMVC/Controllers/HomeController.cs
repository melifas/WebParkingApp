using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static WebParkingMVC.Controllers.ValuesController;

using System;
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
using Microsoft.Azure.Storage;
using Microsoft.Ajax.Utilities;

namespace WebParkingMVC.Controllers
{
    public class HomeController : Controller
    {
        CloudStorageAccount account;
        //CloudBlobClient client;*/

        private readonly BlobServiceClient blobServiceClient;
        private readonly string blobContainer;
        public HomeController()
        {
            var connString = CloudConfigurationManager.GetSetting("Storage");
            account = CloudStorageAccount.Parse(connString);

            /* client = account.CreateCloudBlobClient();
            _container = _client.GetContainerReference(CONTAINER_NAME);*/


                this.blobServiceClient = new BlobServiceClient(CloudConfigurationManager.GetSetting("Storage"));
                this.blobContainer = ConfigurationManager.AppSettings["ContainerName"];
        }

        Data_Access da = new Data_Access();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult AvailableParkingTypes()
        {
            ViewBag.startDate = DateTime.Now.Date;
            ViewBag.endDate = DateTime.Now.Date.AddDays(3);
            List<spgetAvailableparkingsTypeCount> model = new List<spgetAvailableparkingsTypeCount>();
            return View(model);
        }

        //[HttpPost]
        public ActionResult AvailableParkingTypes(DateTime startDate, DateTime endDate)
        {
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;       
            List<spgetAvailableparkingsTypeCount> model = da.AvailableParkings(startDate, endDate);            
            return View(model);
        }




        public async Task<String> AddBlob(string text)
        {
            var tokenServiceEndPoint = ConfigurationManager.AppSettings["newBlobEndPointUrl"];
            try
            {
                //get the uri to the data managing service
                var uri = new Uri(tokenServiceEndPoint);
                
                Debug.WriteLine("Gatekeeper : Calling Valet key service to get a new GUID");
                
                var request = HttpWebRequest.Create(uri);
                //http request betwenn the services provides a safety layer
                var response = await request.GetResponseAsync();
                var responseString = string.Empty;
                var serializer = new DataContractJsonSerializer(typeof(StorageEntitySas));
                var blobSas = (StorageEntitySas)serializer.ReadObject(response.GetResponseStream());

                Debug.WriteLine("Gatekeeper : Got new GUID " + blobSas.Name);

                //create storage credentials object bases on SAS
                var credentials = new StorageCredentials(blobSas.Credentials);
                //using the returned SAS Credentials and Blob Uri create a block blob instance to upload
                var blob = new CloudBlockBlob(blobSas.BlobUri, credentials);

                Debug.WriteLine("Gatekeeper : Writing Data to  " + blobSas.BlobUri);

                await blob.UploadTextAsync(text);

                Debug.WriteLine("Gatekeeper : Writing Data succesfull ");

                Console.WriteLine("Blob upload succesfully : {0}", blobSas.Credentials);
                return  blobSas.Credentials;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> RedirectTest(string id)
        {
            try
            {
                Debug.WriteLine(" Valet : Got request for data with id : " + id);
                var blobclient = this.account.CreateCloudBlobClient();
                var container = blobclient.GetContainerReference(this.blobContainer);
                var blob = container.GetBlockBlobReference(id);

                if (!await blob.ExistsAsync())
                {
                    throw new Exception("Blob Does not Exist");
                }

                var policy = new SharedAccessBlobPolicy
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    // Create a signature fro 5 min
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),

                    //Create signature as long as we can
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5)

                };

                var sas = blob.GetSharedAccessSignature(policy);
                var blobSas = new StorageEntitySas
                {
                    BlobUri = blob.Uri,
                    Credentials = sas
                };

                Debug.WriteLine(string.Format("Valet Redirecting to {0}{1}", blobSas.BlobUri, blobSas.Credentials));

                return this.Redirect(string.Format("{0}{1}", blobSas.BlobUri, blobSas.Credentials));
            }
            catch (Exception ex)
            {

                var message = "Error " + ex.Message;
                Trace.TraceError(message);
                return this.View("Error");
            }
            
        }
        


        public async Task<string> GetBlob(string id)
        {
            var tokenServiceEndpoint = ConfigurationManager.AppSettings["readBlobEndpointUrl"];
            var uri = new Uri(tokenServiceEndpoint + id);
            Debug.WriteLine("Gatekeeper: Fetching Data from Blob "+uri.AbsoluteUri);
            WebClient webClient = new WebClient();
            var res = webClient.DownloadString(uri);
            return res;

        }

        public struct StorageEntitySas
        {
            public string Credentials;
            public Uri BlobUri;
            public string Name;
        }


    }
}