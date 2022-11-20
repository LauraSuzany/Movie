using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Movie.Entity
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("nickname ")]
        public string Nickname { get; set; }

        [DataType(DataType.Date)]
        [Column("birth_date")]
        public DateTime Birth_Date { get; set; }

        [Column("sex")]
        public char Sex { get; set; }

    }
}
