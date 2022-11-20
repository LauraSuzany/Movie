using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Movie.Entity
{
    [Table("evaluation")]
    public class EvaluationEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("note")]
        public double Note { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }

        [DataType(DataType.Date)]
        [Column("post_date")]
        public DateTime PostDate { get; set; }

        [ForeignKey("Movie")]
        [Column("movie_id_fk")]
        public long MovieIdFk { get; set; }

        public virtual MovieEntity Movie { get; set; }

        [ForeignKey("User")]
        [Column("user_id_fk")]
        public long UserIdFk { get; set; }

        public virtual UserEntity User { get; set; }
    }
}