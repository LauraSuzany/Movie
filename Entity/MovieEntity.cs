﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Movie.Entity
{
    [Table("Filme")]
    public class MovieEntity
    {

        [Key]
        [Column("id")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Column("nome")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "data_lancamento")]
        [Column("data_lancamento")]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Descricao")]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        [Column("categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Classificacao")]
        [Column("classificacao")]
        public string Classificacao { get; set; }

    }

}