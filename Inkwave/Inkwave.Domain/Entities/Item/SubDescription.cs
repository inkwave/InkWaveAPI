using Inkwave.Domain.Common;

namespace Inkwave.Domain.Entities

{
    public class SubDescription
    {
        //create a sub description for an item contains ISBN, Author, Publisher, Year, Edition, Pages, Language, Weight, Category, SubCategory, Tags
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public decimal Weight { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Tags { get; set; }


    }
}
