using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonRepertoire.Models
{
    [Table("Seances")]
    public class Seance
    {
        [Key]
        public int Id { get; set; }

        public int MorceauId { get; set; }
        [ForeignKey("MorceauId")]
        public Morceau Morceau { get; set; }
        public DateTime DateDerniereRepetition { get; set; }

        public int NiveauCompetenceId { get; set; }
        [Required(ErrorMessage = "Il faut renseigner le niveau atteint")]
        [ForeignKey("NiveauCompetenceId")]
        public NiveauCompetence NiveauCompetence { get; set; }
    }
}