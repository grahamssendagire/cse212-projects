using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class FeatureCollection {

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
}