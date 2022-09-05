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
            return View(missions);
            //return View(launches);
        }

        //return a list of MissionReports - give it a list of launches and dictionary of payloads 
        private List<MissionReport> BuildMissionReport(List<Launch> allLaunches, Dictionary<string, Payload> payloadsToMap)
        {
            List<MissionReport> missions = new List<MissionReport>();

            foreach (Launch launch in allLaunches)
            {
                MissionReport mission = new MissionReport();

                mission.success = launch.success;
                mission.dateTime = launch.static_fire_date_utc;
                mission.rocket = launch.name;
                //mission.picUrl = launch.links.patch.small;
                mission.launchId = launch.id;
                mission.payloadMass = 0;
                missions.Add(mission);

                //i really dislike this nested ForEach loop, I'm sorry. 
                if (launch.payloads.Any())
                {
                    //we have to have this because payloads is an array unless.... there's LINQ...? no. idk. 
                    foreach (string payloadId in launch.payloads)
                    {
                        Payload payloadToAdd = new Payload(); //using default gave me the same error 
                        bool matchingPayloadFound = payloadsToMap.TryGetValue(payloadId, out payloadToAdd);
                        //loop through payloads - utilize dictionary to TryGetValue (try to find) matching payload by payload Id. Add payloads to mission 
                        //TryGetValue returns a bool, first value is what you feed into it to search, the "out" is 'where is this value going'. 
                        if (matchingPayloadFound)
                        {
                            mission.payloads.Add(payloadToAdd);
                            mission.payloadMass += payloadToAdd.mass_kg;
                        }

                    }
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
