public class FeatureCollection {

    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; }
    public class Earthquake
{
    public string Place { get; set; }
    public double Mag { get; set; }
}

public class Feature
{
    public Earthquake Properties { get; set; }
}


public class EarthquakeService
{
    private readonly HttpClient _client;

    public EarthquakeService(HttpClient client)
    {
        _client = client;
    }

    public async Task<FeatureCollection> GetEarthquakeData(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
       
    }
}

public class SetsAndMapsTester
{
    // Other methods...

    // Problem 4: Earthquake JSON Data
    public static async Task EarthquakeDailySummary()
    {
        var client = new HttpClient();
        var service = new EarthquakeService(client);
        var url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var featureCollection = await service.GetEarthquakeData(url);

        Console.WriteLine("=========== Earthquake TESTS ===========");
        foreach (var feature in featureCollection.Features)
        {
            Console.WriteLine($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }
    }
}
}