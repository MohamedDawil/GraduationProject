using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Json
{

    public class JsonAddress
    {
        public Api api { get; set; }
        public Result2 result { get; set; }
    }

    public class Api
    {
        public string name { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public string encoding { get; set; }
    }

    public class Result2
    {
        public Address address { get; set; }
        public Status status { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string number { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
        public string description_sv { get; set; }
        public string description_en { get; set; }
    }

}
