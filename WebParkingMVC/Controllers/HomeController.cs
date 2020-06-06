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

namespace WebParkingMVC.Controllers
{
    public class HomeController : Controller
    {

        Data_Access da = new Data_Access();
        public ActionResult Index()
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

        [HttpPost]
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