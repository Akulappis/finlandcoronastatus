using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FinlandCoronaStatus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("Finland corona status as of: " + (DateTime.Now).ToString("dd/MM/yyyy"));
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Points.AddXY("Infected", FetchDataFromJSON().Diseased);
            chart1.Series["Series1"].Points.AddXY("Cured", FetchDataFromJSON().Deaths);
            chart1.Series["Series1"].Points.AddXY("Deaths", FetchDataFromJSON().Recovered);
        }
        public static CoronaObject FetchDataFromJSON()
        {
            string rawjson = new WebClient().DownloadString("https://w3qa5ydb4l.execute-api.eu-west-1.amazonaws.com/prod/finnishCoronaData"); //Download json into string
            JObject jObject = JObject.Parse(rawjson); //Parse json into JObject
            var diseasedCount = jObject["confirmed"].ToList().Count();
            var deathsCount = jObject["deaths"].ToList().Count();
            var recoveredCount = jObject["recovered"].ToList().Count();

            CoronaObject cp = new CoronaObject();
            cp.Diseased = diseasedCount.ToString();
            cp.Deaths = deathsCount.ToString();
            cp.Recovered = recoveredCount.ToString();

            return cp;
        }
    }
    public class CoronaObject
    {
        public string Diseased { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
    }
}
