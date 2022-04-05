using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST_DEV_JCL_03022022.Controllers
{
    public class Tbl_TokaController : Controller
    {
        // GET: Tbl_Toka
        public ActionResult Index()
        {


            var client = new RestClient("https://api.toka.com.mx/candidato/api/login/authenticate");
            {
                client.Authenticator = new HttpBasicAuthenticator("ucand0021", "yNDVARG80sr@dDPc2yCT!");
            }
            //var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);

            return View();
        }
    }
}