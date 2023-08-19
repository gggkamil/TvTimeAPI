namespace TVTimeAPIWeb.Models
{
    public class Episode
    {
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }
        public DateTime AirDate { get; set; }
    }
}
