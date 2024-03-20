using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public abstract class SetsAndMapsTester {
    public abstract void Main();

    public void Run() {
        // Call the methods you want to execute here
        EarthquakeDailySummary();
    }

    private static void DisplayPairs(List<string> words) {
        Console.WriteLine("\n=========== Finding Pairs TESTS ===========");
        HashSet<string> seen = new HashSet<string>();
        foreach (string word in words) {
            string reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed) && word != reversed) {
                Console.WriteLine($"{word} & {reversed}");
            }
            seen.Add(word);
        }
        Console.WriteLine("---------");
    }

    // Problem 2: Degree Summary
    // Summarizes degrees earned by individuals in a census file
    // and returns a dictionary with the degree as key and the number
    // of individuals with that degree as value.
    static Dictionary<string, int> SummarizeDegrees(string census) {
        Dictionary<string, int> degreeSummary = new Dictionary<string, int>();
        using (StreamReader sr = new StreamReader(census)) {
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                string degree = data[3].Trim();
                if (degreeSummary.ContainsKey(degree)) {
                    degreeSummary[degree]++;
                }
                else {
                    degreeSummary[degree] = 1;
                }
            }
        }
        return degreeSummary;
    }

    // Problem 3: Anagrams
    // Determines if two words are anagrams of each other
    static bool IsAnagram(string word1, string word2) {
        Dictionary<char, int> freq1 = new Dictionary<char, int>();
        Dictionary<char, int> freq2 = new Dictionary<char, int>();

        foreach (char c in word1.ToLower().Replace(" ", "")) {
            if (freq1.ContainsKey(c)) {
                freq1[c]++;
            }
            else {
                freq1[c] = 1;
            }
        }

        foreach (char c in word2.ToLower().Replace(" ", "")) {
            if (freq2.ContainsKey(c)) {
                freq2[c]++;
            }
            else {
                freq2[c] = 1;
            }
        }

        return freq1.OrderBy(kv => kv.Key).SequenceEqual(freq2.OrderBy(kv => kv.Key));
    }

    // Problem 5: Earthquake
    // This function will read earthquake data from a JSON file and print
    // out a list of all earthquake locations and magnitudes.
    static void EarthquakeDailySummary() {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.SendAsync(getRequestMessage).Result;
        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Print earthquake details
        Console.WriteLine("=========== Earthquake TESTS ===========");
        foreach (var feature in featureCollection.Features) {
            
            Console.WriteLine($"{feature.Place} - Mag {feature.Mag}");
        }
    }
}

public class FeatureCollection {
    public List<Feature> Features { get; set; }

    public class Feature {
        public string Place { get; set; }
        public double Mag { get; set; }
    }
}