using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonRepertoire.Models
{
    public class RepertoireContext : DbContext
    {
        public RepertoireContext() : base("REPERTOIRE_DB")
        {
            Database.SetInitializer(new RepertoireDbInitializer());
        }

        public virtual DbSet<Morceau> Morceaux { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<NiveauComplexite> NiveauxComplexites { get; set; }
        public virtual DbSet<NiveauCompetence> NiveauxCompetences { get; set; }
    }
}