namespace SpaceX.Models
{
    public class MissionReport
    {

        public DateTime? dateTime { get; set; }
        public string rocket { get; set; }
        public bool? success { get; set; }


        //apparently these both have to be strings 
        public string? date { get; set; }
        public string? time { get; set; }  

        public List<Payload> payloads { get; set; } = new List<Payload>();


        public double? payloadMass { get; set; } = 0;

        // I need a string here so I can do N/A for 0 mass launches. Doubles can be converted. Won't matter since it's not ordered by mass on the table.
        public string payloadRank { get; set; } = "n/a";

        public string picUrl { get; set; }

        public string launchId { get; set; }

        public string details { get; set; } = "n/a";

    }



}
