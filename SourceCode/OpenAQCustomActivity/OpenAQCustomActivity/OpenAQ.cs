using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using Amazon.SimpleNotificationService;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleNotificationService.Model;

namespace OpenAQCustomActivity
{
    public struct API
    {
        public const string COUNTRIES = "https://api.openaq.org/v1/countries";
        // pass the country code in the string. first result element is about the no of cities
        public const string COUNTRY_CITIES = "https://api.openaq.org/v1/cities?country={0}";

    }

    public static class OpenAPUtil
    {

        public static void CreateDynamoDBTable() { }


    }


    public class CountriesResult
    {
        public object meta { get; set; }
        public Country[] results { get; set; }

    }

    public class CitiesResult
    {
        
        public object meta { get; set; }
        public City[] results { get; set; }

    }

    public class LocationResult
    {
        public object meta { get; set; }
        public Location[] results { get; set; }

    }


    public class MeasurementResult
    {
        public object meta { get; set; }
        public Measurements[] results { get; set; }

    }

    public class LatestMeasurementResults
    {
        public object meta { get; set; }
        public LatestMeasurement[] results { get; set; }

    }

    /// <summary>
    /// Country listed on the https://openaq.org.orq 
    /// </summary>
    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string cities { get; set; }
        public int locations { get; set; }
        public int count { get; set; }


    }

    /// <summary>
    /// City listed in the https://openaq.org
    /// </summary>
    public class City
    {
        public string city { get; set; }
        public string country { get; set; }
        public int locations { get; set; }
        public int count { get; set; }
    }

    /// <summary>
    /// Location data for a city for measurement
    /// </summary>
    public class Location
    {
        public string location { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int count { get; set; }
        public int distance { get; set; }
        public string sourceName { get; set; }
        public string firstUpdated { get; set; }
        public string lastUpdated { get; set; }
        public string[] parameters { get; set; }
        public Coordinate coordinates { get; set; }

    }

    /// <summary>
    /// Coordiantes for the measuring location
    /// </summary>
    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

    }
    
    /// <summary>
    /// Latest Measurement done for a location in a city
    /// </summary>
    public class LatestMeasurement
    {
        public string location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public Measurements[] measurements { get; set; }
    }

    /// <summary>
    /// Measurement data for the quality of the Air  
    /// </summary>
    public class Measurements
    {
        public string parameter { get; set; }
        public double value { get; set; }
        public string lastUpdated { get; set; }
        public string unit { get; set; }
        public string sourceName { get; set; }
        public AveragingPeriod averagingPeriod { get; set; }
}

    public class AveragingPeriod
        {
            public string unit { get; set; }
            public string value { get; set; }
        }



}
