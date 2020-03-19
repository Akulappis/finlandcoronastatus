using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinlandCoronaStatus
{
    class Corona
    {
        public static string FetchDataFromJSON()
        {
            string rawjson = new WebClient().DownloadString("https://w3qa5ydb4l.execute-api.eu-west-1.amazonaws.com/prod/finnishCoronaData"); //Download json into string
            JObject jObject = JObject.Parse(rawjson); //Parse json into JObject
            var diseased = jObject["confirmed"].ToList();
            var deaths = jObject["deaths"].ToList();
            var recovered = jObject["recovered"].ToList();
            return "asd";

        }
    }
    
}
