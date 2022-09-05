namespace SpaceX.Models
{
    public class Payload
    {
        public Dragon dragon { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool reused { get; set; }
        public string launch { get; set; }
        public string[] customers { get; set; }
        public object[] norad_ids { get; set; }
        public string[] nationalities { get; set; }
        public string[] manufacturers { get; set; }
        public double? mass_kg { get; set; }
        public double? mass_lbs { get; set; }
        public string orbit { get; set; }
        public string reference_system { get; set; }
        public string regime { get; set; }
        public object longitude { get; set; }
        public object semi_major_axis_km { get; set; }
        public object eccentricity { get; set; }
        public object periapsis_km { get; set; }
        public object apoapsis_km { get; set; }
        public object inclination_deg { get; set; }
        public object period_min { get; set; }
        public object lifespan_years { get; set; }
        public object epoch { get; set; }
        public object mean_motion { get; set; }
        public object raan { get; set; }
        public object arg_of_pericenter { get; set; }
        public object mean_anomaly { get; set; }
        public string id { get; set; }
    }

    public class Dragon
    {
        public object capsule { get; set; }
        public object mass_returned_kg { get; set; }
        public object mass_returned_lbs { get; set; }
        public object flight_time_sec { get; set; }
        public object manifest { get; set; }
        public object water_landing { get; set; }
        public object land_landing { get; set; }
    }

}

