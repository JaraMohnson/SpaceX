using Newtonsoft.Json;
using SpaceXFun.Models;
using System.Net;

namespace SpaceX.Models
{
    public class PayloadDAL
    {
        public List<Payload> GetPayloads() //adjust 
        {
            //api URL 
            string url = $"https://api.spacexdata.com/v4/payloads/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            List<Payload> result = JsonConvert.DeserializeObject<List<Payload>>(JSON);
            return result;
        }

        //public Payload GetPayloadById(string id)
        //{
        //    string url = $"https://api.spacexdata.com/v4/payloads/{id}";
        //    HttpWebRequest request = WebRequest.CreateHttp(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());

        //    string JSON = reader.ReadToEnd();

        //    Payload result = JsonConvert.DeserializeObject<Payload>(JSON);

        //    return result;

        //}

        //public double? GetPayloadMass(string id)
        //{
        //    string url = $"https://api.spacexdata.com/v4/payloads/{id}";
        //    HttpWebRequest request = WebRequest.CreateHttp(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    HttpStatusCode statusCode = response.StatusCode;


        //    StreamReader reader = new StreamReader(response.GetResponseStream());

        //    string JSON = reader.ReadToEnd();

        //    Payload result = JsonConvert.DeserializeObject<Payload>(JSON);

        //    if (result.mass_kg != null)
        //    {
        //        return result.mass_kg;
        //    }
        //    else return 0;

        //}

        
    }
}



//public double? GetPayloadMassDouble(string id)
//{
//    string url = $"https://api.spacexdata.com/v4/payloads/?id={id}";
//    HttpWebRequest request = WebRequest.CreateHttp(url);
//    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//    HttpStatusCode statusCode = response.StatusCode;

//    if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Accepted)
//    {
//        StreamReader reader = new StreamReader(response.GetResponseStream());

//        string JSON = reader.ReadToEnd();

//        Payload? result = JsonConvert.DeserializeObject<Payload>(JSON);

//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//        return result.mass_kg;
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
//    }

//    else return 0;



//}