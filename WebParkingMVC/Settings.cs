using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace WebParkingMVC
{
    public class Settings
    {
        public static string StaticContentStorageConnectionString
        {
            get
            {
                return RoleEnvironment.GetConfigurationSettingValue("StaticContent.StorageConnectionString");
            }
        }

        public static string StaticContentContainer
        {
            get
            {
                return RoleEnvironment.GetConfigurationSettingValue("StaticContent.Container");
            }
        }

        public static string StaticContentBaseUrl
        {
            get
            {
                var account = CloudStorageAccount.Parse(StaticContentStorageConnectionString);

                return string.Format("{0}/{1}", account.BlobEndpoint.ToString().TrimEnd('/'), StaticContentContainer.TrimStart('/'));
            }
        }

    }
}