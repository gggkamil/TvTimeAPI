using Microsoft.AspNetCore.Mvc;
using TVTimeAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TVTimeAPIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowController : ControllerBase
    {
        private List<TVShow> _tvShows = new List<TVShow>
        {
                    new TVShow
            {
                ID = 1,
                Title = "Example Show",
                Summary = "An example TV show",
                Seasons = new List<Season>
                {
                    new Season
                    {
                        SeasonNumber = 1,
                        Title = "Season 1",
                        Summary = "First season",
                        Episodes = new List<Episode>
                        {
                            new Episode
                            {
                                EpisodeNumber = 1,
                                Title = "Episode 1",
                                Summary = "First episode of Season 1",
                                Rating = 8.5,
                                AirDate = new DateTime(2023, 1, 1)
                            },
                            // Add more episodes
                        }
                    },
                    // Add more seasons
                }
            },
            // Your TVShow data...
        };

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetTvShowRatings()
        {
            var ratings = _tvShows.Select(show => new
            {
                show.ID,
                show.Title,
                show.Rating
            });

            return Ok(ratings);
        }

        [HttpGet("{showId}/seasons/{seasonNumber}")]
        public ActionResult<object> GetSeasonDetails(int showId, int seasonNumber)
        {
            var tvShow = _tvShows.FirstOrDefault(show => show.ID == showId);
            if (tvShow == null)
                return NotFound();

            var season = tvShow.Seasons.FirstOrDefault(s => s.SeasonNumber == seasonNumber);
            if (season == null)
                return NotFound();

            return Ok(season);
        }

        [HttpGet("{showId}/seasons/{seasonNumber}/episodes/{episodeNumber}")]
        public ActionResult<object> GetEpisodeDetails(int showId, int seasonNumber, int episodeNumber)
        {
            var tvShow = _tvShows.FirstOrDefault(show => show.ID == showId);
            if (tvShow == null)
                return NotFound();

            var season = tvShow.Seasons.FirstOrDefault(s => s.SeasonNumber == seasonNumber);
            if (season == null)
                return NotFound();

            var episode = season.Episodes.FirstOrDefault(e => e.EpisodeNumber == episodeNumber);
            if (episode == null)
                return NotFound();

            return Ok(episode);
        }
    }
}
