namespace SpaceX.Models
{
    public class MissionReport
    {

        public DateTime? dateTime { get; set; }
        public string rocket { get; set; }
        public bool? success { get; set; }

        //maybe I need to initialize this as an empty list. 
        public List<Payload> payloads { get; set; } = new List<Payload>();


        public double? payloadMass { get; set; }

        public string picUrl { get; set; }

        public string launchId { get; set; }


    }



}
