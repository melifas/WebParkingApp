using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParkingMVC
{
    public static class StaticContentUrlHtmlHelper
    {
        // Στην μέθοδο αυτή μπαίνει ενα ΄τοπικο' path π.χ ~/Images/orderedList1.png και βγάνει οτι βλέπω παρακάτω
        // Δηλαδή http://127.0.0.1:10000/devstoreaccount1/static-content/Images/orderedList1.png
        public static string StaticContentUrl(this HtmlHelper helper, string contentPath)
        {
            if (contentPath.StartsWith("~"))
            {
                //Κόβει το tilda και παραμένει το υπόλοιπο path π.χ ~/Images/orderedList1.png και κόβεται το tilda
                contentPath = contentPath.Substring(1);
            }
            //βγαίνει http://127.0.0.1:10000/devstoreaccount1/static-content/Images/orderedList1.png
            contentPath = string.Format("{0}/{1}", Settings.StaticContentBaseUrl.TrimEnd('/'), contentPath.TrimStart('/'));

            var url = new UrlHelper(helper.ViewContext.RequestContext);

            return url.Content(contentPath);
        }
    }
}