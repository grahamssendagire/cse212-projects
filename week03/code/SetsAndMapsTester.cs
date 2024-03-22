 using System.Text.Json;

public class SetsAndMapsTester
{
//This will displays the pairs of words i.e words and its reversed form
public static void Run() {
        // Problem 1: Find Pairs with Sets
        Console.WriteLine("\n=========== Finding Pairs TESTS ===========");
        DisplayPairs(new[] { "am", "at", "ma", "if", "fi" });
        // ma & am
        // fi & if
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "bc", "cd", "de", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ba", "ac", "ad", "da", "ca" });
        // ba & ab
        // da & ad
        // ca & ac
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ac" }); // No pairs displayed
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "aa", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14" });
        // 32 & 23
        // 94 & 49
        // 31 & 13
 
        
                    }

      private static void DisplayPairs(string[] words) {
    
        // Creating new empty set for storing the words
        HashSet<string> set = new HashSet<string>();
        // iterrate through each element in the set of string words
        foreach (string word in words)
        {
            //this reverses the individual elements( strings of words)
            string reversed = new string(word.Reverse().ToArray());
            if (set.Contains(reversed) && word != reversed)
            {
                // print the string of words and their reversed format if the exist
                Console.WriteLine($"{word} & {reversed}");
            }
           
            else
            {
                // if reversed word isnot found then add it to the set
                set.Add(word);
            }
        }
      
    }
   
    
// problem 2

// function that returns a dictionary which contains the degrees of the file
public static Dictionary<string, int> SummarizeDegrees(string filename)

    {
        //a dictionary is a word to descripe a map datastructure in Csharp.
        Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

// stream reader is used to read data from the file  and create a strin then return that string.
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

    //problem 3
    // function on IsAnagram stores two strings as arguments

 public static bool IsAnagram(string word1, string word2)
    {
        // If the length of the two words isnot the same then the function will return false.
        if (word1.Length != word2.Length)
            return false;
// secound map of another problem 
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        // iterate through the letters in the first string.

        foreach (char c in word1.ToLower())
        {
            // passing the spaces in between the words or charracters.
            if (c != ' ')
            {
                // Look into this dictionary and see if it contains the charracter key in the dictionary
                if (charCount.ContainsKey(c))
                {
                //Lookup up to that key and increament it
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
        }
// iterating through the second string
        foreach (char c in word2.ToLower())
        {
             // passing the spaces in between the words or charracters.
            if (c != ' ')
            {
                //second string ,does each charracter in the secound string appearing in the first string(intersection)
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

//problem 4
// class of the eartquarke dail summary.
public class EarthquakeDailySummary

{
    // function on the GetEarthquakeData
    public static async Task GetEarthquakeData()
    {
        // making a get request to the URL(instance of the client class)
        using (var httpClient = new HttpClient())
        {
         // instance of the GetClass
            using (var response = await httpClient.GetAsync("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson"))
            {
               // gets response from the server and sends it to the string
                string apiResponse = await response.Content.ReadAsStringAsync();
            //Get this string and treat it as a jason file then convert it to a classs we defined as a future collection
                var earthquakeData = JsonSerializer.Deserialize<FeatureCollection>(apiResponse);
            // print the each item in the earthquake test.
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
 
 
