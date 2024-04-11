using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Domain.Entities
{
    [Table("movies")]
    public class Movie : EntityBase
    {
        [Column("title")]
        public string? Title { get; set; }

        [Column("rating")]
        public double Rating { get; set; }

        [Column("description")]
        public string? Description { get; set; } 
    }
}
