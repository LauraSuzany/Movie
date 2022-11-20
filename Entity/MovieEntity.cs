using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Movie.Entity
{
    [Table("Movie")]
    public class MovieEntity
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("classification")]
        public string Classification { get; set; }

    }

}
