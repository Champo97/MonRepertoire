using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonRepertoire.Models
{
    [Table("NiveauxCompetences")]
    public class NiveauCompetence
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est obligatoire")]
        public string Libelle { get; set; }
        public int Ordre { get; set; }
    }
}