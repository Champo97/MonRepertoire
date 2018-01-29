using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonRepertoire.Models
{
    [Table("Morceaux")]
    public class Morceau
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre du morceau est obligatoire")]
        public string Titre { get; set; }
        public string Tonalite { get; set; }
        public string Grille { get; set; }

        public int NiveauComplexiteId { get; set; }
        [Required(ErrorMessage = "Il faut renseigner la complexité")]
        [ForeignKey("NiveauComplexiteId")] 
        public NiveauComplexite NiveauComplexite { get; set; }
    }
}