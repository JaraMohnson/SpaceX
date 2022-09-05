using Newtonsoft.Json;
using System.Net;

namespace SpaceX.Models
{
    public class LaunchDAL
    //launch data access layer 
    {
        public List<Launch> GetLaunches()
        {
            //api URL 
            string url = $"https://api.spacexdata.com/v5/launches";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
          
            string JSON = reader.ReadToEnd();

            List<Launch> result = JsonConvert.DeserializeObject<List<Launch>>(JSON);

            return result;
        }

        //public Launch GetLaunchById(string id)
        //{
        //    string url = $"https://api.spacexdata.com/v5/launches/{id}";
        //    HttpWebRequest request = WebRequest.CreateHttp(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());

        //    string JSON = reader.ReadToEnd();

        //    Launch result = JsonConvert.DeserializeObject<Launch>(JSON);
        //    return result;

        //}



    }
}
