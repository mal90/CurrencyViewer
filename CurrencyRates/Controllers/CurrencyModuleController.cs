using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;


namespace CurrencyRates.Controllers
{
    public class CurrencyModuleController : ApiController
    {
        [HttpGet]
        [Route("api/rates/")]
        public IHttpActionResult GetRates()
        {
            return Ok(ReadXMLDocument());
        }

        private string ReadXMLDocument() 
        { 
            var rateURL = "https://www.forex.se/ratesxml.asp?id=492" ;
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(rateURL);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//row");

            var rateValueUSD = "";
            var rateValueEUR = "";
            foreach (XmlNode node in nodes)
            {
                string swiftCode = node["swift_code"].InnerText;

                if (swiftCode == "USD")
                {
                    rateValueUSD = node["sell_cash"].InnerText;
                }
                else if (swiftCode == "EUR")
                {
                    rateValueEUR = node["sell_cash"].InnerText;
                }
            }

            return "USD Value is " + rateValueUSD + " && " + "EUR value is " + rateValueEUR;
        }
    }
}
