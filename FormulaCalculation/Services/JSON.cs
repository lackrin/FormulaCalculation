using System.Collections.Generic;
using System.Net;
using FormulaCalculation.Interfaces;
using Newtonsoft.Json;

namespace FormulaCalculation.Services
{
    public class JSON : IJSON
    {

        

        public JSON()
        {
        }

        public Dictionary<string, dynamic> getJSON()
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://test.ethorstat.com/test.ashx");
            }

            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        }
    }
}