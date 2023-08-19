using System;
using System.Collections.Generic;


namespace TVTimeAPIWeb.Models
{
    public class Season
    {
        public int SeasonNumber { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
