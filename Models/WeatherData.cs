using System.Text.Json.Serialization;

namespace WeatherApp1.Models
{
    public class WeatherResponse
    {
        public Location Location { get; set; } = new();
        public Current Current { get; set; } = new();
    }

    public class Location
    {
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lon { get; set; }
        
        [JsonPropertyName("tz_id")]
        public string TZ_ID { get; set; } = string.Empty;
        
        [JsonPropertyName("localtime_epoch")]
        public long LocaltimeEpoch { get; set; }
        
        public string Localtime { get; set; } = string.Empty;
    }

    public class Current
    {
        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }
        
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; } = string.Empty;
        
        [JsonPropertyName("temp_c")]
        public double TempC { get; set; }
        
        [JsonPropertyName("temp_f")]
        public double TempF { get; set; }
        
        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }
        
        public Condition Condition { get; set; } = new();
        
        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }
        
        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }
        
        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; } = string.Empty;
        
        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }
        
        [JsonPropertyName("pressure_in")]
        public double PressureIn { get; set; }
        
        [JsonPropertyName("precip_mm")]
        public double PrecipMm { get; set; }
        
        [JsonPropertyName("precip_in")]
        public double PrecipIn { get; set; }
        
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        
        [JsonPropertyName("feelslike_c")]
        public double FeelslikeC { get; set; }
        
        [JsonPropertyName("feelslike_f")]
        public double FeelslikeF { get; set; }
        
        [JsonPropertyName("vis_km")]
        public double VisKm { get; set; }
        
        [JsonPropertyName("vis_miles")]
        public double VisMiles { get; set; }
        
        public double UV { get; set; }
        
        [JsonPropertyName("gust_mph")]
        public double GustMph { get; set; }
        
        [JsonPropertyName("gust_kph")]
        public double GustKph { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Code { get; set; }
    }
} 