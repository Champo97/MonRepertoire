using MonRepertoire.Helper;
using MonRepertoire.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MonRepertoire.Models
{
    internal class RepertoireDbInitializer : DropCreateDatabaseAlways<RepertoireContext>
    {
        protected override void Seed(RepertoireContext repertoireContext)
        {
            try
            {
                var niveauComplexite1 = new NiveauComplexite { Id = 1, Ordre = 1, Libelle = "Facile" };
                var niveauComplexite2 = new NiveauComplexite { Id = 2, Ordre = 2, Libelle = "Moyen" };
                var niveauComplexite3 = new NiveauComplexite { Id = 3, Ordre = 3, Libelle = "Difficile" };

                var niveauCompetence1 = new NiveauCompetence { Id = 1, Ordre = 1, Libelle = "Insufisant" };
                var niveauCompetence2 = new NiveauCompetence { Id = 2, Ordre = 2, Libelle = "Moyen" };
                var niveauCompetence3 = new NiveauCompetence { Id = 3, Ordre = 3, Libelle = "Difficile" };

                var morceaux = new List<Morceau>
                {
                     new Morceau { Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence1.Id,  Tonalite = TonaliteEnum.Eb.CustomToString(), Titre = "Ba mwen on Ti Bo", NiveauComplexite = niveauComplexite1 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence2.Id, Titre = "Rosalinda", NiveauComplexite = niveauComplexite2 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence3.Id, Titre = "Bolote ma puce", NiveauComplexite = niveauComplexite3 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence3.Id, Titre = "Tchoukoutou", NiveauComplexite = niveauComplexite3 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence1.Id, Titre = "Glyceria", NiveauComplexite = niveauComplexite1 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence2.Id, Titre = "Dansez mazurka", NiveauComplexite = niveauComplexite2 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence3.Id, Titre = "Okay", NiveauComplexite = niveauComplexite3 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence1.Id, Titre = "Kolé séré", NiveauComplexite = niveauComplexite1 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence2.Id, Titre = "Chiré", NiveauComplexite = niveauComplexite2 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence2.Id, Titre = "Si sé taw", NiveauComplexite = niveauComplexite2 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence3.Id, Titre = "A la Leona", NiveauComplexite = niveauComplexite3 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence1.Id, Titre = "Les annees bonheur", NiveauComplexite = niveauComplexite1 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence3.Id, Titre = "Despacito ", NiveauComplexite = niveauComplexite3 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence1.Id, Titre = "La filo", NiveauComplexite = niveauComplexite1 }
                    ,new Morceau { Tonalite = TonaliteEnum.Eb.CustomToString(), Grille = "D | E | G | A", NiveauComplexiteId = niveauCompetence2.Id, Titre = "La defense ka vini fol", NiveauComplexite = niveauComplexite2 }
                };

                repertoireContext.NiveauxComplexites.AddRange(new NiveauComplexite[] { niveauComplexite1, niveauComplexite2, niveauComplexite3 });
                repertoireContext.NiveauxCompetences.AddRange(new NiveauCompetence[] { niveauCompetence1, niveauCompetence2, niveauCompetence3 });

                repertoireContext.Morceaux.AddRange(morceaux);

                foreach (var morceau in morceaux)
                {
                    Seance seance = new Seance { MorceauId = morceau.Id, NiveauCompetenceId = niveauCompetence1.Id, DateDerniereRepetition = DateTime.Now, Morceau = morceau, NiveauCompetence = niveauCompetence1 };
                    repertoireContext.Seances.Add(seance);
                }

                if (repertoireContext.SaveChanges() <= 0)
                {
                    throw new System.Exception("Les données n'ont pas pû être insérées en base");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}