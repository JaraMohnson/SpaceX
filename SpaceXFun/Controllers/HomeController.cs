using Microsoft.AspNetCore.Mvc;
using SpaceX.Models;
using SpaceXFun.Models;
using System.Diagnostics;
using System.Linq;

namespace SpaceX.Controllers
{
    public class HomeController : Controller
    {
        public LaunchDAL launchDAL = new LaunchDAL();
        public PayloadDAL payloadDAL = new PayloadDAL();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Launch> launches = launchDAL.GetLaunches().ToList();
            Dictionary<string, Payload> payloads = payloadDAL.GetPayloads().ToDictionary(
            p => p.id,
            p => p
            );

            List<MissionReport> missions = BuildMissionReport(launches, payloads);

            //putting this simple Reverse(); logic here so it doesn't get lost in the 
            //  sauce in build mission report 
            missions.Reverse();
            return View(missions);

        }




        //return a list of MissionReports - give it a list of launches and dictionary of payloads 
        //what a beastly method - I want to break this up I think for separation of responsibilities 
        private List<MissionReport> BuildMissionReport(List<Launch> allLaunches, Dictionary<string, Payload> payloadsToMap)
        {
            List<MissionReport> missions = new List<MissionReport>();

            foreach (Launch launch in allLaunches)
            {
                MissionReport mission = new MissionReport();

                mission.success = launch.success;
                mission.dateTime = launch.date_utc;
                mission.date = launch.date_utc.ToShortDateString();
                mission.time = TimeZoneInfo.ConvertTimeFromUtc
                    (launch.date_utc, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")).ToShortTimeString();  
                mission.rocket = launch.name;
                mission.picUrl = launch.links.patch.small;
                mission.launchId = launch.id;
                mission.details = launch.details;
                missions.Add(mission);

                //i really dislike this nested ForEach loop, I'm sorry. 

                //we have to have this because payloads is an array unless.... there's LINQ...? no. idk. nothing works. 
                //for each element in the payloads string[] in each launch 
                foreach (string payloadId in launch.payloads)
                {
                    Payload payloadToAdd = new Payload(); //using default gave me the same error 

                    bool matchingPayloadFound = payloadsToMap.TryGetValue(payloadId, out payloadToAdd);
                    
                    if (matchingPayloadFound)
                    {
                        mission.payloads.Add(payloadToAdd);
                        mission.payloadMass += payloadToAdd.mass_kg;
                    }
                }
            }

            //making changes to missions, not listToOrder
                //so I guess I gotta make another copy to edit the properties of my missions
            List<MissionReport> orderedList = missions.OrderByDescending(m => m.payloadMass).ToList();

            foreach (MissionReport m in missions) 
            {
                if (m.payloadMass != null && m.payloadMass != 0)
                {
                    m.payloadRank = orderedList.IndexOf(m)+1.ToString(); 
                }
            }

            return missions;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
