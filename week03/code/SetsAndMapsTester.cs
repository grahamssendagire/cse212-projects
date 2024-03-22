 using System.Text.Json;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Net.Http;
using System.Threading.Tasks;

public class SetsAndMapsTester
{
    public static void DisplayPairs(List<string> words)
    {
        HashSet<string> set = new HashSet<string>();
        
        foreach (string word in words)
        {
            string reversed = new string(word.Reverse().ToArray());
            if (set.Contains(reversed) && word != reversed)
            {
                Console.WriteLine($"{word} & {reversed}");
            }
           
            else
            {
                set.Add(word);
            }
        }
   
    }

  private static string Reverse(string word)
    {
        char[] charArray = word.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 4)
                {
                    string degree = parts[4];
                    if (degreeCounts.ContainsKey(degree))
                    {
                        degreeCounts[degree]++;
                    }
                    else
                    {
                        degreeCounts.Add(degree, 1);
                    }
                }
            }
        }

        return degreeCounts;
    }
 public static bool IsAnagram(string word1, string word2)
    {
        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in word1.ToLower())
        {
            if (c != ' ')
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
        }

        foreach (char c in word2.ToLower())
        {
            if (c != ' ')
            {
                if (!charCount.ContainsKey(c) || charCount[c] == 0)
                {
                    return false;
                }
                else
                {
                    charCount[c]--;
                }
            }
        }

        return true;
    }


public class EarthquakeDailySummary
{
    public static async Task GetEarthquakeData()
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                var earthquakeData = JsonSerializer.Deserialize<FeatureCollection>(apiResponse);

                Console.WriteLine("=========== Earthquake TESTS ===========");

                foreach (var feature in earthquakeData.Features)
                {
                    Console.WriteLine($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
                }
            }
        }
    }
}

}
