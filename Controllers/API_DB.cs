﻿using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_DEV_JCL_03022022.Controllers
{
    public class API_DB
    {
        //public dynamic Post(string url, string json, string autorizacion = null)
        //{
        //    try
        //    {
        //        var client = new RestClient(url);
        //        var request = new RestRequest("Auth/SignIn");
        //        request.AddHeader("content-type", "application/json");
        //        request.AddParameter("application/json", json, ParameterType.RequestBody);

        //        if (autorizacion != null)
        //        {
        //            request.AddHeader("Authorization", autorizacion);
        //        }

        //        //IRestResponse response = client.ExecutePostAsync(request);

        //        //dynamic datos = JsonConvert.DeserializeObject(response.Content);

        //        //return datos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        public dynamic Get(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            //myWebRequest.CookieContainer = myCookie;
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            //Leemos los datos
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

            dynamic data = JsonConvert.DeserializeObject(Datos);

            return data;
        }
    }
}