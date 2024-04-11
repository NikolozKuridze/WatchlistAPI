using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Domain.Entities
{
    [Table("watchlists")]
    public class WatchlistItem : EntityBase
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")] 
        public User? User { get; set; }
        [Column("movie_id")]
        public int movieId { get; set; }
        [ForeignKey("movieId")]
        public Movie? movie { get; set; }

        [Column("is_watched")]
        public bool IsWatched { get; set; } = false; 

    }
}
