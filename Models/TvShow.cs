namespace TVTimeAPIWeb.Models
{
    public class TVShow
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; } 
        public List<Season> Seasons { get; set; }
    }
}
